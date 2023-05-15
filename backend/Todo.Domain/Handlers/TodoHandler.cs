using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler
        : Notifiable<Notification>,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>,
        IHandler<MarkTodoAsNotDoneCommand>
    {
        private readonly ITodoRepository _repository;
        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateTodoCommand command)
        {
            //Fail Fast Validation
            //if (command.IsValid)
            //{
            //    return new GenericCommandResult(
            //        false,
            //        "Ops, parece que sua tarefa está errada!",
            //        command.Notifications);
            //}

            //Criar um TodoItem
            var todo = new TodoItem(command.Title, command.Date, command.User);

            //Salvar um todo no banco
            _repository.Create(todo);

            //Notificar o Usuário
            return new GenericCommandResult(true, "Tarefa salva!", todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            //Fail Fast Validation
            //if (command.IsValid)
            //{
            //    return new GenericCommandResult(
            //        false,
            //        "Ops, parece que sua tarefa está errada!",
            //        command.Notifications);
            //}
            //Recuperar TodoItem do banco:
            //Reidratação: recuperar algo do BD 
            var todo = _repository.GetById(command.Id, command.User);

            //Atualiza algo:
            todo.UpdateTitle(command.Title);

            //Sala no banco
            _repository.Update(todo);

            //Retorna o resultado:

            return new GenericCommandResult(true, "Tarefa atualizada", todo);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {

            //Fail Fast Validation
            //if (command.IsValid)
            //{
            //    return new GenericCommandResult(
            //        false,
            //        "Ops, parece que sua tarefa está errada!",
            //        command.Notifications);
            //}


            //Recuperar TodoItem do BD:
            var todo = _repository.GetById(command.Id, command.User);

            //Marcar atividade como 'Done':
            todo.MarkAsDone();

            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa marcada com 'concluída'", todo);
        }

        public ICommandResult Handle(MarkTodoAsNotDoneCommand command)
        {
            //Fail Fast Validation
            //if (command.IsValid)
            //{
            //    return new GenericCommandResult(
            //        false,
            //        "Ops, parece que sua tarefa está errada!",
            //        command.Notifications);
            //}


            //Recuperar TodoItem do BD:
            var todo = _repository.GetById(command.Id, command.User);

            //Marcar atividade como 'Done':
            todo.MarkAsNotDone();

            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa marcada com 'em aberto'", todo);
        }
    }
}
