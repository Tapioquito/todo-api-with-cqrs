using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.API.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    [Authorize]
    public class TodoController : ControllerBase
    {


        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll(
            [FromServices] ITodoRepository repository
            )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetAll(user);
        }
        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone(
            [FromServices] ITodoRepository repository
            )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

            return repository.GetAllDone(user);
        }

        [Route("notdone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllNotDone(
            [FromServices] ITodoRepository repository
            )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetAllNotDone(user);
        }
        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForToday(
                    [FromServices] ITodoRepository repository
                    )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetByPeriod(user, DateTime.Now.Date, true);
        }

        [Route("notdone/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetNotDoneForToday(
            [FromServices] ITodoRepository repository
            )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetByPeriod(user, DateTime.Now.Date, false);
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForTomorrow(
            [FromServices] ITodoRepository repository
            )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), true);
        }


        [Route("notdone/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetNotDoneForTomorrow(
            [FromServices] ITodoRepository repository
            )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), false);
        }


        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CreateTodoCommand command,
            [FromServices] TodoHandler handler

            )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

            command.User = user;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
            [FromBody] UpdateTodoCommand command,
            [FromServices] TodoHandler handler

            )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

            command.User = user;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-done")]
        [HttpPost]
        public GenericCommandResult MarkAsDone(
            [FromBody] MarkTodoAsDoneCommand command,
            [FromServices] TodoHandler handler

            )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

            command.User = user;

            return (GenericCommandResult)handler.Handle(command);
        }
        [Route("mark-as-not-done")]
        [HttpPost]
        public GenericCommandResult MarkAsNotDone(
           [FromBody] MarkTodoAsNotDoneCommand command,
           [FromServices] TodoHandler handler

           )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

            command.User = user;

            return (GenericCommandResult)handler.Handle(command);
        }

    }
}
