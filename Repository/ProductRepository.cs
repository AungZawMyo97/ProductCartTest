using AutoMapper;
using Dapper;
using Microsoft.EntityFrameworkCore;
using ProductCartTest.DBContext;
using ProductCartTest.Dto;
using ProductCartTest.Models.EntityModels;
namespace ProductCartTest.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDBContext _dbContext;
    private readonly IMapper _mapper;

    public ProductRepository(ApplicationDBContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    // Get All Products
    public IEnumerable<ProductDto> GetAll()
    {
        using var connection = _dbContext.CreateConnection();
        var query = "SELECT * FROM Product";

        var products = connection.Query<Product>(query);

        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    // Get Product by Product Name
    public ProductDto? GetByProductName(string productName)
    {
        using var connection = _dbContext.CreateConnection();
        var query = "SELECT * FROM Product WHERE ProductName = @ProductName";

        var product = connection.QuerySingleOrDefault<Product>(query, new { ProductName = productName });
        
        return _mapper.Map<ProductDto>(product);
    }

    // Get Product by Id
    public ProductDto? GetById(int Id)
    {
        using var connection = _dbContext.CreateConnection();
        var query = "SELECT * FROM Product WHERE ID = @Id";

        var product = connection.QuerySingleOrDefault<Product>(query, new { Id = Id });
        
        return _mapper.Map<ProductDto>(product);
    }

    // Add Product
    public void Add(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);

        using var connection = _dbContext.CreateConnection();
        var command = "INSERT INTO Product (ProductName, ProductDescription, Price, Stock, CreatedDate) " +
			"VALUES (@ProductName, @ProductDescription, @Price, @Stock, @CreatedDate)";

        connection.Execute(command, product);
    }

    // Update Product
    public void Update(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);

        using var connection = _dbContext.CreateConnection();
        var sql = "UPDATE Product SET ProductName = @ProductName, ProductDescription = @ProductDescription, Price = @Price," +
			"Stock = @Stock, UpdatedDate = @UpdatedDate WHERE ID = @Id";

        connection.Execute(sql, product);
    }

    // Delete Product
    public void Delete(int id)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = "DELETE FROM Product WHERE ID = @Id";

        connection.Execute(sql, new { Id = id });
    }
}
