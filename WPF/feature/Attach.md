# Attach方法ごとのコード

Attachとはプログラムコードからアプリケーションを動かす際に。操作する対象の要素(WindowDriver/UserControlDriver)と接続する処理のことをさします。
実際にはプログラムコードのメソッドとして実現されます。

出力されるコードとしてはWindowDriverを取得する拡張メソッドは無限待ちで実装されます。
これはテスト実行時のトップレベルウィドウの待ち合わせを考えてのものです。
UserControlDriverを取得する方はなければnullを返すというコードが生成されます。

AttachにはWinndowDriver/UserControlDriverごとの次の2種類があります。

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
そこで対象が見つかって検索に必要な識別子を作成できたら true を返すように実装します。

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
見つかった分だけ識別子を返します。

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
