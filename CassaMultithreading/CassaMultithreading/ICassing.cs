using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassaMultithreading
{
    internal interface ICassing
    {
        public Thread Threading { get; set; }
        bool StopCassa { get; set; }
        public void Add(Person person);
        public Person Remove();
        public bool IsEmpty();
        public void ThreadHandler(object data);
    }
}
