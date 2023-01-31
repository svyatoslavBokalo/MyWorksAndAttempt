using CassaMultithreading.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassaMultithreading.Person
{
    internal class Person : IPerson
    {
        private long id;
        private string? surname;
        private string? name;
        private uint age;
        private int status;
        
        public long Id { get => this.id; set => this.id = value; }
        public string? Surname { get => surname; set => surname = value; }
        public string? Name { get => name; set => name = value; }
        public uint Age { get => age; 
            set 
            {
                if (value <= 0)
                {
                    throw new InvalidDataException("age must be more than 0");
                }
                else
                {
                    age = value;
                }
            } 
        }
        public int Status { get => status;
            set 
            {
                if(value <= 0)
                {
                    throw new InvalidDataException("status must be more than 0");
                }
                status = value;
            } 
        }
        public Person()
        {
            Id = 0;
            Surname = "";
            Name = "";
            Age = int.MaxValue;
            Status = int.MaxValue;
        }
        public Person(long id, string? surname, string? name, uint age, int status)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Age = age;
            Status = status;
        }
        public Person(long id, string? surname, string? name, uint age, string? status)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Age = age;
            Status = PersonParser.StatusParse(status);
        }

        public override string? ToString()
        {
            return $"{this.Id} - {this.Surname} - {this.Name} - {this.Age} - {PersonParser.ReverseStatusParse(this.Status)}";
        }
    }
}
