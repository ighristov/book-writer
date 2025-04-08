namespace ClassLibrary
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    public partial class BookRenderer
    {
        byte[] GeneratePage(IList<string> pageLines)
        {
            using (var bitmap = new System.Drawing.Bitmap(794, 1122))
            {
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.Clear(Color.White);
                    for (int i = 0; i < pageLines.Count; i++)
                    {
                        g.DrawString(pageLines[i], SystemFonts.DefaultFont, SystemBrushes.WindowText, new PointF(10, 30 * i));
                    }
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    bitmap.Save(ms, ImageFormat.Bmp);
                    return ms.ToArray();
                }
            }
        }
    }
}
