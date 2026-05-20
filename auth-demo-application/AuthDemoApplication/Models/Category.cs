namespace AuthDemoApplication.Models;

public sealed class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? IconUrl { get; set; }

    // Self-reference for subcategories
    public Guid? ParentCategoryId { get; set; }
    public Category? ParentCategory { get; set; }
    public ICollection<Category> SubCategories { get; set; } = [];

    // Navigation
    public ICollection<GameCategory> GameCategories { get; set; } = [];
}