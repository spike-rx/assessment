using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

/// <summary>
///     database entity
/// </summary>
public class TodoItem
{
    [Key] public Guid Id { get; set; }

    [StringLength(1000)] public string Description { get; set; }

    public bool IsCompleted { get; set; }
}