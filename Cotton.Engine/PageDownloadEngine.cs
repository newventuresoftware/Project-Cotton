using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NewVentureSoftware.Cotton.Engine
{
    public sealed class PageDownloadEngine
    {
        private PageDownloadEngine()
        {

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
