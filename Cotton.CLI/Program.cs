using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fclp;
using NewVentureSoftware.Cotton.Engine;
using System.IO;
using Newtonsoft.Json;

namespace Cotton.CLI
{
    class Program
    {
        private const string defaultName = "out.json";

        private static ApplicationOptions ApplicationOptions { get; set; }

        static void Main(string[] args)
        {
            SetUpCommandLineParser(args);

            switch (ApplicationOptions.Mode)
            {
                case Mode.Crawl:
                    PerformCrawl();
                    break;
                case Mode.Compare:
                    PerformCompare();
                    break;
                default:
                    break;
            }
        }

        private static void PerformCrawl()
        {
            if (!string.IsNullOrWhiteSpace(ApplicationOptions.PagesSource) && File.Exists(ApplicationOptions.PagesSource))
            {
                var pageData = PageDownloadEngine.DownloadPagesFromFile(ApplicationOptions.PagesSource, UrlCrawledProgress);
                var serializedData = JsonConvert.SerializeObject(pageData);

                if(!string.IsNullOrWhiteSpace(ApplicationOptions.OutputFile))
                {
                    File.WriteAllText(ApplicationOptions.OutputFile, serializedData);
                }
                else
                {
                    File.WriteAllText(defaultName, serializedData);
                }
            }
        }

        private static void UrlCrawledProgress(string url)
        {
            Console.WriteLine($"Finished crawling: {url}");
        }

        private static void PerformCompare()
        {
            throw new NotImplementedException();
        }

        private static void SetUpCommandLineParser(string[] args)
        {
            var parser = new FluentCommandLineParser<ApplicationOptions>();

            parser.Setup<string>(arg => arg.PagesSource).As('p', "pages").WithDescription("Points to a filename containing all URLs to scan.");
            parser.Setup<string>(arg => arg.OutputFile).As('o', "output").SetDefault(defaultName).WithDescription("Points to a filename where all page data is stored.");
            parser.Setup<Mode>(arg => arg.Mode).As('m', "mode").WithDescription("REQUIRED: Specifies what operation the program will perform.").Required();
            parser.SetupHelp("?", "help").Callback(text => Console.WriteLine(text));

            if(parser.Parse(args).HasErrors)
            {
                parser.HelpOption.ShowHelp(parser.Options);
                Environment.Exit(-1);
            }

            Program.ApplicationOptions = parser.Object;
        }
    }
}
