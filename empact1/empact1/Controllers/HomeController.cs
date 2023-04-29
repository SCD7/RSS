using empact1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.ServiceModel.Syndication;
using System.Xml;

namespace empact1.Controllers
{
    public class HomeController : Controller
    {
        private readonly string rssURL = "https://rss.nytimes.com/services/xml/rss/nyt/World.xml";

        public IActionResult Index()
        {
            using var reader = XmlReader.Create(rssURL);
            var feed = SyndicationFeed.Load(reader);

            //var itemsWhichContainKeyword = feed.Items.Where(item => item.Summary.Text.Contains(""));

            return View(feed.Items);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}