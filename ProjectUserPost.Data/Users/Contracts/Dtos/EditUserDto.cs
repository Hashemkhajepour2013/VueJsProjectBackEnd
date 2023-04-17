using System.ComponentModel.DataAnnotations;

namespace ProjectUserPost.Data.Users.Contracts.Dtos;

public class EditUserDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string UserName { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = null!;

    [MaxLength(11)]
    public string Phone { get; set; }

    [MaxLength(100)]
    public string Website { get; set; }

    [MaxLength(100)]
    public string Company { get; set; }
}