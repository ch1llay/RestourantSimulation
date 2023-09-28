﻿using Microsoft.AspNetCore.Mvc;
using Models.Application.Items;
using Models.Enums;
using Service.DI.Interfaces;
using Service.Services.Interfaces;

namespace RestourantSimulation;

[ApiController]
[Route("[controller]")]
public class DishMenuController : Controller
{
    private readonly IDishService _dishService;

    public DishMenuController(IServiceManager serviceManager)
    {
        _dishService = serviceManager.DishService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(Dish dish)
    {
        return Ok(await _dishService.Add(dish));
    }

    [HttpPost("add-many")]
    public async Task<IActionResult> AddMany(List<Dish> dishes)
    {
        return Ok(await _dishService.AddMany(dishes));
    }


    [HttpPost("get-by-ids")]
    public async Task<IActionResult> GetByIds(List<int> ids)
    {
        return Ok(await _dishService.GetByIds(ids));
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _dishService.GetAll());
    }

    [HttpGet("all/available")]
    public async Task<IActionResult> GetAllAvailable()
    {
        return Ok(await _dishService.GetAllAvailable());
    }

    [HttpGet("by-type/{dishType}")]
    public async Task<IActionResult> GetAll(DishType dishType)
    {
        return Ok(await _dishService.GetByType(dishType));
    }

    [HttpGet("by-type/{dishType}/available")]
    public async Task<IActionResult> GetByTypeAvailable(DishType dishType)
    {
        return Ok(await _dishService.GetByTypeAvailable(dishType));
    }


    [HttpPut("update")]
    public async Task<IActionResult> Update(Dish dish)
    {
        return Ok(await _dishService.Update(dish));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _dishService.Delete(id));
    }
}