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
