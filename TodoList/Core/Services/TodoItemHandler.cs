using Core.Entities;
using Core.Services.Interfaces;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Mvc;


namespace Core.Services;

public class TodoItemHandler:ITodoItemHandler
{
    private readonly ITodoItemRepository _itemRepository;

    public TodoItemHandler(ITodoItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public Task<IEnumerable<TodoItem>> GetTodoItems()
    {
        return _itemRepository.GetTodoItemAsync();
    }

    public Task<TodoItem> GetTodoItem(Guid id)
    {
        return _itemRepository.GetTodoItem(id);
    }

    public async Task<TodoItem> PutTodoItem(Guid id, TodoItem todoItem)
    {
        if (id != todoItem.Id)
        {
            throw new ProblemDetailsException(new ValidationProblemDetails
            {
                Status = 404, Detail = "Not the same item"

            });

        }
        try
        {
            await _itemRepository.SaveChangeAsync(todoItem);
        }
        catch (Exception)
        {
            if (!TodoItemIdExists(id))
            {
                throw new ProblemDetailsException(new ValidationProblemDetails
                {
                    Status = 403, Detail = "Id not found"
                });
            }
        }
        return todoItem;
    }

    public Task<TodoItem> PostTodoItem(TodoItem todoItem)
    {
        if (string.IsNullOrEmpty(todoItem?.Description))
        {
            throw new ProblemDetailsException(new ValidationProblemDetails
            {
                Status = 403, Detail = "Description is required"
            });
        }
        else if (TodoItemDescriptionExists(todoItem.Description))
        {
            throw new ProblemDetailsException(new ValidationProblemDetails
            {
                Status = 403, Detail = "Duplicated description"
            });
        }

        return _itemRepository.AddTodoItemAsync(todoItem);
    }


    private bool TodoItemIdExists(Guid id)
    {
        return _itemRepository.TodoItemIdExists(id);
    }

    
    private bool TodoItemDescriptionExists(string description)
    {
        return _itemRepository.TodoItemDescriptionExits(description);
    }

}