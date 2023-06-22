

using System.Text.RegularExpressions;

namespace LearningTesting
{
    public class Person
    {
        public Person() { }
        private string lastName;

        public Person(int id, string name, string lastName, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.lastName = lastName;
        }

        private int id;
        public int Id
        {
            get => id;
            set
            {
                if (value < 0)
                    throw new ArgumentException("ID can not be less than zero!");
                id = value;
            }
        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                if (Regex.IsMatch(value, @"[0-9]"))
                    throw new InvalidOperationException("Name can not contain the number");
                name = value;
            }
        }
        public int Age { get; set; }
    }

    public class Children : Person 
    { 
        public Children() { }

        public Children(int id, string name,string lastName, int age, int schoolId) : base(id, name,lastName, age) 
        {
           this.Id = id;
           this.Name = name;
           this.Age = age;
           this.SchoolId = schoolId;
        }

        public int SchoolId { get;set; }
    }
}
