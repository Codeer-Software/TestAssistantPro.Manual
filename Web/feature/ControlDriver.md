# ControlDriver

ControlDriver は、[Selenium の IWebElement](https://www.selenium.dev/selenium/docs/api/dotnet/html/T_OpenQA_Selenium_IWebElement.htm)　をラップして、
要素を操作しやすくしたドライバです。多くの物は複数のアプリケーション間で再利用できます。

TestAssistantPro を使って Web のテストプロジェクトを作成すると次のパッケージがインストールされ、含まれるControlDriverを利用できます。

+ [Selenium.StandardControls](https://github.com/Codeer-Software/Selenium.StandardControls)

詳細はそれぞれのリンクを参照してください。

## カスタムControllDriver

アプリケーションによっては固有のコントロールや上述した以外の3rdパティーのコントロールを利用することがあります。
TestAssistantPro はそのような場合でもそれぞれに対する ControlDriver を実装することで対応できます。

カスタムControlDrierは`ControlDriverBase`クラスを継承したクラスをPageObjectプロジェクトの任意の場所に配置します。
TestAssistantProは自動的にこのクラスを読み取り、AnalyzeWindowに反映します。

```cs
public class TextBoxDriver : ControlDriverBase
{
    public TextBoxDriver(IWebElement element) : base(element){}

    public TextBoxDriver(IWebElement element, Action wait) : base(element){ Wait = wait; }

    public Action Wait { get; set; }

    public void Edit(string text)
    {
        var js = JS;
        Element.Show();
        Element.Focus();
        js.ExecuteScript("arguments[0].select();", Element);
        Element.SendKeys(Keys.Delete);
        Element.SendKeys(text);
        try
        {
            js.ExecuteScript("");//sync.
        }
        catch { }
        Wait?.Invoke();
    }

    public static implicit operator TextBoxDriver(ElementFinder finder) => finder.Find<TextBoxDriver>();

    [CaptureCodeGenerator]
    public string GetWebElementCaptureGenerator()
    {
        return $@"
                element.addEventListener('change', function() {{ 
                    var name = __codeerTestAssistantPro.getElementName(this);
                    __codeerTestAssistantPro.pushCode(name + '.Edit(""' + this.value + '"");');
                }}, false);
        ";
    }

    [TargetElementInfo]
    public static TargetElementInfo TargetElementInfo => new TargetElementInfo("input");
}
```

TestAssistantProは初めに`GetWebElementCaptureGenerator`で返されるJavaScriptコードをブラウザに埋め込みます。
このスクリプトはキャプチャの実行時にブラウザの操作をハンドリングし、C#コードを生成するコードを定義します。
上記の例では、`change`イベントの発生時に、`__codeerTestAssistantPro.pushCode`によりEditメソッドを実行するC#コードを出力しています。
`element`変数には、このControlDriverが対象としている要素のインスタンスが設定されます。
C#上の変数名は`__codeerTestAssistantPro.getElementName`メソッドに要素を指定することで取得できます。

要素の状態を監視して変更を検知する場合などは、`__codeerTestAssistantPro.addPolling`メソッドにコールバックを設定してください。
このコールバックは定期的に実行さるため、変更を検知し、変更が検知されたときにC#コードを出力するようにします。

```cs
[CaptureCodeGenerator]
public string GetWebElementCaptureGenerator()
{
    return $@"
    __codeerTestAssistantPro.addPolling(() => {{
        
        const editor = element.querySelector('{_editorTag}');
        if (!!editor) return;

        let oldValue = window.__InlineEditableDriverBase['{guid}'];
        let value = element.querySelector('span').innerText;
        if (!oldValue) {{
            oldValue = value;
        }}
        if (oldValue != value) {{
            const name = __codeerTestAssistantPro.getElementName(element);
            __codeerTestAssistantPro.pushCode(name + '.Edit(""' + value + '"");');
        }}

        window.__InlineEditableDriverBase['{guid}'] = value;
    }});
".Trim();
}
```

キャプチャした動作を再生するメソッドは任意の名前をつけることができますが、慣例として`Edit`という名前を利用することを推奨します。

`TargetElementInfoAttribute`が設定されたメソッドはAnalyuzeWindowで要素が選択された際に利用されます。
選択された要素が、指定されたセレクタと一致した場合に、デフォルトの値として該当のControlDriverが選択されます。
