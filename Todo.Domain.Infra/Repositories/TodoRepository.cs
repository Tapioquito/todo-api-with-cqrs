using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Queries;

namespace Todo.Domain.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _dataContext;
        public TodoRepository(DataContext context)
        {
            _dataContext = context;
        }
        public void Create(TodoItem todo)
        {
            _dataContext.Todos.Add(todo);
            _dataContext.SaveChanges();
        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            return _dataContext
                .Todos.AsNoTracking()
                .Where(TodoQueries.GetAll(user))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            return _dataContext
                .Todos.AsNoTracking()
                .Where(TodoQueries.GetAllDone(user))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllNotDone(string user)
        {
            return _dataContext
                .Todos.AsNoTracking()
                .Where(TodoQueries.GetAllNotDone(user))
                .OrderBy(x => x.Date);
        }

        public TodoItem GetById(Guid id, string user)
        {
            return _dataContext
                .Todos.AsNoTracking().Where(TodoQueries.GetById(id, user)).FirstOrDefault();

        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            return _dataContext.Todos.AsNoTracking().Where(TodoQueries.GetByPeriod(user, date, done)).OrderBy(x => x.Date);

        }

        public void Update(TodoItem todo)
        {
            _dataContext.Entry(todo).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }
    }
}
