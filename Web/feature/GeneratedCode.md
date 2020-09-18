# PageObject/ComponentObjectのコード

PageObjectとComponentObjectの役割は画面および要素を特定して取得することです。 そのためにAttachを行うメソッドも作られます。 Attachを行うメソッドについては[PageObjectへのアタッチ](Attach.md)を参照してください。 ComponentObjectの場合は親のPageObjectの子要素としてPropertyで取得する方法もあります。

## PageObjectのコード例

```cs
using OpenQA.Selenium;
using Selenium.StandardControls;
using Selenium.StandardControls.PageObjectUtility;
using Selenium.StandardControls.TestAssistant.GeneratorToolKit;
using PageObject;

namespace PageObject
{
    public class MoviesPage : PageBase
    {
        public AnchorDriver to_home => ById("to-home").Wait();
        public AnchorDriver to_movies => ById("to-movies").Wait();
        public AnchorDriver to_controls => ById("to-controls").Wait();
        public AnchorDriver to_create => ById("to-create").Wait();
        public ItemsControlDriver<MovieItem> tbody => ByTagName("tbody").Wait();

        public MoviesPage(IWebDriver driver) : base(driver) { }
    }

    public static class MoviesPageExtensions
    {
        [PageObjectIdentify("/Movies", UrlComapreType.EndsWith)]
        public static MoviesPage AttachMoviesPage(this IWebDriver driver) => new MoviesPage(driver);
    }
}
```

## ComponentObjectのコード例

```cs
using OpenQA.Selenium;
using Selenium.StandardControls;
using Selenium.StandardControls.PageObjectUtility;
using Selenium.StandardControls.TestAssistant.GeneratorToolKit;

namespace PageObject
{
    public class MovieItem : ComponentBase
    {
        public IWebElement movie_title => ByName("movie-title").Wait().Find();
        public IWebElement movie_releasedate => ByName("movie-releasedate").Wait().Find();
        public IWebElement movie_genre => ByName("movie-genre").Wait().Find();
        public IWebElement movie_price => ByName("movie-price").Wait().Find();
        public AnchorDriver movie_to_edit => ByName("movie-to-edit").Wait();
        public AnchorDriver movie_to_details => ByName("movie-to-details").Wait();
        public AnchorDriver movie_to_delete => ByName("movie-to-delete").Wait();

        public MovieItem(IWebElement element) : base(element) { }
        public static implicit operator MovieItem(ElementFinder finder) => finder.Find<MovieItem>();
    }
}
```