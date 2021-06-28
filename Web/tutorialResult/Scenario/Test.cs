using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObject;

namespace Scenario
{
    public class TAPTest
    {
        IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            // 次のコードを追加
            _driver.Url = "http://testassistantpro-demo.azurewebsites.net/Movies";
        }

        [TearDown]
        public void TearDown() => _driver.Dispose();

        [TestCase]
        public void TestScenario()
        {
            var moviesPage = _driver.AttachMoviesPage();
            moviesPage.to_create.Click();
            var movieCreatePage = _driver.AttachMovieCreatePage();
            movieCreatePage.movie_title.Edit("映画のタイトル");
            movieCreatePage.movie_releasedate.Edit(2020, 01, 01);
            movieCreatePage.movie_genre.Edit("アクション");
            movieCreatePage.movie_price.Edit("3000");
            movieCreatePage.to_add.Click();
            var moviesPage1 = _driver.AttachMoviesPage();
        }

        [TestCase]
        public void TestAll()
        {

        }
    }
}
