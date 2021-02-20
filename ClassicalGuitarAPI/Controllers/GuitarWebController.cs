using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.Extensions.Logging;

namespace ClassicalGuitarAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuitarWebController : ControllerBase
    {
        private string oceanUrl = "https://www.oceannetworks.ca/news/stories";
        private string siteUrl = "https://www.siccasguitars.com/guitar/meistergitarren";
        public string[] QueryTerms { get; } = { "Ocean", "Nature", "Pollution" };
        //private List<Website> websites = new List<Website>();
        private List<string> imageLinks = new List<string>();


        private readonly ILogger<GuitarWebController> _logger;

        public GuitarWebController(ILogger<GuitarWebController> logger)
        {
            _logger = logger;
        }

        internal async Task ScrapeWebsite()
        {
            CancellationTokenSource cancellationToken = new CancellationTokenSource();
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage request = await httpClient.GetAsync(siteUrl);
            cancellationToken.Token.ThrowIfCancellationRequested();
Stream response = await request.Content.ReadAsStreamAsync();
            cancellationToken.Token.ThrowIfCancellationRequested();

            HtmlParser parser = new HtmlParser();
            IHtmlDocument document = parser.ParseDocument(response);
            GetScrapeResults(document);
        }

        private void GetScrapeResults(IHtmlDocument document)
        {
            var guitarImages = document.All.Where(x => x.TagName == "LI");
if (guitarImages.Any())
            {
                PrintResults(guitarImages);
            }
        }

        public void PrintResults(IEnumerable<IElement> guitarImages)
        {
            // Clean Up Results: See Next Step
            foreach (var images in guitarImages)
            {
CleanUpResults(images);

//rtb_debugDisplay.AppendText($"{Title} - {Url}{Environment.NewLine}");
            }
        }

        private void CleanUpResults(IElement result)
        {
            string htmlResult = result.InnerHtml;
            Console.WriteLine(htmlResult);
            IEnumerable<string> links = htmlResult.Split("\t\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Where(s => s.StartsWith("http://") || s.StartsWith("www.") || s.StartsWith("src=\"https://"));
            foreach (var link in links)
            {
                var removedPrefix = link.Replace("src=\"", "");
                var newLink = removedPrefix.Remove(removedPrefix.Length - 1, 1);
                imageLinks.Add(newLink);
            }
            //SplitResults(htmlResult);
        }



        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            await ScrapeWebsite();

            return imageLinks;
        }
    }
}
