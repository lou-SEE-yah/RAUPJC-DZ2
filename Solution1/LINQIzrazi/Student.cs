using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQIzrazi
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }

        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public static bool operator ==(Student student1, Student student2)
        {
            if (object.ReferenceEquals(student1, null) || object.ReferenceEquals(student2, null))
                return false;
            return student1.Equals(student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            if (object.ReferenceEquals(student1, null) || object.ReferenceEquals(student2, null))
                return false;
            return !student1.Equals(student2);
        }

        public override bool Equals(object obj)
        {
            var student = obj as Student;
            if (object.ReferenceEquals(student, null))
                return false;
            if (this.Jmbag.Equals(student.Jmbag))
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return this.Jmbag.GetHashCode();
        }

        /*public override string ToString()
        {
            return Jmbag.ToString() + "-" + Name.ToString();
        }*/
    }

    public enum Gender
    {
        Male, Female
    }
}
