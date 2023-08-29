using System.ComponentModel.DataAnnotations;

namespace BookShopFront.DTO.Author
{
    public class CreateAuthorDTO
    {
        [Required]
        [StringLength(8, ErrorMessage = "FullName length can't be more than 8.")]
        public string FullName { get; set; }
        public string? BIO { get; set; }
    }
}
