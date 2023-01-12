using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassaMultithreading
{
    internal class Cassa: ICassing
    {
        private Queue<Person> persons;
        private Thread thread;
        private bool stopCassa;

        public Cassa()
        {
            this.persons = new Queue<Person>();
            this.thread = new Thread(new ParameterizedThreadStart(ThreadHandler));
            this.stopCassa = false;
        }

        public bool StopCassa { get => stopCassa; set => stopCassa = value; }

        private void ThreadHandler(object data)
        {
            while (!stopCassa)
            {
                if (persons.Count>0)
                {
                    Person person = persons.Dequeue();
                    Thread.Sleep(Configuration.timeService*person.CountProduct * 1000);
                    Console.WriteLine("serviced!!!!!!!");
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
    }
}
