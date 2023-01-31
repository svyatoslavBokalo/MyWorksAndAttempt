using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassaMultithreading.Interface
{
    internal interface IPerson
    {
        public long Id { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public uint Age { get; set; }
        public int Status { get; set; }
    }
}
