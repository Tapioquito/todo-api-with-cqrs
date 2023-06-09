﻿using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateTodoCommandTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", DateTime.Now, "");
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Título Tarefa", DateTime.Now, "tapioquito");
        public CreateTodoCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }


        [TestMethod]
        public void Dado_comando_invalido()
        {



            Assert.AreEqual(_invalidCommand.IsValid, false);

        }

        [TestMethod]
        public void Dado_comando_valido()
        {
            // var command = new CreateTodoCommand("Título Tarefa", DateTime.Now, "tapioquito");

            Assert.AreEqual(_validCommand.IsValid, false);
        }
    }
}
