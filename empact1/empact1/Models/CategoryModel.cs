using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace empact1.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }

        public string? Domain { get; set; }

        public string? Description { get; set; }

        [ForeignKey("MediaContentModel")]
        public int MediaContentId { get; set; }

        public MediaContentModel MediaContent { get; set; }

        public string? MediaCredit { get;  set; }

        public string? MediaDescription { get; set; }


    }
}