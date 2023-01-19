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

        public Station(int countCassas)
        {
            this.cassas = new List<ICassing>();

            for (int i = 0; i < countCassas; i++)
            {
                this.cassas.Add(new Cassa());
            }
        }

        public Station(List<ICassing> cassings)
        {
            this.cassas = new List<ICassing>();
            for (int i = 0; i < cassings.Count; i++)
            {
                this.cassas.Add(cassings[i]);
            }
        }

        public List<ICassing> Cassas
        {
            get
            {
                return this.cassas;
            }
        }

        public void Add(ICassing cassing)
        {
            this.cassas.Add(cassing);
        }

        public ICassing GetCassa(int numberOfCassa)
        {
            return cassas[numberOfCassa];
        }

        public bool IsEmpty()
        {
            foreach(ICassing cassing in this.cassas)
            {
                if (cassing.IsEmpty())
                {
                    return true;
                }
            }
            return false;
        }

        public void Remove(ICassing cassing)
        {
            this.cassas.Remove(cassing);
        }

        public override string? ToString()
        {
            string res = "";
            int k = 1;
            foreach(ICassing cassing in this.cassas)
            {
                res += k + ": " + cassing.ToString() +"\n";
                k++;
            }
            return res;
        }
    }
}
