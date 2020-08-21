using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDockApp
{
    public class TreeViewModel
    {
        public string Name { get; set; }

        public bool IsExpanded { get; set; }

        public List<TreeViewModel> Children { get; set; }
    }
}
