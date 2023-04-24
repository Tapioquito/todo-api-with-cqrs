using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class MarkTodoAsNotDoneCommand: Notifiable<Notification>,ICommand
    {
        public MarkTodoAsNotDoneCommand()
        {
            
        }

        public MarkTodoAsNotDoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;
            AddNotifications(new MarkTodoAsNotDoneContract(this));
        }

        public Guid Id { get; set; }
        public string User { get; set; }
    }
}
