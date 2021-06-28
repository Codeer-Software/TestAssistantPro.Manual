using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Codeer.TestAssistant.GeneratorToolKit;
using RM.Friendly.WPFStandardControls;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Primitives;

namespace Driver.InTarget
{
    [CaptureCodeGenerator("Driver.Controls.CheckListBoxDriver")]
    public class CheckListBoxDriverGenerator : CaptureCodeGeneratorBase
    {
        CheckListBox _list;

        protected override void Attach()
        {
            _list = (CheckListBox)ControlObject;
            _list.GotFocus += GotFocus;
        }

        protected override void Detach()
            => _list.GotFocus -= GotFocus;

        void GotFocus(object sender, RoutedEventArgs e)
        {
            var index = GetActiveIndex(_list);
            if (index == -1) return;

            AddSentence(new TokenName(), $".EmulateActivateItem({index});");
        }

        public static int GetActiveIndex(ItemsControl list)
        {
            //マウスもしくはキーボードフォーカスのある要素を取得
            DependencyObject focusedElement = null;
            if (list.IsKeyboardFocusWithin)
            {
                focusedElement = Keyboard.FocusedElement as DependencyObject;
            }
            else if (list.IsMouseCaptureWithin)
            {
                focusedElement = Mouse.Captured as DependencyObject;
            }
            if (focusedElement == null) return -1;

            //親方向にVisualTreeをたどってSelectorItemを見つける
            var focusedItem = focusedElement.VisualTree(TreeRunDirection.Ancestors).OfType<SelectorItem>().FirstOrDefault();
            if (focusedItem == null) return -1;

            //インデックスを取得
            return list.ItemContainerGenerator.IndexFromContainer(focusedItem);
        }
    }
}
