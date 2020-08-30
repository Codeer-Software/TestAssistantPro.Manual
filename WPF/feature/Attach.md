# Attach方法ごとのコード

Attachとはプログラムコードからアプリケーションを動かす際に、操作する対象の要素(WindowDriver/UserControlDriver)と接続する処理のことをさします。 実際にはプログラムコードのメソッドとして実現されます。
これはTestAssistantProを使わない場合にも手書きで作成します。
詳細は[こちら](https://github.com/Codeer-Software/Friendly/blob/master/TestAutomationDesign.jp.md#attach)を参照してください。
TestAssistantProはキャプチャ時にこのメソッドを使ってドライバを検索します。
そのためTestAssitantProを使う場合は`WindowDriverIdentifyAttribute`、`UserControlDriverIdentifyAttribute`属性を付けてTestAssistantProが利用できるようにします。

<br>
AttachにはWinndowDriver/UserControlDriverごとに次の4種類があります。

| 種類 | 説明 |
|-----|-----|
| Type Full Name | .Net の TypeFullName で特定します。 |
| Custom | カスタムの特定手法です。 |

それぞれの種類ごとに生成されるコードを次に記載します。

## WindowDriverへの接続

WindowDriverを接続の対象とする関数には`WindowDriverIdentifyAttribute`属性を付与します。

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

キャプチャ時にTryが先に呼び出されます。
このTryメソッドは通常はTestAssistantProからしか利用されません。
そこで渡されたWindowControlが目的のWindowである場合は true を返すように実装します。
Tは識別子を表す任意の型に書き換えてください。
Tryで作成した識別子を使ってAttachメソッドが実行されます。
次の Variable Window Text がCustomの実装例となりますので、そちらを参考にしてみてください。
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

これは Custom の実装の一つです。WindowTextを元に識別しています。
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

UserControlDriverを接続の対象とする関数には`UserControlDriverIdentifyAttribute`属性を付与します。

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

キャプチャ時にTryが先に呼び出されます。
Tは識別子を表す任意の型に書き換えてください。
見つかった分だけ識別子を返します。
Tryで作成した識別子を使ってAttachメソッドが実行されます。

```cs
public static class XUserControlDriverExtensions
{
    [UserControlDriverIdentify(CustomMethod = "TryGet")]
    public static XUserControlDriver AttachXUserControl(this ParentDriver parent, T identifier)
    {
    }

    public static void TryGet(this ParentDriver parent, out T[] identifier)
    {
    }
}
```

Customの実装例です。<br>
TODO
```cs
public static class OrderDocumentUserControlDriverExtensions
{
    [UserControlDriverIdentify(CustomMethod = "TryGet")]
    public static OrderDocumentUserControlDriver AttachOrderDocumentUserControl(this WindowsAppFriend app, string identifier)
        => app.GetTopLevelWindows().
                Select(e => e.VisualTree().ByType("WpfDockApp.OrderDocumentUserControl").SingleOrDefault()).
                Where(e => !e.IsNull).
                Where(e => (string)e.Dynamic().Title == identifier).
                FirstOrDefault()?.Dynamic();

    public static void TryGet(this WindowsAppFriend app, out string[] identifier)
        => identifier = app.GetTopLevelWindows().
            Select(e => e.VisualTree().ByType("WpfDockApp.OrderDocumentUserControl").SingleOrDefault()).
            Where(e => !e.IsNull).
            Select(e => (string)e.Dynamic().Title).
            ToArray();
}
```

### アプリケーション全体からの検索

特定の WindowDriver/UserControlDriver から検索する以外にアプリケーション全体から探す方法もあります。
WindowsAppFriendの拡張にすると以下のようにアプリケーション全体から検索できます。

```cs
public static class XUserControlDriverExtensions
{
    [UserControlDriverIdentify()]
    public static XUserControlDriver AttachOutputForm(this WindowsAppFriend app)
        => app.GetTopLevelWindows().SelectMany(e => e.GetFromTypeFullName("WinFormsApp.XUserControlDriver")).FirstOrDefault()?.Dynamic();
}
```
