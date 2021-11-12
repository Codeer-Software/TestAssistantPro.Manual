# Captureウィンドウをカスタマイズする

TestAssitantProはCodeer.TestAssistant.GeneratorToolkit に定義されているインタフェースを実装することでその挙動をカスタマイズできます。
ソリューション内で実装および実装されているdllの参照のどちらも利用できます。

## ドライバツリーのコンテキストメニューの拡張

[MenuAction]属性を付けることでドライバツリーに表示されるメニューを拡張できます。
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
    public static class CapterAttachTreeMenuAction
    {
        [MenuAction]
        public static void Assert(WPFComboBox comboBox, string accessPath)
            => CaptureAdaptor.AddCode($"{accessPath}.SelectedIndex.Is({comboBox.SelectedIndex});");

        [MenuAction]
        public static void Assert(WPFListBox listBox, string accessPath)
            => CaptureAdaptor.AddCode($"{accessPath}.SelectedIndex.Is({listBox.SelectedIndex});");

        [MenuAction]
        public static void Assert(WPFListView listView, string accessPath)
            => CaptureAdaptor.AddCode($"{accessPath}.SelectedIndex.Is({listView.SelectedIndex});");

        [MenuAction]
        public static void Assert(WPFProgressBar progressBar, string accessPath)
            => CaptureAdaptor.AddCode($"{accessPath}.Value.Is({progressBar.Value});");

        [MenuAction]
        public static void Assert(WPFRichTextBox richTextBox, string accessPath)
            => CaptureAdaptor.AddCode($"{accessPath}.Text.Is({ToLiteral(richTextBox.Text)});");

        [MenuAction]
        public static void Assert(WPFSelector selector, string accessPath)
            => CaptureAdaptor.AddCode($"{accessPath}.SelectedIndex.Is({selector.SelectedIndex});");

        [MenuAction]
        public static void Assert(WPFSlider slider, string accessPath)
            => CaptureAdaptor.AddCode($"{accessPath}.Value.Is({slider.Value});");

        [MenuAction]
        public static void Assert(WPFTabControl tabControl, string accessPath)
            => CaptureAdaptor.AddCode($"{accessPath}.SelectedIndex.Is({tabControl.SelectedIndex});");

        [MenuAction]
        public static void Assert(WPFTextBox textBox, string accessPath)
            => CaptureAdaptor.AddCode($"{accessPath}.Text.Is({ToLiteral(textBox.Text)});");

        [MenuAction]
        public static void Assert(WPFTextBlock textBlock, string accessPath)
            => CaptureAdaptor.AddCode($"{accessPath}.Text.Is({ToLiteral(textBlock.Text)});");

        [MenuAction]
        public static void Assert(WPFToggleButton toggleButton, string accessPath)
        {
            var value = toggleButton.IsChecked == null ? "null" : toggleButton.IsChecked.Value.ToString().ToLower();
            CaptureAdaptor.AddCode($"{accessPath}.IsChecked.Is({value});");
        }

        [MenuAction]
        public static void Assert(WPFTreeView treeView, string accessPath)
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

        [MenuAction]
        public static void Assert(WPFCalendar calendar, string accessPath)
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

        [MenuAction]
        public static void Assert(WPFDatePicker datePicker, string accessPath)
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

        [MenuAction]
        public static void Assert(WPFDataGrid dataGrid, string accessPath)
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
```

![ICaptureAttachTreeMenuAction.png](../Img/ICaptureAttachTreeMenuAction.png)

### MenuActionの指定方法

#### staticの場合
```cs
    [MenuAction]
    public static void MenuActionTest(SimpleWindowDriver driver, string accessPath)
    {
    }

    [MenuAction]
    public static void MenuActionTestNonParam(SimpleWindowDriver driver)
    {
    }
```
staticの場合は上記Assertと同様に、第1引数はそのクラスのオブジェクトとなります。<br>
第2引数には「string accessPath」と指定することで、アクセスパスを指定することができます（省略可）。

#### メンバの場合
```cs
    [MenuAction]
    public void MenuActionTest2()
    {
    }

    [MenuAction(DisplayName="MenuActionTestAAAAA")]
    public void MenuActionTest3(string accessPath)
    {
    }

    [MenuAction]
    public void MenuActionTest4(string accessPath)
    {
    }
```
メンバとして指定する場合は、第1引数は「string accessPath」を指定することができます（省略可）。<br>
他の引数を指定した場合はエラーとなりメニューへの表示はされません。<br>
また、属性のパラメータとして「DisplayName」を指定することで、メニューでの表示名を変更することができます。<br>

正しく記述することで、右クリックメニューにメソッドが表示されます。<br>
![MenuAction_1_.png](../Img/CaptureAttachTreeMenuAction_1.png)<br>

MenuAction属性が付いたメソッドは、上記Assertのように「CaptureAdaptor.AddCode」等を記述しない限り、実行されるだけでキャプチャされたコードが出力されることはありません。

### メソッドの実行
![MenuAction_2_.png](../Img/CaptureAttachTreeMenuAction_2.png)<br>
対象となるオブジェクトのpublicメソッドが「Methods」項目に一覧表示されます。<br>
ドライバのクラスでpublicメソッドを書くことで、独自の処理を呼び出すことができます。

```cs
    public void テスト1(bool x)
    {
    }

    public enum XXX
    {
        A,
        B
    }

    public void テスト2(XXX x)
    {
    }
```
引数にはstring、bool、Enum、int等の数値型を指定することができます（対応外の引数が指定されている場合はメニューに表示されません）。<br>
実行時、引数が指定されている場合は入力用のダイアログが表示されます。<br>
![MenuAction_3_.png](../Img/CaptureAttachTreeMenuAction_3.png)<br>
