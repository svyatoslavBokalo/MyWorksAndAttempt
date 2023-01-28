using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassaMultithreading
{
    internal class Person
    {
        private int countProduct;
        public Person()
        {
            countProduct = 1;
        }

        public Person(int countProduct)
        {
            this.countProduct = countProduct;
        }

        public int CountProduct { get => countProduct; }
    }
}
