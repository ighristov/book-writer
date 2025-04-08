namespace ClassLibrary
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public partial class BookRenderer
    {
        const int linesPerPage = 24;
        const string fileName = "CSharp Language Specification.txt";        

        public byte[] GetPageData(ref long position)
        {
            using (var reader = new StreamReader("CSharp Language Specification.txt"))
            {
                reader.BaseStream.Position = position;
                var line = "";
                var pageLines = new List<string>();
                while (pageLines.Count < linesPerPage && (line = reader.ReadLine()) != null)
                {
                    pageLines.Add(line);
                    position += line.Length + 2;
                }

                return pageLines.Any() 
                    ? this.GeneratePage(pageLines) 
                    : null;
            }
        }
    }
}
