﻿namespace Mealthy.Mealthy.Domain.Model;

public class Recipe
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int PreparationTime { get; set; }
    //Relationships
    public IList<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public IList<Step> Steps { get; set; } = new List<Step>();
}