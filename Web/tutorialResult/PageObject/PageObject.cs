using OpenQA.Selenium;
using Selenium.StandardControls;
using Selenium.StandardControls.PageObjectUtility;
using Selenium.StandardControls.TestAssistant.GeneratorToolKit;

namespace PageObject
{
    public class TopObject : PageBase
    {
        public ButtonDriver to_demo => ById("to-demo").Wait();
        public AnchorDriver to_home => ById("to-home").Wait();
        public AnchorDriver to_movies => ById("to-movies").Wait();
        public AnchorDriver to_controls => ById("to-controls").Wait();

        public TopObject(IWebDriver driver) : base(driver) { }
    }

    public static class TopObjectExtensions
    {
        [PageObjectIdentify(UrlComapreType.EndsWith, "/")]
        public static TopObject AttachTopObject(this IWebDriver driver) => new TopObject(driver);
    }
}