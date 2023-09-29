﻿using Common.Enums;
using Service.Items;

namespace Service.Models;

public class Dish : MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public DishType DishType { get; set; }
}