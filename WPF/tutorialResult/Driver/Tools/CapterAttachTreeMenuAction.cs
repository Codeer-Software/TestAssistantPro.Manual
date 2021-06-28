using Codeer.Friendly.Windows;
using Codeer.TestAssistant.GeneratorToolKit;
using RM.Friendly.WPFStandardControls;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Driver.Tools
{
    public class CapterAttachTreeMenuAction : ICaptureAttachTreeMenuAction
    {
        public Dictionary<string, MenuAction> GetAction(string accessPath, object driver)
        {
            var dic = new Dictionary<string, MenuAction>();

            if (driver is WPFComboBox comboBox) dic["Assert"] = () => Assert(accessPath, comboBox);
            else if (driver is WPFListBox listBox) dic["Assert"] = () => Assert(accessPath, listBox);
            else if (driver is WPFListView listView) dic["Assert"] = () => Assert(accessPath, listView);
            else if (driver is WPFProgressBar progressBar) dic["Assert"] = () => Assert(accessPath, progressBar);
            else if (driver is WPFRichTextBox richTextBox) dic["Assert"] = () => Assert(accessPath, richTextBox);
            else if (driver is WPFSelector selector) dic["Assert"] = () => Assert(accessPath, selector);
            else if (driver is WPFSlider slider) dic["Assert"] = () => Assert(accessPath, slider);
            else if (driver is WPFTabControl tabControl) dic["Assert"] = () => Assert(accessPath, tabControl);
            else if (driver is WPFTextBox textBox) dic["Assert"] = () => Assert(accessPath, textBox);
            else if (driver is WPFTextBlock textBlock) dic["Assert"] = () => Assert(accessPath, textBlock);
            else if (driver is WPFToggleButton toggleButton) dic["Assert"] = () => Assert(accessPath, toggleButton);
            else if (driver is WPFTreeView treeView) dic["Assert"] = () => Assert(accessPath, treeView);
            else if (driver is WPFCalendar calendar) dic["Assert"] = () => Assert(accessPath, calendar);
            else if (driver is WPFDatePicker datePicker) dic["Assert"] = () => Assert(accessPath, datePicker);
            else if (driver is WPFDataGrid dataGrid) dic["Assert"] = () => Assert(accessPath, dataGrid);
            else if (!(driver is WindowsAppFriend)) dic["Assert"] = () => AssertAll(accessPath, driver);

            return dic;
        }

        void AssertAll(string accessPath, object driver)
        {
            foreach (var e in driver.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (e.GetIndexParameters().Length != 0) continue;
                var obj = e.GetValue(driver);
                if (obj == null) continue;

                var childAccessPath = accessPath + "." + e.Name;

                if (obj is WPFComboBox comboBox) Assert(childAccessPath, comboBox);
                else if (obj is WPFListBox listBox) Assert(childAccessPath, listBox);
                else if (obj is WPFListView listView) Assert(childAccessPath, listView);
                else if (obj is WPFProgressBar progressBar) Assert(childAccessPath, progressBar);
                else if (obj is WPFRichTextBox richTextBox) Assert(childAccessPath, richTextBox);
                else if (obj is WPFSelector selector) Assert(childAccessPath, selector);
                else if (obj is WPFSlider slider) Assert(childAccessPath, slider);
                else if (obj is WPFTabControl tabControl) Assert(childAccessPath, tabControl);
                else if (obj is WPFTextBox textBox) Assert(childAccessPath, textBox);
                else if (obj is WPFTextBlock textBlock) Assert(childAccessPath, textBlock);
                else if (obj is WPFToggleButton toggleButton) Assert(childAccessPath, toggleButton);
                else if (obj is WPFTreeView treeView) Assert(childAccessPath, treeView);
                else if (obj is WPFCalendar calendar) Assert(childAccessPath, calendar);
                else if (obj is WPFDatePicker datePicker) Assert(childAccessPath, datePicker);
                else if (obj is WPFDataGrid dataGrid) Assert(childAccessPath, dataGrid);
            }
        }

        void Assert(string accessPath, WPFComboBox comboBox)
            => CaptureAdaptor.AddCode($"{accessPath}.SelectedIndex.Is({comboBox.SelectedIndex});");

        void Assert(string accessPath, WPFListBox listBox)
            => CaptureAdaptor.AddCode($"{accessPath}.SelectedIndex.Is({listBox.SelectedIndex});");

        void Assert(string accessPath, WPFListView listView)
            => CaptureAdaptor.AddCode($"{accessPath}.SelectedIndex.Is({listView.SelectedIndex});");

        void Assert(string accessPath, WPFProgressBar progressBar)
            => CaptureAdaptor.AddCode($"{accessPath}.Value.Is({progressBar.Value});");

        void Assert(string accessPath, WPFRichTextBox richTextBox)
            => CaptureAdaptor.AddCode($"{accessPath}.Text.Is({ToLiteral(richTextBox.Text)});");

        void Assert(string accessPath, WPFSelector selector)
            => CaptureAdaptor.AddCode($"{accessPath}.SelectedIndex.Is({selector.SelectedIndex});");

        void Assert(string accessPath, WPFSlider slider)
            => CaptureAdaptor.AddCode($"{accessPath}.Value.Is({slider.Value});");

        void Assert(string accessPath, WPFTabControl tabControl)
            => CaptureAdaptor.AddCode($"{accessPath}.SelectedIndex.Is({tabControl.SelectedIndex});");

        void Assert(string accessPath, WPFTextBox textBox)
            => CaptureAdaptor.AddCode($"{accessPath}.Text.Is({ToLiteral(textBox.Text)});");

        void Assert(string accessPath, WPFTextBlock textBlock)
            => CaptureAdaptor.AddCode($"{accessPath}.Text.Is({ToLiteral(textBlock.Text)});");

        void Assert(string accessPath, WPFToggleButton toggleButton)
        {
            var value = toggleButton.IsChecked == null ? "null" : toggleButton.IsChecked.Value.ToString().ToLower();
            CaptureAdaptor.AddCode($"{accessPath}.IsChecked.Is({value});");
        }

        void Assert(string accessPath, WPFTreeView treeView)
        {
            if (treeView.SelectedItem.AppVar.IsNull)
            {
                CaptureAdaptor.AddCode($"{accessPath}.SelectedItem.AppVar.IsNull.IsTrue();");
            }
            else
            {
                CaptureAdaptor.AddCode($"{accessPath}.SelectedItem.Text.Is({ToLiteral(treeView.SelectedItem.Text)});");
            }
        }

        void Assert(string accessPath, WPFCalendar calendar)
        {
            CaptureAdaptor.AddUsing(typeof(DateTime).Namespace);
            if (calendar.SelectedDate.HasValue)
            {
                var value = calendar.SelectedDate.Value;
                CaptureAdaptor.AddCode($"{accessPath}.SelectedDate.Is(new DateTime({value.Year}, {value.Month}, {value.Day}));");
            }
            else
            {
                CaptureAdaptor.AddCode($"{accessPath}.SelectedDate.IsNull();");
            }
        }

        void Assert(string accessPath, WPFDatePicker datePicker)
        {
            CaptureAdaptor.AddUsing(typeof(DateTime).Namespace);
            if (datePicker.SelectedDate.HasValue)
            {
                var value = datePicker.SelectedDate.Value;
                CaptureAdaptor.AddCode($"{accessPath}.SelectedDate.Is(new DateTime({value.Year}, {value.Month}, {value.Day}));");
            }
            else
            {
                CaptureAdaptor.AddCode($"{accessPath}.SelectedDate.IsNull();");
            }
        }

        void Assert(string accessPath, WPFDataGrid dataGrid)
        {
            var rowCount = dataGrid.ItemCount;
            var colCount = dataGrid.ColCount;
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    var text = ToLiteral(dataGrid.GetCellText(row, col));
                    CaptureAdaptor.AddCode($"{accessPath}.GetCellText({row}, {col}).Is({text});");
                }
            }
        }

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
