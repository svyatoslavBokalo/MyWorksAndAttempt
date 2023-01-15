using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassaMultithreading
{
    internal interface ICassingOperation
    {
        public void Add(ICassing cassing);
        public void Remove(ICassing cassing);
    }
}
