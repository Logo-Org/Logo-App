using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogoAppBackend.Entities;

[ComplexType]
public class Contact {

    [MaxLength(20)]
    public string PhoneNumber { get; set; } = string.Empty;

    [MaxLength(255)]
    public required string Email { get; set; } = string.Empty;

}