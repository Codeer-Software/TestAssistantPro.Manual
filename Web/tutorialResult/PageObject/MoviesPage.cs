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
        [PageObjectIdentify(UrlComapreType.EndsWith, "/Movies")]
        public static MoviesPage AttachMoviesPage(this IWebDriver driver)
        {
            driver.WaitForUrl(UrlComapreType.EndsWith, "/Movies");
            return new MoviesPage(driver);
        }
    }
}