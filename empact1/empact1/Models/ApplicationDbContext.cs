using Microsoft.EntityFrameworkCore;
using System.ServiceModel.Syndication;
using System.Xml;

namespace empact1.Models

{
    public class ApplicationDbContext : DbContext
    {
        private readonly string rssURL = "https://rss.nytimes.com/services/xml/rss/nyt/World.xml";

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<MediaContentModel> MediaContents { get; set; }
        public DbSet<NewsItemModel> Items { get; set; }

    }
}

