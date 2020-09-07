# Captureウィンドウをカスタマイズする

TestAssitantProはCodeer.TestAssistant.GeneratorToolkit に定義されているインタフェースを実装することでその挙動をカスタマイズできます。
ソリューション内で実装および実装されているdllの参照のどちらも利用できます。

## ドライバツリーのコンテキストメニューの拡張

ICaptureAttachTreeMenuActionを実装することでドライバツリーに表示されるメニューを拡張できます。
テストソリューションのDriverプロジェクトにある、Tools/CaptureAttachTreeMenuAction.csファイルにはAssertの定義が標準で実装されています。


```cs
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Codeer.Friendly.Windows;
using Codeer.TestAssistant.GeneratorToolKit;
using RM.Friendly.WPFStandardControls;

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

        void Assert(string accessPath, WPFCalendar calendar)
        {
            //CheckStateをネームスペース修飾無しで使うのでコード生成後にusingも追加されるようにする
            CaptureAdaptor.AddUsing(typeof(DateTime).Namespace);

            if (calendar.SelectedDate.HasValue)
            {
                //現在のSelectedDateを期待値とするコードを作成
                var value = calendar.SelectedDate.Value;
                CaptureAdaptor.AddCode($"{accessPath}.SelectedDate.Is(new DateTime({value.Year}, {value.Month}, {value.Day}));");
            }
            else
            {
                CaptureAdaptor.AddCode($"{accessPath}.SelectedDate.IsNull();");
            }
        }
```

![ICaptureAttachTreeMenuAction.png](../Img/ICaptureAttachTreeMenuAction.png)

