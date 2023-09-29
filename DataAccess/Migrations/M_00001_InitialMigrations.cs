﻿using FluentMigrator;
using FluentMigrator.Expressions;

namespace DataAccess.Migrations;

[Migration(1, "Initial")]
public class M_00001_InitialMigrations : Migration
{
    public override void Up()
    {
        Create.Table("Employees")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString()
            .WithColumn("EmployeeType").AsInt32()
            .WithColumn("EmployeeRang").AsInt32();

        Create.Table("Tables")
            .WithColumn("Number").AsInt32().PrimaryKey().Identity()
            .WithColumn("PeopleCapacity").AsInt32()
            .WithColumn("Available").AsBoolean();

        Create.Table("Products")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString()
            .WithColumn("IsByWeight").AsBoolean()
            .WithColumn("Amount").AsInt32();
        
        Create.Table("Drinks")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString()
            .WithColumn("DrinkType").AsInt32()
            .WithColumn("Cost").AsDecimal();

        
        Create.Table("Dishes")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString()
            .WithColumn("DishType").AsInt32()
            .WithColumn("Cost").AsDecimal();
        
        Create.Table("ProductDish")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("DishId").AsInt32().ForeignKey("Dishes", "Id")
            .WithColumn("ProductId").AsInt32().ForeignKey("Products", "Id");
        
        Create.Table("ProductDrink")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("DrinkId").AsInt32().ForeignKey("Drinks", "Id")
            .WithColumn("ProductId").AsInt32().ForeignKey("Products", "Id");
        
       
        Create.Table("Orders")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("StartTime").AsDateTime()
            .WithColumn("EndTime").AsDateTime()
            .WithColumn("TableNumber").AsInt32().ForeignKey("Tables", "Number")
            .WithColumn("PeopleAmount").AsInt32()
            .WithColumn("Amount").AsDecimal();

        Create.Table("CookingDishes")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("DishId").AsInt32().ForeignKey("Dishes", "Id")
            .WithColumn("OrderId").AsInt32().ForeignKey("Orders", "Id")
            .WithColumn("StartTime").AsDateTime()
            .WithColumn("EndTime").AsDateTime();
        
        Create.Table("CookingDrinks")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("DrinkId").AsInt32().ForeignKey("Drinks", "Id")
            .WithColumn("OrderId").AsInt32().ForeignKey("Orders", "Id")
            .WithColumn("StartTime").AsDateTime()
            .WithColumn("EndTime").AsDateTime();
        
        Create.Table("ProductCookingDish")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("CookingDishId").AsInt32().ForeignKey("CookingDishes", "Id")
            .WithColumn("ProductId").AsInt32().ForeignKey("Products", "Id")
            .WithColumn("StartTime").AsDateTime()
            .WithColumn("EndTime").AsDateTime();
        
        Create.Table("ProductCookingDrink")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("CookingDrinkId").AsInt32().ForeignKey("CookingDrinks", "Id")
            .WithColumn("ProductId").AsInt32().ForeignKey("Products", "Id")
            .WithColumn("StartTime").AsDateTime()
            .WithColumn("EndTime").AsDateTime();
    }

    public override void Down()
    {
        Delete.Table("ProductCookingDish");
        Delete.Table("CookingDishes");
        Delete.Table("Orders");
        Delete.Table("ProductDish");
        Delete.Table("Dishes");
        Delete.Table("Products");
        Delete.Table("Tables");
        Delete.Table("Employees");
    }
}