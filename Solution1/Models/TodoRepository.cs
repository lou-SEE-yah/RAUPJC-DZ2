using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models;
using zad2;

namespace Repositories
{
    /// <summary >
    /// Class that encapsulates all the logic for accessing TodoTtems .
    /// </ summary >
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;
        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }
            // Shorter way to write this in C# using ?? operator :
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >() ;
            // x ?? y -> if x is not null , expression returns x. Else y.
        }

        

        public void Add(TodoItem todoItem)
        {
            if (todoItem == null)
            {
                throw new ArgumentNullException();
            }
            if (_inMemoryTodoDatabase.Where(s => s.Equals(todoItem)).FirstOrDefault() != null)
            {
                throw new DuplicateTodoItemException("duplicate id: {" + todoItem.Id + "}");
            }
            _inMemoryTodoDatabase.Add(todoItem);
        }

        public TodoItem Get(Guid todoId)
        {
            TodoItem item = _inMemoryTodoDatabase.Where(s => s.Id.Equals(todoId)).FirstOrDefault();
            return item;

        }

        public List<TodoItem> GetActive()
        {
            List<TodoItem> list = _inMemoryTodoDatabase.Where(s => s.IsCompleted == false).ToList();
            return list;
        }

        public List<TodoItem> GetAll()
        {
            List<TodoItem> list = _inMemoryTodoDatabase.OrderByDescending(s => s.DateCreated).ToList();
            return list;
        }

        public List<TodoItem> GetCompleted()
        {
            List<TodoItem> list = _inMemoryTodoDatabase.Where(s => s.IsCompleted == true).ToList();
            return list;
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            List<TodoItem> list = _inMemoryTodoDatabase.Where(s => filterFunction(s) == true).ToList();
            return list;
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            TodoItem item = _inMemoryTodoDatabase.Where(s => s.Id.Equals(todoId)).FirstOrDefault();
            if (item == null) return false;
            item.MarkAsCompleted();
            return true;
        }

        public bool Remove(Guid todoId)
        {
            TodoItem item = _inMemoryTodoDatabase.Where(s => s.Id.Equals(todoId)).FirstOrDefault();
            if (item == null)
                return false;
            _inMemoryTodoDatabase.Remove(item);
            return true;
        }

        public void Update(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Contains(todoItem))
            {
                var toUpdate = _inMemoryTodoDatabase.Single(x => x.Id.Equals(todoItem.Id));
                toUpdate = todoItem;
            }
            else
                _inMemoryTodoDatabase.Add(todoItem);

        }

        public bool Contains(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Contains(todoItem) == true)
            {
                return true;
            }
            return false;
        }
    }
}