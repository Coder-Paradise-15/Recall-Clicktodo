using RecallClickTodo.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecallClickTodo.Core.Interfaces
{
    public interface ITodoService
    {
        Task<Todo> CreateTodoAsync(Todo todo);
        Task<Todo> GetTodoAsync(Guid id);
        Task<IEnumerable<Todo>> GetAllTodosAsync();
        Task<IEnumerable<Todo>> GetTodosByStatusAsync(TodoStatus status);
        Task<Todo> UpdateTodoAsync(Todo todo);
        Task<bool> DeleteTodoAsync(Guid id);
        Task<IEnumerable<Todo>> SearchTodosAsync(string query);
        Task<IEnumerable<Todo>> GetTodosByPriorityAsync(int priority);
    }
}
