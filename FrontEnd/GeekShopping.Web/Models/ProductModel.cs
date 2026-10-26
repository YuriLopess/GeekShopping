using System;
using System.ComponentModel.DataAnnotations;

namespace GeekShopping.Web.Models;

public class ProductModel
{
    public long Id { get; set; }

    [Required]
    [StringLength(150)]
    public string Name { get; set; } = string.Empty;

    [Range(1, 10000)]
    public decimal Price { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    [Display(Name = "Category")]
    [StringLength(50)]
    public string? CategoryName { get; set; }

    [Display(Name = "Image URL")]
    [StringLength(300)]
    public string? ImageURL { get; set; }
}
