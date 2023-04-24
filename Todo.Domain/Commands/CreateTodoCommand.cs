using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class CreateTodoCommand : Notifiable<Notification>, ICommand
    {

        public CreateTodoCommand()
        {

        }

        public CreateTodoCommand(string title, DateTime date, string user)
        {
            Title = title;
            Date = date;
            User = user;
            AddNotifications(new CreateTodoContract(this));
        }

        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; }

    }
}
