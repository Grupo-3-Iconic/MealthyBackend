﻿namespace Mealthy.Mealthy.Domain.Model;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public float Price { get; set; }
    public int storeId { get; set; }
    public string Unit { get; set; }
    public int Quantity { get; set; }
    public string photoUrl { get; set; }
}