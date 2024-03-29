# ControlDriver

ControlDriver は、[Selenium の IWebElement](https://www.selenium.dev/selenium/docs/api/dotnet/html/T_OpenQA_Selenium_IWebElement.htm) をラップして、
要素を操作しやすくしたドライバです。
多くの物は複数のアプリケーション間で再利用できます。

TestAssistantPro を使って Web のテストプロジェクトを作成すると次のパッケージがインストールされ、含まれる ControlDriver を利用できます。

+ [Selenium.StandardControls](https://github.com/Codeer-Software/Selenium.StandardControls)

詳細はそれぞれのリンクを参照してください。

## カスタムControllDriver

アプリケーションによっては固有のコントロールや上述した以外の 3rd パーティのコントロールを利用することがあります。
TestAssistantPro はそのような場合でもそれぞれに対する ControlDriver を実装することで対応できます。

カスタム ControlDriver は `ControlDriverBase` クラスを継承したクラスを PageObject プロジェクトの任意の場所に配置します。
TestAssistantPro は自動的にこのクラスを読み取り、AnalyzeWindow に反映します。

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
### Capture
操作のキャプチャは JavaScript で行います。`CaptureCodeGeneratorAttribute` を付けたメソッドがあると呼び出され実行されます。
ここでイベント処理を行い操作時に C# のコードが生成されるようにします。
上記の例では、`change` イベントの発生時に、 Edit メソッドを実行する C# コードを出力しています。
このキャプチャ用の JavaScript で使うことができる変数とメソッドがあります。

|  変数/メソッド |  説明  |
| ---- | ---- |
|element | このControlDriverで操作対象としている要素です。|
|window.__codeerTestAssistantPro.getElementName(element) | 指定の要素に対応するドライバの変数名を取得します。|
|window.__codeerTestAssistantPro.pushCode(code) | 生成したコードを追加します。|
|window.__codeerTestAssistantPro.pushUsings(code) | C#のコード上で必要なUsingを追加します。|
|window.__codeerTestAssistantPro.addPolling(func) | ポーリングでコールバックされる関数を登録します。|

要素の状態を監視して変更を検知する場合などは、`__codeerTestAssistantPro.addPolling` メソッドにコールバックを設定してください。
このコールバックは定期的に実行さるため、変更を検知し、変更が検知されたときに C# コードを出力するようにします。

```cs
[CaptureCodeGenerator]
public string GetWebElementCaptureGenerator()
{
    var guid = Guid.NewGuid();
    return $@"
    __codeerTestAssistantPro.addPolling(() => {{
        //前回の値を取得する
        let oldValue = window.__captureCache['{guid}'];
        let value = element.querySelector('span').innerText;
        if (!oldValue) {{
            //初回の場合は前回値はない
            oldValue = value;
        }}

        //値が異なっていたら編集されていたとみなし、コード生成
        if (oldValue != value) {{
            const name = __codeerTestAssistantPro.getElementName(element);
            __codeerTestAssistantPro.pushCode(name + '.Edit(""' + value + '"");');
        }}

        window.__InlineEditableDriverBase['{guid}'] = value;
    }});
".Trim();
}
```

`TargetElementInfoAttribute` が設定されたメソッドは [AnalyuzeWindow] で要素が選択された際に利用されます。
選択された要素が、指定されたセレクタと一致した場合に、デフォルトの値として該当の ControlDriver が選択されます。

例えばこれはタグが input の時にこのドライバが選択されます。
```cs
[TargetElementInfo]
public static TargetElementInfo TargetElementInfo => new TargetElementInfo("input");
```

この書き方であればタグが input で type 属性が checkbox の場合にこのドライバが選択されます。
```cs
[TargetElementInfo]
public static TargetElementInfo TargetElementInfo => new TargetElementInfo("input", "type", "checkbox");
```

上記の二つはともに input タグですが、より指定の細かい方が優先されます。