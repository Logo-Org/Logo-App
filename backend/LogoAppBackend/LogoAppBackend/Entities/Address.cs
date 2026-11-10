using System.ComponentModel.DataAnnotations.Schema;

namespace LogoAppBackend.Entities;

[ComplexType]
public class Address {

    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;

}