using CassaMultithreading.Interface;
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
        private Queue<IClient> persons;
        private Thread thread;
        private bool stopCassa;
        private double cordinate;

        #region constructre
        public Cassa()
        {
            this.persons = new Queue<IClient>();
            this.thread = new Thread(new ParameterizedThreadStart(ThreadHandler));
            this.stopCassa = false;
            this.cordinate = 0;
    }

        public Cassa(long _id)
        {
            this.id = _id;
            this.persons = new Queue<IClient>();
            this.thread = new Thread(new ParameterizedThreadStart(ThreadHandler));
            this.stopCassa = false;
            this.cordinate = 0;
        }

        public Cassa(long _id, double _cordinate)
        {
            this.id = _id;
            this.persons = new Queue<IClient>();
            this.thread = new Thread(new ParameterizedThreadStart(ThreadHandler));
            this.stopCassa = false;
            this.cordinate = _cordinate;
        }

        //public Cassa(long _id,  double _pointX, double _pointY)
        //{
        //    this.id = _id;
        //    this.persons = new Queue<IClient>();
        //    this.thread = new Thread(new ParameterizedThreadStart(ThreadHandler));
        //    this.stopCassa = false;
        //    this.cordinate = (_pointX, _pointY);
        //}
        #endregion

        #region prop
        public bool StopCassa { get => stopCassa; set => stopCassa = value; }
        public Thread Threading { get => thread;  }
        public long Id { get => this.id; set => this.id = value; }
        public double Cordinate { get => this.cordinate; set => this.cordinate = value; }

        #endregion
        public void ThreadHandler(object data)
        {

            while (!stopCassa)
            {
                //Console.WriteLine("it's while()");
                if (persons.Count>0)
                {
                    IClient person = persons.Dequeue();
                    Thread.Sleep(Configuration.timeService * person.CountProduct * 1000);
                    //Thread.Sleep(1000);
                    Console.WriteLine($"serviced!!!!!!! by {this.id} cassa|| cordinate = {this.Cordinate} \t\t {person.ToString()}");
                }
                else
                {
                    Console.WriteLine($"all customers are served!!! - {this.Id}|| cordinate = {this.Cordinate}");
                    stopCassa=true;
                }
            }
        }

        public void Add(IClient person)
        {
            persons.Enqueue(person);
        }

        public IClient Remove()
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
