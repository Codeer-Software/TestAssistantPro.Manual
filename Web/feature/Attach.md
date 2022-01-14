# PageObjectへのアタッチ

アタッチとはプログラムコードからアプリケーションを動かす際に、操作する対象の PageObject と接続する処理のことを言います。
実際にはプログラムコードのメソッドとして実現されます。
TestAssistantPro はキャプチャ時に `PageObjectIdentify` 属性が付与されたこのメソッドを使って PageObject を検索します。

次の2種類のどちらかの値で PageObject を特定します。

- 画面タイトル
- URL

上記のどちらかの値を、次のどれかの条件で一致させます。

- 完全一致
- 部分一致
- 前方一致
- 後方一致

アタッチのためのコードの例を次に記載します。

```cs
public static class MovieCreatePageExtensions
{
    [PageObjectIdentify("/Movies/Create", UrlComapreType.EndsWith)]
    public static MovieCreatePage AttachMovieCreatePage(this IWebDriver driver) 
        => new MovieCreatePage(driver);
}
```