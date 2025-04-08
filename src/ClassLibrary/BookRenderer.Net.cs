namespace ClassLibrary
{
    using SkiaSharp;

    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    public partial class BookRenderer
    {
        static readonly SKFont font = new SKFont(SKTypeface.Default);
        static readonly SKPaint paintText = new SKPaint() { Color = SKColors.Black };
        static readonly SKPaint paintBackground = new SKPaint() { Color = SKColors.White };
        
        byte[] GeneratePage(IList<string> pageLines)
        {
            using (var bitmap = new SKBitmap(794, 1122))
            using (SKCanvas canvas = new SKCanvas(bitmap))
            {
                canvas.DrawRect(0, 0, bitmap.Width, bitmap.Height, paintBackground);

                for (int i = 0; i < pageLines.Count; i++)
                {
                    canvas.DrawText(pageLines[i], 10, (30 * i), SKTextAlign.Left, font, paintText);
                }

                using (var image = SKImage.FromBitmap(bitmap))
                using (var data = image.Encode(SKEncodedImageFormat.Jpeg, 100))
                {
                    return data.ToArray();
                }
            }
        }
    }
}
