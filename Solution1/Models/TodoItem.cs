using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DateCompleted { get; set; }
        public DateTime DateCreated { get; set; }

        public TodoItem(string text)
        {
            Id = Guid.NewGuid(); // Generates new unique identifier
            Text = text;
            IsCompleted = false;
            DateCreated = DateTime.Now; // Set creation date as current time
        }

        public void MarkAsCompleted()
        {
            if (!IsCompleted)
            {
                IsCompleted = true;
                DateCompleted = DateTime.Now;
            }
        }

        public override bool Equals(object obj)
        {
            var item = obj as TodoItem;
            if (item == null) return false;
            if (this.Id.Equals(item.Id))
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
