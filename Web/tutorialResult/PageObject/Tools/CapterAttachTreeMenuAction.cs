using OpenQA.Selenium;
using Selenium.StandardControls;
using Selenium.StandardControls.PageObjectUtility;
using Selenium.StandardControls.TestAssistant.GeneratorToolKit;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PageObject.Tools
{
    public class CapterAttachTreeMenuAction : ICaptureAttachTreeMenuAction
    {
        public Dictionary<string, Action> GetAction(string accessPath, object driver)
        {
            var dic = new Dictionary<string, Action>();

            if (driver is IWebDriver web)
            {
                dic["Url"] = () =>
                {
                    CaptureAdaptor.AddCode(accessPath + ".Url = " + ToLiteral(web.Url) + ";");
                };
                dic["Alert - Accept"] = () =>
                {
                    CaptureAdaptor.AddCode(accessPath + ".WaitForAlert().Accept();");
                    CaptureAdaptor.AddUsing("Selenium.StandardControls");
                };
                dic["Alert - Dismiss"] = () =>
                {
                    CaptureAdaptor.AddCode(accessPath + ".WaitForAlert().Dismiss();");
                    CaptureAdaptor.AddUsing("Selenium.StandardControls");
                };
            }
            else
            {
                if (driver is AnchorDriver anchor) dic["Assert"] = () => Assert(accessPath, anchor);
                else if (driver is DateDriver date) dic["Assert"] = () => Assert(accessPath, date);
                else if (driver is DropDownListDriver dropdown) dic["Assert"] = () => Assert(accessPath, dropdown);
                else if (driver is LabelDriver label) dic["Assert"] = () => Assert(accessPath, label);
                else if (driver is RadioButtonDriver radio) dic["Assert"] = () => Assert(accessPath, radio);
                else if (driver is CheckBoxDriver check) dic["Assert"] = () => Assert(accessPath, check);
                else if (driver is TextAreaDriver textArea) dic["Assert"] = () => Assert(accessPath, textArea);
                else if (driver is TextBoxDriver textBox) dic["Assert"] = () => Assert(accessPath, textBox);
                else if (driver is IWebElement element) dic["Assert"] = () => Assert(accessPath, element);
                else if (IsItemsControl(driver)) dic["Assert"] = () => AssertItemsControl(accessPath, driver);
                else dic["Assert All"] = () => AssertAll(accessPath, driver);
            }
            return dic;
        }

        static void AssertAll(string accessPath, object driver)
        {
            if (driver == null) return;
            if (!typeof(MappingBase).IsAssignableFrom(driver.GetType())) return;

            foreach (var e in driver.GetType().GetProperties().Where(e => e.DeclaringType == driver.GetType()))
            {
                SelectAssert(accessPath + "." + e.Name, e.GetValue(driver));
            }
        }

        static void Assert(string accessPath, AnchorDriver anchor)
            => CaptureAdaptor.AddCode(accessPath + ".Text.Is(" + ToLiteral(anchor.Text) + ");");

        static void Assert(string accessPath, DateDriver date)
            => CaptureAdaptor.AddCode(accessPath + ".Text.Is(" + ToLiteral(date.Text) + ");");

        static void Assert(string accessPath, DropDownListDriver dropdown)
            => CaptureAdaptor.AddCode(accessPath + ".Text.Is(" + ToLiteral(dropdown.Text) + ");");

        static void Assert(string accessPath, LabelDriver label)
            => CaptureAdaptor.AddCode(accessPath + ".Text.Is(" + ToLiteral(label.Text) + ");");

        static void Assert(string accessPath, RadioButtonDriver radio)
            => CaptureAdaptor.AddCode(accessPath + ".Checked.Is(" + radio.Checked.ToString().ToLower() + ");");

        static void Assert(string accessPath, CheckBoxDriver check)
            => CaptureAdaptor.AddCode(accessPath + ".Checked.Is(" + check.Checked.ToString().ToLower() + ");");

        static void Assert(string accessPath, TextBoxDriver textBox)
            => CaptureAdaptor.AddCode(accessPath + ".Text.Is(" + ToLiteral(textBox.Text) + ");");

        static void Assert(string accessPath, IWebElement element)
            => CaptureAdaptor.AddCode(accessPath + ".Text.Is(" + ToLiteral(element.Text) + ");");

        static void AssertItemsControl(string accessPath, object obj)
        {
            dynamic itemsControl = obj;
            int count = itemsControl.Count;
            for (int i = 0; i < count; i++)
            {
                SelectAssert(accessPath + $".GetItem({i})", itemsControl.GetItem(i));
            }
        }

        static void SelectAssert(string accessPath, object obj)
        {
            if (obj == null) return;
            if (obj is IWebDriver) return;

            if (obj is AnchorDriver anchor) Assert(accessPath, anchor);
            else if (obj is DateDriver date) Assert(accessPath, date);
            else if (obj is DropDownListDriver dropdown) Assert(accessPath, dropdown);
            else if (obj is LabelDriver label) Assert(accessPath, label);
            else if (obj is RadioButtonDriver radio) Assert(accessPath, radio);
            else if (obj is CheckBoxDriver check) Assert(accessPath, check);
            else if (obj is TextAreaDriver textArea) Assert(accessPath, textArea);
            else if (obj is TextBoxDriver textBox) Assert(accessPath, textBox);
            else if (obj is IWebElement element) Assert(accessPath, element);
            else if (IsItemsControl(obj)) AssertItemsControl(accessPath, obj);
            else AssertAll(accessPath, obj);
        }

        static bool IsItemsControl(object obj)
            => obj != null && obj.GetType().IsGenericType && obj.GetType().GetGenericTypeDefinition() == typeof(ItemsControlDriver<>);

        static string ToLiteral(string text)
        {
            using (var writer = new StringWriter())
            using (var provider = CodeDomProvider.CreateProvider("CSharp"))
            {
                var expression = new CodePrimitiveExpression(text);
                provider.GenerateCodeFromExpression(expression, writer, options: null);
                return writer.ToString();
            }
        }
    }
}