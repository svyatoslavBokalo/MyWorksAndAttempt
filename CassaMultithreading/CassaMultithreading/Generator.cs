using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassaMultithreading
{
    internal class Generator
    {
        static public void AddPeople(ICassingOperation cassingOperation, int countPeople)
        {
            for(int i = 0; i < countPeople; i++)
            {
                if (cassingOperation.IsEmpty())
                {
                    foreach(ICassing cassing in cassingOperation.Cassas)
                    {
                        if (cassing.IsEmpty())
                        {
                            cassing.Add(new Person());
                        }
                    }
                }
                else
                {
                    Random random = new Random();
                    cassingOperation.GetCassa(random.Next(0, cassingOperation.Cassas.Count)).Add(new Person());
                }
            }
        }

        static public void ProcessCassas(ICassingOperation cassingOperation)
        {
            Thread[] threads = new Thread[cassingOperation.Cassas.Count];
            //for (int i = 0; i < n * m / countThread; i++)
            //{
            //    for (int j = 0; j < countThread; j++)
            //    {
            //        threads[j] = new Thread(new ParameterizedThreadStart(ThreadExample.ThreadProc));
            //        threads[j].Start(myMatrix[i * countThread + j]);
            //        threads[j].Join();
            //    }
            //}
            //for(int i = 0; i<countThread; i++)
            //{
            //    threads[i] = new Thread(new ParameterizedThreadStart(ThreadExample.ThreadProc));
            //    myDatas[i] = new MyData(mas, i * countElement, countElement);
            //    threads[i].Start(myDatas[i]);
            //    threads[i].Join();
            //}


            for (int i = 0; i< cassingOperation.Cassas.Count; i++)
            {
                threads[i] = cassingOperation.GetCassa(i).Threading;
                threads[i].Start(cassingOperation.GetCassa(i));
                threads[i].Join();
            }
        }
    }
}
