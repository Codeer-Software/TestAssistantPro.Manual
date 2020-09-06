using System.Windows;
using System.Windows.Controls;

namespace WpfDockApp
{
    public class ListViewDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DataTemplate1 { get; set; }
        public DataTemplate DataTemplate2 { get; set; }
        public DataTemplate DataTemplate3 { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is ListView1ViewModel)
            {
                return DataTemplate1;
            }
            else if (item is ListView2ViewModel)
            {
                return DataTemplate2;
            }
            else if (item is ListView3ViewModel)
            {
                return DataTemplate3;
            }
            return null;
        }
    }
}
