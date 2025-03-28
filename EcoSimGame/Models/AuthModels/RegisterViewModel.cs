using System.ComponentModel.DataAnnotations;

namespace EcoSimGame.Models.AuthModels;

public class RegisterViewModel
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Hasła muszą być identyczne.")]
    public string ConfirmPassword { get; set; }
}
