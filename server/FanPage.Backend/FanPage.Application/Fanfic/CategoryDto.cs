namespace FanPage.Application.Fanfic;

public class CategoryDto
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    
    public ICollection<FanficCategoryDto> FanficCategories { get; set; }
}