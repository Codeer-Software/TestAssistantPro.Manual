using Codeer.Friendly.Windows;
using Driver.TestController;
using NUnit.Framework;
using Driver.Windows;

namespace Scenario
{
    [TestFixture]
    public class Test
    {
        WindowsAppFriend _app;

        [SetUp]
        public void TestInitialize() => _app = ProcessController.Start();

        [TearDown]
        public void TestCleanup() => _app.Kill();

        [Test]
        public void TestMethod1()
        {
            OpenDocument();
            Search();
        }

        void OpenDocument()
        {
            var treeUserControl = _app.AttachTreeUserControl();
            treeUserControl._treeView.GetItem("Oder management", "Accepted").EmulateChangeSelected(true);
            treeUserControl._treeViewContextMenu.GetItem("Open").EmulateClick();
        }

        void Search()
        {
            var outputUserControl = _app.AttachOutputUserControl();
            var orderDocumentUserControl = _app.AttachOrderDocumentUserControl(@"Accepted");
            outputUserControl._buttonClear.EmulateClick();
            orderDocumentUserControl._searchText.EmulateChangeText("300");
            orderDocumentUserControl._searchButton.EmulateClick();
            outputUserControl._textBox.Text.Is("OrderDocument (1,3) : 300\nOrderDocument (2,3) : 300\n");
        }
    }
}
