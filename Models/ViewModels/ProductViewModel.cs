namespace ProductCartTest.Models.ViewModels;

public class ProductViewModel
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    // Additional properties for view purposes
    public string FormattedPrice => Price.ToString("C");
    public string FormattedCreatedDate => CreatedDate.ToString("MM/dd/yyyy");
    public string FormattedUpdatedDate => (UpdatedDate != null ? UpdatedDate?.ToString("MM/dd/yyyy") : "-");
}