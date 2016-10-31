using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zad2;

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

        #region Constructor tests
        [TestMethod()]
        public void TodoRepositoryNullTest()
        {
            ITodoRepository repository = new TodoRepository();
            Assert.IsNotNull(repository);
        }

        [TestMethod()]
        public void TodoRepositoryNotNullTest()
        {
            IGenericList<TodoItem> initialDbState = new GenericList<TodoItem>();
            ITodoRepository repository = new TodoRepository(initialDbState);
            Assert.IsNotNull(repository);
        }
        #endregion

        [TestMethod()]
        public void GetActiveTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            var todoItem1 = new TodoItem(" Groceries1 ");
            var todoItem2 = new TodoItem(" Groceries2 ");
            var todoItem3 = new TodoItem(" Groceries3 ");
            todoItem2.MarkAsCompleted();
            repository.Add(todoItem);
            repository.Add(todoItem1);
            repository.Add(todoItem2);
            repository.Add(todoItem3);
            List<TodoItem> list = repository.GetActive();
            foreach (var item in list)
            {
                Assert.IsTrue(item.IsCompleted == false);
            }
        }

        [TestMethod()]
        public void GetAllTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            var todoItem1 = new TodoItem(" Groceries1 ");
            var todoItem2 = new TodoItem(" Groceries2 ");
            var todoItem3 = new TodoItem(" Groceries3 ");
            todoItem2.MarkAsCompleted();
            repository.Add(todoItem);
            repository.Add(todoItem1);
            repository.Add(todoItem2);
            repository.Add(todoItem3);
            List<TodoItem> list = repository.GetAll();
            Assert.IsTrue(list.Count == 4);
        }

        [TestMethod()]
        public void GetCompletedTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            var todoItem1 = new TodoItem(" Groceries1 ");
            var todoItem2 = new TodoItem(" Groceries2 ");
            var todoItem3 = new TodoItem(" Groceries3 ");
            todoItem2.MarkAsCompleted();
            todoItem3.MarkAsCompleted();
            repository.Add(todoItem);
            repository.Add(todoItem1);
            repository.Add(todoItem2);
            repository.Add(todoItem3);
            List<TodoItem> list = repository.GetCompleted();
            foreach (var item in list)
            {
                Assert.IsTrue(item.IsCompleted);
            }
        }

        [TestMethod()]
        public void GetFilteredTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            var todoItem1 = new TodoItem(" Groceries1 ");
            var todoItem2 = new TodoItem(" Groceries2 ");
            var todoItem3 = new TodoItem(" Groceries3 ");
            todoItem2.MarkAsCompleted();
            todoItem3.MarkAsCompleted();
            repository.Add(todoItem);
            repository.Add(todoItem1);
            repository.Add(todoItem2);
            repository.Add(todoItem3);
            List<TodoItem> list = repository.GetFiltered(s => s.DateCompleted.Equals(DateTime.Now));
            foreach (var item in list)
            {
                Assert.IsTrue(item.DateCompleted.Equals(DateTime.Now));
            }
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
        [TestMethod()]
        public void UpdateExistingTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            repository.Add(todoItem);
            todoItem.Text = "Groceries2";
            repository.Update((todoItem));
            Assert.AreEqual(repository.Get(todoItem.Id).Text, todoItem.Text);
        }

        [TestMethod()]
        public void UpdateNonExistingTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            repository.Update((todoItem));
            Assert.IsTrue(repository.Contains(todoItem));
        }
        #endregion

        #region Contains tests
        [TestMethod]
        public void ContainsTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            repository.Add(todoItem);
            bool test = repository.Contains(todoItem);
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void ContainsTest1()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            TodoItem todoItem2 = new TodoItem(" Groceries2 ");
            repository.Add(todoItem);
            bool test = repository.Contains(todoItem2);
            Assert.IsTrue(test == false);
        }
        #endregion
    }
}