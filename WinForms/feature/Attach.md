# Attach方法ごとのコード

Attachとはプログラムコードからアプリケーションを動かす際に。操作する対象の要素(WindowDriver/UserControlDriver)と接続する処理のことをさします。
実際にはプログラムコードのメソッドとして実現されます。

出力されるコードとしてはWindowDriverを取得する拡張メソッドは無限待ちで実装されます。
これはテスト実行時のトップレベルウィドウの待ち合わせを考えてのものです。
UserControlDriverを取得する方はなければnullを返すというコードが生成されます。

AttachにはWinndowDriver/UserControlDriverごとの次の4種類があります。

| 種類 | 説明 |
|-----|-----|
| Type Full Name | .Net の TypeFullName で特定します。 |
| Window Text | Win32 の WindowText で特定します。 |
| Variable Window Text | WindowText から特定しますが常に同じ WindowText でない場合に使います。 |
| Custom | カスタムの特定手法です。 |

それぞれの種類ごとに生成されるコードを次に記載します。

## WindowDriverへの接続

WindowDriverを接続の対象とする関数には`WindowDriverIdentifyAttribute`属性を付与します。

### TypeFullName

```cs
public static class MainFormDriverExtensions
{
    [WindowDriverIdentify(TypeFullName = "WinFormsApp.MainForm")]
    public static MainFormDriver AttachMainForm(this WindowsAppFriend app)
        => app.WaitForIdentifyFromTypeFullName("WinFormsApp.MainForm").Dynamic();
}
```
### WinodwText

```cs
    
public static class MainFormDriverExtensions
{
    [WindowDriverIdentify(WindowText = "Text ...")]
    public static MainFormDriver AttachMainForm(this WindowsAppFriend app)
        => app.WaitForIdentifyFromWindowText("Text ...").Dynamic();
}
```
### Custom

キャプチャ時にTryが先に呼び出されます。
そこで対象が見つかって検索に必要な識別子を作成できたら true を返すように実装します。

```cs
public static class MainFormDriverExtensions
{
    [WindowDriverIdentify(CustomMethod = "Try")]
    public static MainFormDriver AttachMainForm(this WindowsAppFriend app, T identifier)
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
public static class MainFormDriverExtensions
{
    [WindowDriverIdentify(CustomMethod = "Try")]
    public static MainFormDriver AttachMainForm(this WindowsAppFriend app, string identifier)
        => app.WaitForIdentifyFromWindowText(identifier).Dynamic();

    public static bool Try(WindowControl window, out string identifier)
    {
        identifier = window.GetWindowText();
        return window.TypeFullName == "WinFormsApp.MainForm";
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

### WinodwText

```cs
public static class XUserControlDriverExtensions
{
    [UserControlDriverIdentify]
    public static XUserControlDriver AttachXUserControl(this ParentDriver parent)
        => parent.Core.GetFromWindowText("Text...").FirstOrDefault()?.Dynamic();
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

### Variable Window Text

これは Custom の実装の一つです。WindowTextを元に識別しています。

```cs
public static class XUserControlDriverExtensions
{
    [UserControlDriverIdentify(CustomMethod = "TryGet")]
    public static XUserControlDriver AttachXUserControl(this ParentDriver parent, string text)
        => parent.Core.IdentifyFromWindowText("").Dynamic();

    public static void TryGet(this ParentDriver parent, out string[] texts)
        => texts = parent.Core.GetFromTypeFullName("WinFormsApp.XUserControlDriver").Select(e => (string)e.Dynamic().Text).ToArray();
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
