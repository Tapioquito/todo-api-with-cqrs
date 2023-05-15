using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Domain.Commands.Contracts
{
    public class MarkTodoAsNotDoneContract : Contract<TodoItem>
    {
       // private MarkTodoAsNotDoneCommand markTodoAsNotDoneCommand;

        public MarkTodoAsNotDoneContract(MarkTodoAsNotDoneCommand todoCommand)
        {
            Requires()
                .IsEmpty(todoCommand.Id, "Id", "Nao foi informado Id")
               //.IsTrue(todoItem.Done, "Done", "A atividade precisa ser marcada como 'concluída'");
               .IsGreaterOrEqualsThan(todoCommand.User, 6, "User", "O campo 'Usuário' deve possuir ao menos 6 caracteres");
        }

        //public MarkTodoAsNotDoneContract(MarkTodoAsNotDoneCommand markTodoAsNotDoneCommand)
        //{
        //    this.markTodoAsNotDoneCommand = markTodoAsNotDoneCommand;
        //}
    }
}
