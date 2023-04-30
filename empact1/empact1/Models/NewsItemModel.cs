using System.ComponentModel.DataAnnotations;

namespace empact1.Models
{
    public class NewsItemModel
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Link { get; set;}
        public string? PublishDate { get; set; }
        public string? DcCreator { get; set; }

        public IEnumerable<CategoryModel>? Categories { get; set; } 

    }
}
