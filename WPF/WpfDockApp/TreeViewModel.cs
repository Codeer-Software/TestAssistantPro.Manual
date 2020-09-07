using System.Collections.Generic;

namespace WpfDockApp
{
    public class TreeViewModel
    {
        public string Name { get; set; }

        public bool IsExpanded { get; set; }

        public List<TreeViewModel> Children { get; set; }
    }
}
