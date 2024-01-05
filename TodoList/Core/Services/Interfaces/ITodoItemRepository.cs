using Core.Entities;

namespace Core.Services.Interfaces;

public interface ITodoItemRepository
{
    public Task<IEnumerable<TodoItem>> GetTodoItemAsync();

    public Task<TodoItem> GetTodoItem(Guid id);

    public Task<TodoItem> SaveChangeAsync(TodoItem todoItem);

    public Task<TodoItem> AddTodoItemAsync(TodoItem todoItem);

    public bool TodoItemIdExists(Guid id);
    
    public bool TodoItemDescriptionExits(string description);


}