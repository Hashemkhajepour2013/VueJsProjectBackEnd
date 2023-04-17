using System.ComponentModel.DataAnnotations;

namespace ProjectUserPost.Data.Posts.Cotracts.Dtos
{
    public sealed class EditPostDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        public string Body { get; set; } = null!;
        public int userId { get; set; }
    }
}
