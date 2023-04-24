using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Domain.Commands.Contracts
{
    public class UpdateTodoContract : Contract<TodoItem>
    {
        public UpdateTodoContract(UpdateTodoCommand todoCommand)
        {
            Requires()
                .IsGreaterOrEqualsThan(todoCommand.Title, 6, "Title", "O campo 'Título' deve possuir ao menos 6 caracteres")
                .IsGreaterOrEqualsThan(todoCommand.User, 6, "User", "O campo 'Usuário' deve possuir ao menos 6 caracteres");
        }
    }
}
