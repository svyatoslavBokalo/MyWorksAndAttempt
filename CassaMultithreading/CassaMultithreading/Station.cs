using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CassaMultithreading
{
    internal class Station: ICassingOperation
    {
        private List<ICassing> cassas;
        #region constructre
        public Station()
        {
            this.cassas = new List<ICassing>();
            NumericOfCasses();
            GeneradeCordinate(0);
        }

        public Station(int countCassas)
        {
            this.cassas = new List<ICassing>();

            for (int i = 0; i < countCassas; i++)
            {
                this.cassas.Add(new Cassa());
            }
            NumericOfCasses();
            GeneradeCordinate(0);
        }

        public Station(int countCassas, double startCordinateCassa)
        {
            this.cassas = new List<ICassing>();

            for (int i = 0; i < countCassas; i++)
            {
                this.cassas.Add(new Cassa());
            }
            NumericOfCasses();
            GeneradeCordinate(startCordinateCassa);
        }

        public Station(List<ICassing> cassings)
        {
            this.cassas = new List<ICassing>();
            for (int i = 0; i < cassings.Count; i++)
            {
                this.cassas.Add(cassings[i]);
            }
            NumericOfCasses();
        }
        #endregion
        private void NumericOfCasses()
        {
            int k = 1;
            foreach (ICassing cassing in cassas)
            {
                cassing.Id = k;
                k++;
            }
        }
        private void GeneradeCordinate(double startCordinateCassa)
        {
            for(int i = 0; i < cassas.Count; i++)
            {
                cassas[i].Cordinate = startCordinateCassa + Configuration.distanceBetweenCasses * i;
            }
        }

        public List<ICassing> Cassas
        {
            get
            {
                return this.cassas;
            }
        }
        //дописати, ще треба додавати id каси
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
        public bool AllEmpty()
        {
            foreach(ICassing cassing in this.cassas)
            {
                if (cassing.IsEmpty() == false)
                {
                    return false;
                }
            }
            return true;
        }
        //дописати, ще треба додавати id каси 
        public void Remove(ICassing cassing)
        {
            this.cassas.Remove(cassing);
        }
        public (double, double) DistanceForCasses()
        {
            //(double, double) res;
            //List<double> cordinateOfCasses = new List<double>();
            //foreach(ICassing cassing in cassas)
            //{
            //    cordinateOfCasses.Add(cassing.Cordinate);
            //}
            double min = cassas.Min(el => el.Cordinate);
            double max = cassas.Max(el => el.Cordinate);
            return (min - Configuration.distanceBetweenCasses, max + Configuration.distanceBetweenCasses);
        }
        public ICassing GetEmptyCassa()
        {
            ICassing cassa = null;
            foreach (ICassing cassing in this.cassas)
            {
                if (cassing.IsEmpty())
                {
                    return cassing;
                }
            }
            if(cassa == null)
            {
                throw new InvalidDataException("not exists element of ICassing");
            }
            return cassa;
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
