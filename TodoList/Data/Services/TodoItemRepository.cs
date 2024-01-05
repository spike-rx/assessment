using Core.Entities;
using Core.Services.Interfaces;
using Data.Contexts;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Data.Services;

public class TodoItemRepository: ITodoItemRepository
{
    private readonly TodoContext _todoContext;

    public TodoItemRepository(TodoContext todoContext)
    {
        _todoContext = todoContext;
    }
    
    
    public async Task<IEnumerable<TodoItem>> GetTodoItemAsync()
    {
        return await _todoContext.TodoItems.Where(x => !x.IsCompleted).ToListAsync();
            
        
    }

    public async Task<TodoItem> GetTodoItem(Guid id)
    {
        var result = await _todoContext.TodoItems.FindAsync(id);
        if (result == null)
        {
            throw new ProblemDetailsException(new ValidationProblemDetails
            {
                Status = 422, Detail = "Item not found"
            });
        }
        return result;
    }

    public async Task<TodoItem> SaveChangeAsync(TodoItem todoItem)
    {
        _todoContext.Entry(todoItem).State = EntityState.Modified;
        await _todoContext.SaveChangesAsync();
        return todoItem;
    }

    public async Task<TodoItem> AddTodoItemAsync(TodoItem todoItem)
    {
        _todoContext.TodoItems.Add(todoItem);
        await _todoContext.SaveChangesAsync();
        return todoItem;
    }

    public bool TodoItemIdExists(Guid id)
    {
        return _todoContext.TodoItems.Any(x => x.Id == id);
    }

    public bool TodoItemDescriptionExits(string description)
    {
        return _todoContext.TodoItems
            .Any(x => x.Description.ToLowerInvariant() == description.ToLowerInvariant() && !x.IsCompleted);
    }
}