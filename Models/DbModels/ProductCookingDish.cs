﻿namespace Models.DbModels;

public class ProductCookingDish
{
    public int Id { get; set; }
    public int CookingDishId { get; set; }
    public int ProductId { get; set; }
    public int ProductAmount { get; set; }
}