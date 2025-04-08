namespace ConsoleAppNet
{
    using ClassLibrary;

    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    internal class Program
    {
        private const int TotalBookIterations = 100;
        private const int PagesReportFrequency = 100;

        static void Main(string[] args)
        {
            Console.WriteLine($"Rendering started. Using .NET Runtime {Environment.Version} on {Environment.OSVersion.Platform}");

            for (int bookIteration = 1; bookIteration <= TotalBookIterations; bookIteration++)
            {
                RenderBook(bookIteration);
            }

            Console.WriteLine("All rendering complete.");
            Console.ReadKey();
        }

        private static void RenderBook(int bookIteration)
        {
            int pageNumber = 1;
            long position = 0;
            var bookRenderer = new BookRenderer();
            var stopWatch = Stopwatch.StartNew();

            while (true)
            {
                byte[] pageData = bookRenderer.GetPageData(ref position);

                if (pageData == null)
                    break;

                if (pageNumber % PagesReportFrequency == 0)
                {
                    Console.WriteLine($"Book {bookIteration}: rendered {pageNumber} pages.");
                }

                // Uncomment the code below to enable image output.
                // System.IO.File.WriteAllBytes($"img_{bookIteration}_{pageNumber}.jpeg", pageData);
                pageNumber++;
            }

            stopWatch.Stop();
            Console.WriteLine($"Book {bookIteration} completed rendering in {stopWatch.Elapsed.TotalSeconds:F2} seconds. Rendered {pageNumber - 1} pages.");
        }
    }
}