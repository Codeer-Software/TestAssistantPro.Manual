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