using empact1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.ServiceModel.Syndication;
using System.Xml;

namespace empact1.Controllers
{
    public class HomeController : Controller
    {
        private readonly string rssURL = "https://rss.nytimes.com/services/xml/rss/nyt/World.xml";

        private ApplicationDbContext context { get; }

        public HomeController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var items = context.Items
                .Include(item => item.Categories)
                .Include(item => item.Categories.Select(category => category.MediaContent))
                .ToList();

            //if(items.Count == 0)
            //{

                using var reader = XmlReader.Create(rssURL);
                var feed = SyndicationFeed.Load(reader);


                foreach (var item in feed.Items)
                {

                var link = item.Categories.Select(c => new CategoryModel
                {
                    Domain = c.Label,
                    Description = c.Scheme,
                    MediaCredit = c.Name
                });

                    items.Add(new NewsItemModel
                    {
                        Title = item.Title.Text,
                        Description = item.Summary.Text,
                        Link = item.Links.First().Uri.OriginalString,
                        PublishDate = item.PublishDate.DateTime.ToString(),
                        DcCreator = item.Authors.FirstOrDefault()?.Name ?? string.Empty,
                        Categories = item.Categories.Select(c => new CategoryModel
                        {
                            Domain = c.Label,
                            Description = c.Scheme,
                            MediaCredit = c.Name
                        })

                    });
                }

                //context.Items.AddRange(items);

                context.SaveChanges();
            //}



            //var itemsWhichContainKeyword = feed.Items.Where(item => item.Summary.Text.Contains(""));

            return View(items);
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