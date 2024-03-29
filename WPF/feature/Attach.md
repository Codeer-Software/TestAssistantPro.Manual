# Attach方法ごとのコード

Attach とはプログラムコードからアプリケーションを動かす際に、操作する対象の要素(WindowDriver/UserControlDriver)と接続する処理のことをさします。 実際にはプログラムコードのメソッドとして実現されます。
これは TestAssistantPro を使わない場合にも手書きで作成します。
詳細は[こちら](https://github.com/Codeer-Software/Friendly/blob/master/TestAutomationDesign.jp.md#attach)を参照してください。
TestAssistantPro はキャプチャ時にこのメソッドを使ってドライバを検索します。
TestAssistantPro で利用するためには `WindowDriverIdentifyAttribute`、`UserControlDriverIdentifyAttribute` 属性を付けます。

<br>
Attach には WinndowDriver/UserControlDriver ごとに次の2種類があります。

| 種類 | 説明 |
|-----|-----|
| Type Full Name | .Net の TypeFullName で特定します。 |
| Custom | カスタムの特定手法です。 |

それぞれの種類ごとに生成されるコードを次に記載します。

## WindowDriverへの接続

WindowDriver を接続の対象とする関数には `WindowDriverIdentifyAttribute` 属性を付与します。

### TypeFullName

```cs
public static class MainWindowDriverExtensions
{
    [WindowDriverIdentify(TypeFullName = "WpfDockApp.MainWindow")]
    public static MainWindowDriver AttachMainWindow(this WindowsAppFriend app)
        => app.WaitForIdentifyFromTypeFullName("WpfDockApp.MainWindow").Dynamic();
}
```
### Custom

キャプチャ時に Try が先に呼び出されます。
この Try メソッドは通常、TestAssistantPro からしか利用されません。
そこで渡された WindowControl が目的の Window である場合は true を返すように実装します。
ジェネリック型パラメーター T は識別子を表す任意の型に書き換えてください。
Try で作成した識別子を使って Attach メソッドが実行されます。
次の Variable Window Text が Custom の実装例となりますので、そちらを参考にしてみてください。
```cs
public static class MainWindowDriverExtensions
{
    [WindowDriverIdentify(CustomMethod = "Try")]
    public static MainWindowDriver AttachMainForm(this WindowsAppFriend app, T identifier)
    {
    }

    public static bool Try(WindowControl window, out T identifier)
    {
    }
}
```

### Variable Window Text

これは Custom の実装の一つです。WindowText を元に識別しています。
```cs
public static class MainWindowDriverExtensions
{
    [WindowDriverIdentify(CustomMethod = "Try")]
    public static MainWindowDriver AttachMainForm(this WindowsAppFriend app, string identifier)
        => app.WaitForIdentifyFromWindowText(identifier).Dynamic();

    public static bool Try(WindowControl window, out string identifier)
    {
        identifier = window.GetWindowText();
        return window.TypeFullName == "WpfDockApp.MainWindow";
    }
}
```

## UserContorlDriverへの接続

UserControlDriver を接続の対象とする関数には `UserControlDriverIdentifyAttribute` 属性を付与します。

### TypeFullName

```cs
public static class XUserControlDriverExtensions
{
    [UserControlDriverIdentify]
    public static XUserControlDriver AttachXUserControl(this ParentDriver parent)
        => parent.Core.GetFromTypeFullName("WinFormsApp.XUserControlDriver").FirstOrDefault()?.Dynamic();
}
```

### Custom

キャプチャ時に Try が先に呼び出されます。
ジェネリック型パラメーター T は識別子を表す任意の型に書き換えてください。
見つかった分だけ識別子を返します。
Try で作成した識別子を使って Attach メソッドが実行されます。

```cs
public static class XUserControlDriverExtensions
{
    [UserControlDriverIdentify(CustomMethod = "TryGet")]
    public static XUserControlDriver AttachXUserControl(this ParentDriver parent, T identifier)
    {
    }

    public static T[] TryGet(this ParentDriver parent)
    {
    }
}
```

これは Custom の実装の一つです。<br>
```cs
public static class OrderDocumentUserControlDriverExtensions
{
    //ここに特定のためのカスタムコードを入れる
    //キャプチャ時にTestAssistantProが使うCustomMethod名を指定します。
    [UserControlDriverIdentify(CustomMethod = "TryGet")]
    public static OrderDocumentUserControlDriver AttachOrderDocumentUserControl(this WindowsAppFriend app, string identifier)
        //アプリの全てのウィンドウからTypeが一致するものを取得
        => app.GetTopLevelWindows().
                SelectMany(e => e.GetFromTypeFullName("WpfDockApp.OrderDocumentUserControl")).
                //その中でタイトルが一致するものを取得
                Where(e => GetTitle(e) == identifier).
                FirstOrDefault()?.Dynamic();

    //キャプチャ時にTestAssisatntProが使います。
    //発見した目的のUserControlの識別子をout引数に入れます。
    public static string[] TryGet(this WindowsAppFriend app)
        //アプリの全てのウィンドウからTypeが一致するものを取得
            => app.GetTopLevelWindows().
                SelectMany(e => e.GetFromTypeFullName("WpfDockApp.OrderDocumentUserControl")).
                //識別子にタイトルを使う
                Select(e => GetTitle(e)).
                ToArray();

    static string GetTitle(AppVar e)
        //タイトルを取得します。
        //UserContorlから親方向にたどって見つかるLayoutDocumentControlが持っています。
        //これは利用しているライブラリ(今回はXceed)の知識が必要です。
        => e.VisualTree(TreeRunDirection.Ancestors).ByType("Xceed.Wpf.AvalonDock.Controls.LayoutDocumentControl").First().Dynamic().Model.Title;
}
```

### アプリケーション全体からの検索

特定の WindowDriver/UserControlDriver から検索する以外にアプリケーション全体から探す方法もあります。
WindowsAppFriend の拡張にすると以下のようにアプリケーション全体から検索できます。

```cs
public static class XUserControlDriverExtensions
{
    [UserControlDriverIdentify]
    public static XUserControlDriver AttachOutputForm(this WindowsAppFriend app)
        => app.GetTopLevelWindows().SelectMany(e => e.GetFromTypeFullName("WinFormsApp.XUserControlDriver")).FirstOrDefault()?.Dynamic();
}
```
