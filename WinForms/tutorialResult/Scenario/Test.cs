using Codeer.Friendly.Windows;
using Driver.TestController;
using NUnit.Framework;
using System.Diagnostics;
using System;
using Driver.Windows;
using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows.KeyMouse;

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
            var treeForm = _app.AttachTreeForm();
            treeForm._treeView.FindItem("Order management", "Accepted").EmulateSelect();
            treeForm._contextMenu.FindItem("Open").EmulateClick();
        }

        void Search()
        {
            var outputForm = _app.AttachOutputForm();
            var orderDocumentForm = _app.AttachOrderDocumentForm(@"Accepted");
            orderDocumentForm._searchTextBox.EmulateChangeText("300");
            orderDocumentForm._searchButton.EmulateClick();
            outputForm._textBoxResult.Text.Is("Accepted(1,3) : 300\r\nAccepted(2,3) : 300");
        }
    }
}
