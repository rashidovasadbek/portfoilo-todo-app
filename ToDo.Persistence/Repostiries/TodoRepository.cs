using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Persistence.DataContext;
using ToDo.Persistence.Repostiries.Interfaces;

namespace ToDo.Persistence.Repostiries;

public class TodoRepository : EntityRepositoryBase<TodoItem, AppDbContext>, ITodoRepository
{
    public TodoRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<TodoItem> Get(Expression<Func<TodoItem, bool>> predicate = default, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public ValueTask<TodoItem> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public ValueTask<TodoItem> CreateAsync(TodoItem todoItem, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(todoItem, saveChanges, cancellationToken);
    }

    public async ValueTask<bool> UpdateAsync(TodoItem todoItem, CancellationToken cancellationToken = default)
    {
        var result = await DbContext.Todos
            .Where(x => x.Id == todoItem.Id)
            .ExecuteUpdateAsync(propertySetter => propertySetter
                .SetProperty(toto => toto.Title, todoItem.Title)
                .SetProperty(todo => todo.IsDone, todoItem.IsDone)
                .SetProperty(todo => todo.IsFavorite, todoItem.IsFavorite)
                .SetProperty(todo => todo.DueTime, todoItem.DueTime)
                .SetProperty(todo => todo.ReminderTime, todoItem.ReminderTime)
                .SetProperty(todo => todo.ModifiedTime, DateTimeOffset.UtcNow), 
            cancellationToken
        );
        
        return result > 0;
    }

    public async ValueTask<bool> DeleteByIdAsync(Guid todoId, CancellationToken cancellationToken = default)
    {
        var result = await DbContext.Todos.Where(x => x.Id == todoId).ExecuteDeleteAsync(cancellationToken);

        return result > 0;
    }
}