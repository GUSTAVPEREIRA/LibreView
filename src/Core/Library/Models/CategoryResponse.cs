using System.ComponentModel.DataAnnotations;

namespace Core.Library.Models;

public class CategoryResponse
{
    public int Id { get; set; }
    [Required] [MaxLength(100)] public string Name { get; set; }

    [MaxLength(500)] public string Description { get; set; }
}