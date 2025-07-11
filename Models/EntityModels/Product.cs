﻿namespace ProductCartTest.Models.EntityModels;

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
