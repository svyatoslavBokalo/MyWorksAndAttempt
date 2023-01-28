using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassaMultithreading
{
    internal class Cassa: ICassing
    {
        private long id;
        private Queue<Person> persons;
        private Thread thread;
        private bool stopCassa;

        public Cassa()
        {
            this.persons = new Queue<Person>();
            this.thread = new Thread(new ParameterizedThreadStart(ThreadHandler));
            this.stopCassa = false;
        }

        public Cassa(long _id)
        {
            this.id = _id;
            this.persons = new Queue<Person>();
            this.thread = new Thread(new ParameterizedThreadStart(ThreadHandler));
            this.stopCassa = false;
        }

        public bool StopCassa { get => stopCassa; set => stopCassa = value; }
        public Thread Threading { get => thread;  }
        public long Id { get => this.id; set => this.id = value; }

        public void ThreadHandler(object data)
        {

            while (!stopCassa)
            {
                //Console.WriteLine("it's while()");
                if (persons.Count>0)
                {
                    Person person = persons.Dequeue();
                    Thread.Sleep(Configuration.timeService * person.CountProduct * 1000);
                    //Thread.Sleep(1000);
                    Console.WriteLine($"serviced!!!!!!! by {this.id} cassa");
                }
                else
                {
                    Console.WriteLine("all customers are served!!!");
                    stopCassa=true;
                }
            }
        }

        public void Add(Person person)
        {
            persons.Enqueue(person);
        }

        public Person Remove()
        {
            return persons.Dequeue();
        }

        public bool IsEmpty()
        {
            if (persons.Count <= 0)
            {
                return true;
            }
            return false;
        }

        public override string? ToString()
        {
            return $"cassa have {persons.Count} clients";
        }
    }
}
