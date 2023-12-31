﻿using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserLogic userLogic;

    public UsersController(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }

    [HttpPost,Route("create")]
    public async Task<ActionResult<User>> CreateAsync(User dto)
    {
        try
        {
            userLogic.CreateAsync(dto);
            return Created($"/users/{dto.Id}", dto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet, Route("GetByEmail")]
    public async Task<ActionResult<User>> GetByEmailAsync([FromQuery] string email)
    {
        try
        {
            User user = await userLogic.GetByEmailAsync(email);
            return Ok(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{getById:int}")]
    public async Task<ActionResult<User>> GetByIdAsync([FromRoute] int getById)
    {
        try
        {
            User user = await userLogic.GetByIdAsync(getById);
            return Ok(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete("delete/{deleteId:int}")]
    public async void DeleteUser([FromRoute] int deleteId){
        try
        {
            userLogic.deleteUser(deleteId);
            Ok("user delete");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            StatusCode(500, e.Message);
        }
    }

    [HttpPatch,Route("patch")]
    public async Task<ActionResult<User>> UpdateUser(User dto){
        try
        {
           await userLogic.UpdateUser(dto);
            return Created($"/users/{dto.Id}", dto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}