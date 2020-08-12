using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDockApp
{
    public class SearchEventArgs
    {
        public string SearchResult;

        public SearchEventArgs(string result)
        {
            SearchResult = result;
        }
    }
}
