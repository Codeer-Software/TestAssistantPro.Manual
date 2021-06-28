using OpenQA.Selenium;
using Selenium.StandardControls;
using Selenium.StandardControls.PageObjectUtility;
using Selenium.StandardControls.TestAssistant.GeneratorToolKit;

namespace PageObject
{
    public class MovieCreatePage : PageBase
    {
        public TextBoxDriver movie_title => ById("movie-title").Wait();
        public TextBoxDriver movie_genre => ById("movie-genre").Wait();
        public TextBoxDriver movie_price => ById("movie-price").Wait();
        public ButtonDriver to_add => ById("to-add").Wait();
        public AnchorDriver to_index => ById("to-index").Wait();
        public DateDriver movie_releasedate => ById("movie-releasedate").Wait();
        public IWebElement h4 => ByCssSelector("main[role='main']").ByTagName("h4").Wait().Find();

        public MovieCreatePage(IWebDriver driver) : base(driver) { }
    }

    public static class MovieCreatePageExtensions
    {
        [PageObjectIdentify(TitleComapreType.Equals, "Create - Demo")]
        public static MovieCreatePage AttachMovieCreatePage(this IWebDriver driver)
        {
            driver.WaitForTitle(TitleComapreType.Equals, "Create - Demo");
            return new MovieCreatePage(driver);
        }
    }
}