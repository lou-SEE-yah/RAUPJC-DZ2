using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Tests
{
    [TestClass]
    public class TodoRepositoryTests
    {
        #region Add tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingNullToDatabaseThrowsException()
        {
            ITodoRepository repository = new TodoRepository();
            repository.Add(null);
        }

        [TestMethod]
        public void AddingItemWillAddToDatabase()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            repository.Add(todoItem);
            Assert.AreEqual(1, repository.GetAll().Count);
            Assert.IsTrue(repository.Get(todoItem.Id) != null);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateTodoItemException))]
        public void AddingExistingItemWillThrowException()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            repository.Add(todoItem);
            repository.Add(todoItem);
        }
        #endregion

        #region Get tests
        [TestMethod]
        public void GetExistingItemTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            repository.Add(todoItem);
            TodoItem getItem = repository.Get(todoItem.Id);
            Assert.IsTrue(todoItem.Equals(getItem));
        }

        [TestMethod]
        public void GetNonExistingItemTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            var todoItem2 = new TodoItem(" Groceries2 ");
            repository.Add(todoItem);
            TodoItem getItem = repository.Get(todoItem2.Id);
            Assert.IsTrue(getItem == null); ;
        }
        #endregion

        [TestMethod()]
        public void TodoRepositoryTest()
        {
            Assert.Fail();
        }


        [TestMethod()]
        public void GetActiveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCompletedTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetFilteredTest()
        {
            Assert.Fail();
        }

        #region Mark as completed tests
        [TestMethod()]
        public void MarkAsCompletedExistingTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            repository.Add(todoItem);
            bool test = repository.MarkAsCompleted(todoItem.Id);
            Assert.IsTrue((test == true));
        }

        [TestMethod()]
        public void MarkAsCompletedOnAlreadyCompletedTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            todoItem.IsCompleted = true;
            repository.Add(todoItem);
            bool test = repository.MarkAsCompleted(todoItem.Id);
            Assert.IsTrue((test == true));
        }

        [TestMethod()]
        public void MarkAsCompletedNonExistingTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            var todoItem2 = new TodoItem(" Groceries2 ");
            repository.Add(todoItem);
            bool test = repository.MarkAsCompleted(todoItem2.Id);
            Assert.IsTrue((test == false));
        }
        #endregion

        #region Remove tests
        [TestMethod()]
        public void RemoveExistingTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            repository.Add(todoItem);
            bool removed = repository.Remove(todoItem.Id);
            Assert.IsTrue((removed == true));
            Assert.AreEqual(0, repository.GetAll().Count);
        }

        [TestMethod()]
        public void RemoveNonExistingTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            var todoItem2 = new TodoItem(" Groceries2 ");
            repository.Add(todoItem);
            bool removed = repository.Remove(todoItem2.Id);
            Assert.IsTrue((removed == false));
            Assert.AreEqual(1, repository.GetAll().Count);
        }
        #endregion

        #region Update tests
        //ne radi
        [TestMethod()]
        public void UpdateTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            repository.Add(todoItem);
            todoItem.Text = "Groceries2";
            repository.Update((todoItem));
            Assert.Equals(repository.Get(todoItem.Id).Text, todoItem.Text);
        }
        #endregion

        [TestMethod()]
        public void ContainsTest()
        {
            TodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            repository.Add(todoItem);
            bool test = repository.Contains(todoItem);
            Assert.IsTrue(test == true);
        }

        [TestMethod()]
        public void ContainsTest1()
        {
            TodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            var todoItem2 = new TodoItem(" Groceries2 ");
            repository.Add(todoItem);
            bool test = repository.Contains(todoItem2);
            Assert.IsTrue(test == false);
        }
    }
}