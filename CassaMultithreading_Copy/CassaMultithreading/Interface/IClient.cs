using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassaMultithreading.Interface
{
    internal interface IClient: IPerson
    {
        public int CountProduct { get; set; }
    }
}
