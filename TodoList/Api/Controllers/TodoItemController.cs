using System;
using System.Threading.Tasks;
using Core.Entities;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoItemController: ControllerBase
{
    private readonly ITodoItemHandler _todoItemHandler;

    public TodoItemController(ITodoItemHandler todoItemHandler)
    {
        _todoItemHandler = todoItemHandler;
    }

    // Get: api/TodoItems
    // ActionResult may be better
    [HttpGet]
    public async Task<IActionResult> GetTodoItems()
    {
        var result = await _todoItemHandler.GetTodoItems();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTodoItem(Guid id)
    {
        var result = await _todoItemHandler.GetTodoItem(id);
        return Ok(result);

    }

    [HttpPut]
    public async Task<IActionResult> PutTodoItem(Guid id, TodoItem todoItem)
    {

        var result = await _todoItemHandler.PutTodoItem(id, todoItem);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostTodoItem(TodoItem todoItem)
    {
        await _todoItemHandler.PostTodoItem(todoItem);
        return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);

    }
    
}