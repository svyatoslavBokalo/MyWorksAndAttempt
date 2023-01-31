using CassaMultithreading.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassaMultithreading
{
    internal interface ICassing
    {
        public long Id { get; set; }
        public Thread Threading { get;  }
        bool StopCassa { get; set; }
        public void Add(IClient person);
        public IClient Remove();
        public bool IsEmpty();
        public void ThreadHandler(object data);
    }
}
