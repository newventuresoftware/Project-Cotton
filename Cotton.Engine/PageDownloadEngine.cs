using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NewVentureSoftware.Cotton.Engine
{
    public static class PageDownloadEngine
    {
        public static IList<PageData> DownloadPagesFromFile(string pathToFile, Action<string> progressCallback = null)
        {
            var urls = File.ReadAllLines(pathToFile);

            return DownloadPages(urls, progressCallback);
        }

        public static IList<PageData> DownloadPages(IEnumerable<string> pagesToDownload, Action<string> progressCallback = null)
        {
            var pageData = new List<PageData>();

            foreach (var url in pagesToDownload)
            {
                pageData.Add(DownloadPage(url));
                progressCallback?.Invoke(url);
            }

            return pageData;
        }

        public static PageData DownloadPage(string pageToDownload)
        {
            using (var client = new HttpClient())
            {
                var pageContent = client.GetStringAsync(pageToDownload).Result;
                var document = new HtmlDocument();
                var pageData = new PageData() { PageURL = pageToDownload };

                document.LoadHtml(pageContent);
                pageData.Title = document.DocumentNode.Descendants("title").FirstOrDefault()?.InnerText;
                pageData.Body = document.DocumentNode.Descendants("body").FirstOrDefault()?.InnerText;

                return pageData;
            }
        }
    }
}
