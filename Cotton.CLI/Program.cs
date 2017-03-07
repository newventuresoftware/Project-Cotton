using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fclp;
using NewVentureSoftware.Cotton.Engine;

namespace Cotton.CLI
{
    class Program
    {
        private static ApplicationOptions ApplicationOptions { get; set; }

        static void Main(string[] args)
        {
            SetUpCommandLineParser(args);

            var page = PageDownloadEngine.DownloadPage("http://www.google.bg/");
        }

        private static void SetUpCommandLineParser(string[] args)
        {
            var parser = new FluentCommandLineParser<ApplicationOptions>();

            parser.Setup<string>(arg => arg.LeftURLSource).As("left-source").WithDescription("Points to the filename containing all left URLs");
            parser.Setup<string>(arg => arg.LeftURLSource).As("right-source").WithDescription("Points to the filename containing all right URLs");
            parser.SetupHelp("?", "help").Callback(text => Console.WriteLine(text));
            parser.Parse(args);
            Program.ApplicationOptions = parser.Object;
        }
    }
}
