using Core.Services;
using Core.Services.Interfaces;
using Moq;

namespace Unit.Tests.Core.Services;

public class TodoItemHandlerTests
{
    private static readonly Mock<ITodoItemRepository> Repo = new Mock<ITodoItemRepository>();

    private static readonly TodoItemHandler Handler = new TodoItemHandler(Repo.Object);
    
    [Fact(DisplayName = "Get all todo Item")]
    public async Task GetAllItems()
    {
        var repo = new Mock<ITodoItemRepository>();
        var handler = new TodoItemHandler(repo.Object);

        var result = await handler.GetTodoItems();

        Assert.Equal("Core.Entities.TodoItem[]", result.ToString());
    }

    [Fact(DisplayName = "Get one Item")]
    public async Task GetOneItem()
    {
        var result = await Handler.GetTodoItem(Guid.NewGuid());
        Assert.StartsWith("System.Threading.Tasks.Task", result.ToString());
    }
    
}