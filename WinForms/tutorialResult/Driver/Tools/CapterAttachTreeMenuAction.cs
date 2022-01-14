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
    public static class CapterAttachTreeMenuAction
    {
        [MenuAction]
        public static void Assert(FormsCheckBox checkBox, string accessPath)
        {
            CaptureAdaptor.AddUsing(typeof(CheckState).Namespace);
            CaptureAdaptor.AddCode($"{accessPath}.CheckState.Is(CheckState.{checkBox.CheckState});");
        }

        [MenuAction]
        public static void Assert(FormsCheckedListBox checkedListBox, string accessPath)
        {
            var count = checkedListBox.ItemCount;
            for (int i = 0; i < count; i++)
            {
                var checkState = checkedListBox.GetCheckState(i);
                CaptureAdaptor.AddCode($"{accessPath}.GetCheckState({i}).Is(CheckState.{checkState});");
            }
        }

        [MenuAction]
        public static void Assert(FormsComboBox comboBox, string accessPath)
            => CaptureAdaptor.AddCode($"{accessPath}.SelectedItemIndex.Is({comboBox.SelectedItemIndex});");

        [MenuAction]
        public static void Assert(FormsDataGridView dataGridView, string accessPath)
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

        [MenuAction]
        public static void Assert(FormsDateTimePicker dateTimePicker, string accessPath)
        {
            CaptureAdaptor.AddUsing(typeof(DateTime).Namespace);
            var value = dateTimePicker.SelectedDay;
            CaptureAdaptor.AddCode($"{accessPath}.SelectedDay.Date.Is(new DateTime({value.Year}, {value.Month}, {value.Day}));");
        }

        [MenuAction]
        public static void Assert(FormsListBox listBox, string accessPath)
        {
            var texts = listBox.GetAllItemText();
            for (int i = 0; i < texts.Length; i++)
            {
                CaptureAdaptor.AddCode($"{accessPath}.GetItemText({i}).Is({ToLiteral(listBox.GetItemText(i))});");
            }
        }

        [MenuAction]
        public static void Assert(FormsListView listView, string accessPath)
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

        [MenuAction]
        public static void Assert(FormsMaskedTextBox maskedTextBox, string accessPath)
            => CaptureAdaptor.AddCode($"{accessPath}.Text.Is({ToLiteral(maskedTextBox.Text)});");

        [MenuAction]
        public static void Assert(FormsMonthCalendar monthCalendar, string accessPath)
        {
            CaptureAdaptor.AddUsing(typeof(DateTime).Namespace);
            var value = monthCalendar.SelectedDay;
            CaptureAdaptor.AddCode($"{accessPath}.SelectedDay.Date.Is(new DateTime({value.Year}, {value.Month}, {value.Day}));");
        }

        [MenuAction]
        public static void Assert(FormsNumericUpDown numericUpDown, string accessPath)
            => CaptureAdaptor.AddCode($"{accessPath}.Value.Is({numericUpDown.Value});");

        [MenuAction]
        public static void Assert(FormsProgressBar progressBar, string accessPath)
            => CaptureAdaptor.AddCode($"{accessPath}.Pos.Is({progressBar.Pos});");

        [MenuAction]
        public static void Assert(FormsRadioButton radioButton, string accessPath)
            => CaptureAdaptor.AddCode($"{accessPath}.Checked.Is({radioButton.Checked.ToString().ToLower()});");

        [MenuAction]
        public static void Assert(FormsRichTextBox richTextBox, string accessPath)
            => CaptureAdaptor.AddCode($"{accessPath}.Text.Is({ToLiteral(richTextBox.Text)});");

        [MenuAction]
        public static void Assert(FormsTabControl tabControl, string accessPath)
            => CaptureAdaptor.AddCode($"{accessPath}.SelectedIndex.Is({tabControl.SelectedIndex});");

        [MenuAction]
        public static void Assert(FormsTextBox textBox, string accessPath)
            => CaptureAdaptor.AddCode($"{accessPath}.Text.Is({ToLiteral(textBox.Text)});");

        [MenuAction]
        public static void Assert(FormsToolStripComboBox toolStripComboBox, string accessPath)
            => CaptureAdaptor.AddCode($"{accessPath}.ComboBox.SelectedItemIndex.Is({toolStripComboBox.ComboBox.SelectedItemIndex});");

        [MenuAction]
        public static void Assert(FormsToolStripTextBox toolStripTextBox, string accessPath)
            => CaptureAdaptor.AddCode($"{accessPath}.Text.Is({ToLiteral(toolStripTextBox.Text)});");

        [MenuAction]
        public static void Assert(FormsTrackBar trackBar, string accessPath)
            => CaptureAdaptor.AddCode($"{accessPath}.Value.Is({trackBar.Value});");

        [MenuAction]
        public static void Assert(FormsTreeView treeView, string accessPath)
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
