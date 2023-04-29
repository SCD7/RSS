using System.ComponentModel.DataAnnotations;

namespace empact1.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }  

        public string? Domain { get; set; }

        public string? Description { get; set; }

    }
}
