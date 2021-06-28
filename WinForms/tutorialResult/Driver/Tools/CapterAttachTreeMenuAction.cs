using Codeer.Friendly.Windows;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Driver.Tools
{
    public class CapterAttachTreeMenuAction : ICaptureAttachTreeMenuAction
    {
        public Dictionary<string, MenuAction> GetAction(string accessPath, object driver)
        {
            var dic = new Dictionary<string, MenuAction>();

            if (driver is FormsCheckBox checkBox) dic["Assert"] = () => Assert(accessPath, checkBox);
            else if (driver is FormsCheckedListBox checkedListBox) dic["Assert"] = () => Assert(accessPath, checkedListBox);
            else if (driver is FormsComboBox comboBox) dic["Assert"] = () => Assert(accessPath, comboBox);
            else if (driver is FormsDataGridView dataGridView) dic["Assert"] = () => Assert(accessPath, dataGridView);
            else if (driver is FormsDateTimePicker dateTimePicker) dic["Assert"] = () => Assert(accessPath, dateTimePicker);
            else if (driver is FormsListBox listBox) dic["Assert"] = () => Assert(accessPath, listBox);
            else if (driver is FormsListView listView) dic["Assert"] = () => Assert(accessPath, listView);
            else if (driver is FormsMaskedTextBox maskedTextBox) dic["Assert"] = () => Assert(accessPath, maskedTextBox);
            else if (driver is FormsMonthCalendar monthCalendar) dic["Assert"] = () => Assert(accessPath, monthCalendar);
            else if (driver is FormsNumericUpDown numericUpDown) dic["Assert"] = () => Assert(accessPath, numericUpDown);
            else if (driver is FormsProgressBar progressBar) dic["Assert"] = () => Assert(accessPath, progressBar);
            else if (driver is FormsRadioButton radioButton) dic["Assert"] = () => Assert(accessPath, radioButton);
            else if (driver is FormsRichTextBox richTextBox) dic["Assert"] = () => Assert(accessPath, richTextBox);
            else if (driver is FormsTabControl tabControl) dic["Assert"] = () => Assert(accessPath, tabControl);
            else if (driver is FormsTextBox textBox) dic["Assert"] = () => Assert(accessPath, textBox);
            else if (driver is FormsToolStripComboBox toolStripComboBox) dic["Assert"] = () => Assert(accessPath, toolStripComboBox);
            else if (driver is FormsToolStripTextBox toolStripTextBox) dic["Assert"] = () => Assert(accessPath, toolStripTextBox);
            else if (driver is FormsTrackBar trackBar) dic["Assert"] = () => Assert(accessPath, trackBar);
            else if (driver is FormsTreeView treeView) dic["Assert"] = () => Assert(accessPath, treeView);
            else if (!(driver is WindowsAppFriend)) dic["Assert"] = () => AssertAll(accessPath, driver);

            return dic;
        }

        static void AssertAll(string accessPath, object driver)
        {
            foreach (var e in driver.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (e.GetIndexParameters().Length != 0) continue;
                var obj = e.GetValue(driver);
                if (obj == null) continue;

                var childAccessPath = accessPath + "." + e.Name;
                if (obj is FormsCheckBox checkBox) Assert(childAccessPath, checkBox);
                else if (obj is FormsCheckedListBox checkedListBox) Assert(childAccessPath, checkedListBox);
                else if (obj is FormsComboBox comboBox) Assert(childAccessPath, comboBox);
                else if (obj is FormsDataGridView dataGridView) Assert(childAccessPath, dataGridView);
                else if (obj is FormsDateTimePicker dateTimePicker) Assert(childAccessPath, dateTimePicker);
                else if (obj is FormsListBox listBox) Assert(childAccessPath, listBox);
                else if (obj is FormsListView listView) Assert(childAccessPath, listView);
                else if (obj is FormsMaskedTextBox maskedTextBox) Assert(childAccessPath, maskedTextBox);
                else if (obj is FormsMonthCalendar monthCalendar) Assert(childAccessPath, monthCalendar);
                else if (obj is FormsNumericUpDown numericUpDown) Assert(childAccessPath, numericUpDown);
                else if (obj is FormsProgressBar progressBar) Assert(childAccessPath, progressBar);
                else if (obj is FormsRadioButton radioButton) Assert(childAccessPath, radioButton);
                else if (obj is FormsRichTextBox richTextBox) Assert(childAccessPath, richTextBox);
                else if (obj is FormsTabControl tabControl) Assert(childAccessPath, tabControl);
                else if (obj is FormsTextBox textBox) Assert(childAccessPath, textBox);
                else if (obj is FormsToolStripComboBox toolStripComboBox) Assert(childAccessPath, toolStripComboBox);
                else if (obj is FormsToolStripTextBox toolStripTextBox) Assert(childAccessPath, toolStripTextBox);
                else if (obj is FormsTrackBar trackBar) Assert(childAccessPath, trackBar);
                else if (obj is FormsTreeView treeView) Assert(childAccessPath, treeView);
            }
        }

        static void Assert(string accessPath, FormsCheckBox checkBox)
        {
            CaptureAdaptor.AddUsing(typeof(CheckState).Namespace);
            CaptureAdaptor.AddCode($"{accessPath}.CheckState.Is(CheckState.{checkBox.CheckState});");
        }

        static void Assert(string accessPath, FormsCheckedListBox checkedListBox)
        {
            var count = checkedListBox.ItemCount;
            for (int i = 0; i < count; i++)
            {
                var checkState = checkedListBox.GetCheckState(i);
                CaptureAdaptor.AddCode($"{accessPath}.GetCheckState({i}).Is(CheckState.{checkState});");
            }
        }

        static void Assert(string accessPath, FormsComboBox comboBox)
            => CaptureAdaptor.AddCode($"{accessPath}.SelectedItemIndex.Is({comboBox.SelectedItemIndex});");

        static void Assert(string accessPath, FormsDataGridView dataGridView)
        {
            var rowCount = dataGridView.RowCount;
            var colCount = dataGridView.ColumnCount;
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    var text = ToLiteral(dataGridView.GetCell(col, row).Text);
                    CaptureAdaptor.AddCode($"{accessPath}.GetCell({col}, {row}).Text.Is({text});");
                }
            }
        }

        static void Assert(string accessPath, FormsDateTimePicker dateTimePicker)
        {
            CaptureAdaptor.AddUsing(typeof(DateTime).Namespace);
            var value = dateTimePicker.SelectedDay;
            CaptureAdaptor.AddCode($"{accessPath}.SelectedDay.Date.Is(new DateTime({value.Year}, {value.Month}, {value.Day}));");
        }

        static void Assert(string accessPath, FormsListBox listBox)
        {
            var texts = listBox.GetAllItemText();
            for (int i = 0; i < texts.Length; i++)
            {
                CaptureAdaptor.AddCode($"{accessPath}.GetItemText({i}).Is({ToLiteral(listBox.GetItemText(i))});");
            }
        }

        static void Assert(string accessPath, FormsListView listView)
        {
            var rowCount = listView.ItemCount;
            var colCount = listView.ColumnCount;
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    var text = ToLiteral(listView.GetListViewItem(row).GetSubItem(col).Text);
                    CaptureAdaptor.AddCode($"{accessPath}.GetListViewItem({row}).GetSubItem({col}).Text.Is({text});");
                }
            }
        }

        static void Assert(string accessPath, FormsMaskedTextBox maskedTextBox)
            => CaptureAdaptor.AddCode($"{accessPath}.Text.Is({ToLiteral(maskedTextBox.Text)});");

        static void Assert(string accessPath, FormsMonthCalendar monthCalendar)
        {
            CaptureAdaptor.AddUsing(typeof(DateTime).Namespace);
            var value = monthCalendar.SelectedDay;
            CaptureAdaptor.AddCode($"{accessPath}.SelectedDay.Date.Is(new DateTime({value.Year}, {value.Month}, {value.Day}));");
        }

        static void Assert(string accessPath, FormsNumericUpDown numericUpDown)
            => CaptureAdaptor.AddCode($"{accessPath}.Value.Is({numericUpDown.Value});");

        static void Assert(string accessPath, FormsProgressBar progressBar)
            => CaptureAdaptor.AddCode($"{accessPath}.Pos.Is({progressBar.Pos});");

        static void Assert(string accessPath, FormsRadioButton radioButton)
            => CaptureAdaptor.AddCode($"{accessPath}.Checked.Is({radioButton.Checked.ToString().ToLower()});");

        static void Assert(string accessPath, FormsRichTextBox richTextBox)
            => CaptureAdaptor.AddCode($"{accessPath}.Text.Is({ToLiteral(richTextBox.Text)});");

        static void Assert(string accessPath, FormsTabControl tabControl)
            => CaptureAdaptor.AddCode($"{accessPath}.SelectedIndex.Is({tabControl.SelectedIndex});");

        static void Assert(string accessPath, FormsTextBox textBox)
            => CaptureAdaptor.AddCode($"{accessPath}.Text.Is({ToLiteral(textBox.Text)});");

        static void Assert(string accessPath, FormsToolStripComboBox toolStripComboBox)
            => CaptureAdaptor.AddCode($"{accessPath}.ComboBox.SelectedItemIndex.Is({toolStripComboBox.ComboBox.SelectedItemIndex});");

        static void Assert(string accessPath, FormsToolStripTextBox toolStripTextBox)
            => CaptureAdaptor.AddCode($"{accessPath}.Text.Is({ToLiteral(toolStripTextBox.Text)});");

        static void Assert(string accessPath, FormsTrackBar trackBar)
            => CaptureAdaptor.AddCode($"{accessPath}.Value.Is({trackBar.Value});");

        static void Assert(string accessPath, FormsTreeView treeView)
        {
            if (treeView.SelectNode.AppVar.IsNull)
            {
                CaptureAdaptor.AddCode($"{accessPath}.SelectNode.AppVar.IsNull.IsTrue();");
            }
            else
            {
                CaptureAdaptor.AddCode($"{accessPath}.SelectNode.Text.Is({ToLiteral(treeView.SelectNode.Text)});");
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
