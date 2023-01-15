using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassaMultithreading
{
    internal class Station: ICassingOperation
    {
        private List<ICassing> cassas;

        public Station()
        {
            this.cassas = new List<ICassing>();
        }

        public Station(List<ICassing> cassings)
        {
            this.cassas = new List<ICassing>();
            for (int i = 0; i < cassings.Count; i++)
            {
                this.cassas.Add(cassings[i]);
            }
        }

        public void Add(ICassing cassing)
        {
            this.cassas.Add(cassing);
        }

        public void Remove(ICassing cassing)
        {
            this.cassas.Remove(cassing);
        }
    }
}
