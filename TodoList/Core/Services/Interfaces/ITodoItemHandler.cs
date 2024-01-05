using Core.Entities;

namespace Core.Services.Interfaces;

public interface ITodoItemHandler
{
    public Task<IEnumerable<TodoItem>> GetTodoItems();

    public Task<TodoItem> GetTodoItem(Guid id);
    
    public Task<TodoItem> PutTodoItem (Guid id, TodoItem todoItem);

    public Task<TodoItem> PostTodoItem(TodoItem todoItem);
    

}