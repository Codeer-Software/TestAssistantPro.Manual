using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDockApp
{
    public class MakeDocumentEventArgs
    {
        public string Header;

        public string[][] Document { get; set; }


        public MakeDocumentEventArgs(string header, string[][] document)
        {
            Header = header;
            Document = document;
        }
    }
}
