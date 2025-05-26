using Microsoft.AspNetCore.Mvc;
using ProductCartTest.Dto;
using ProductCartTest.Models.ViewModels;
using ProductCartTest.Repository;

namespace ProductCartTest.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    // List all products
    public IActionResult Index()
    {
        List<ProductViewModel> viewModel = new List<ProductViewModel>();
        var products = _productRepository.GetAll();

        if (products == null || !products.Any())
        {
            return View(viewModel);
        }

        foreach (var product in products)
        {
            ProductViewModel productViewModel = new ProductViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price,
                Stock = product.Stock,
                CreatedDate = product.CreatedDate,
                UpdatedDate = product.UpdatedDate
            };

            viewModel.Add(productViewModel);
        }

        return View(viewModel);
    }

	// Create a new product
	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ProductViewModel vm)
    {
        if (ModelState.IsValid)
        {
            ProductDto product = new ProductDto
            {
                ProductName = vm.ProductName,
                ProductDescription = vm.ProductDescription,
                Price = vm.Price,
                Stock = vm.Stock,
                CreatedDate = DateTime.Now
            };

            _productRepository.Add(product);
            return RedirectToAction(nameof(Index));
        }

        return View(vm);
    }

    // Get an existing product
    public IActionResult Edit(int id)
    {
        ProductViewModel viewModel = new ProductViewModel();

        var product = _productRepository.GetById(id);
        if (product == null)
        {
            return View(viewModel);
        }

        viewModel.Id = product.Id;
        viewModel.ProductName = product.ProductName;
        viewModel.ProductDescription = product.ProductDescription;
        viewModel.Price = product.Price;
        viewModel.Stock = product.Stock;

        return View(viewModel);
    }

    // Update an existing product
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(ProductViewModel vm)
    {
        if (ModelState.IsValid)
        {
            ProductDto product = new ProductDto
            {
                Id = vm.Id,
                ProductName = vm.ProductName,
                ProductDescription = vm.ProductDescription,
                Price = vm.Price,
                Stock = vm.Stock,
                UpdatedDate = DateTime.Now
            };
            _productRepository.Update(product);

            return RedirectToAction(nameof(Index));
        }

        return View(vm);
    }

	// Delete a product
	public IActionResult Delete(int id)
	{
		ProductViewModel viewModel = new ProductViewModel();

		var product = _productRepository.GetById(id);
		if (product == null)
		{
			return View(viewModel);
		}

		viewModel.Id = product.Id;
		viewModel.ProductName = product.ProductName;
		viewModel.ProductDescription = product.ProductDescription;
		viewModel.Price = product.Price;
		viewModel.Stock = product.Stock;
		viewModel.CreatedDate = product.CreatedDate;

		return View(viewModel);
	}

	[HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteProduct(int id)
    {
        _productRepository.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
