using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Domain.Commands.Contracts
{
    public class CreateTodoContract: Contract<TodoItem>
    {
        //private CreateTodoCommand createTodoCommand;

        public CreateTodoContract(CreateTodoCommand todoCommand)
        {
            Requires()
                .IsNullOrEmpty(todoCommand.Title, "Title", "O campo 'Título' deve ser preenchido")
                .IsGreaterOrEqualsThan(todoCommand.Title, 4, "Title", "O campo 'Título' deve possuir ao menos 4 caracteres")
             //   .IsNullOrEmpty(todoCommand.User, "User", "O campo 'Usuário' deve ser preenchido")
                .IsGreaterOrEqualsThan(todoCommand.User, 6, "User", "O campo 'Usuário' deve possuir ao menos 6 caracteres");
               //Lembrar de trabalhar com datas depois
        }

        //public CreateTodoContract(CreateTodoCommand createTodoCommand)
        //{
        //    this.createTodoCommand = createTodoCommand;
        //}
    }
}
