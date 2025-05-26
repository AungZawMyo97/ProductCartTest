using ProductCartTest.Dto;
using ProductCartTest.Models.EntityModels;

namespace ProductCartTest.Repository;

public interface IProductRepository
{
    // Get All Products
    IEnumerable<ProductDto> GetAll();

    // Get Product by Product Name
    ProductDto? GetByProductName(string productName);

    // Get Product by Id
    ProductDto? GetById(int Id);

    // Add Product
    void Add(ProductDto productDto);

    // Update Product
    void Update(ProductDto productDto);

    // Delete Product
    void Delete(int id);
}
