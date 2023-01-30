using CassaMultithreading.Interface;
using CassaMultithreading.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CassaMultithreading
{
    internal class Generator
    {
        static public void TestAddPeople(ICassingOperation cassingOperation, int countPeople)
        {
            for(int i = 0; i < countPeople; i++)
            {
                if (cassingOperation.IsEmpty())
                {
                    foreach(ICassing cassing in cassingOperation.Cassas)
                    {
                        if (cassing.IsEmpty())
                        {
                            cassing.Add(new Client());
                        }
                    }
                }
                else
                {
                    Random random = new Random();
                    cassingOperation.GetCassa(random.Next(0, cassingOperation.Cassas.Count)).Add(new Client());
                }
            }
        }
        static public void AddPeople(object arg)
        {
            //CassingAndListClientscs cassingAndListClientscs = (CassingAndListClientscs)arg;
            ICassingOperation cassingOperation = (ICassingOperation)arg;
            Reader reader = new Reader();
            List<IClient> clients = PersonParser.Clients_Parse(reader);
            foreach (IClient client in clients)
            {
                if (cassingOperation.IsEmpty())
                {
                    foreach (ICassing cassing in cassingOperation.Cassas)
                    {
                        if (cassing.IsEmpty())
                        {
                            cassing.Add(client);
                            Console.WriteLine($"add new client in cassa {cassing.Id}");
                            Thread.Sleep(1000);
                        }
                    }
                }
                else
                {
                    Random random = new Random();
                    int number = random.Next(0, cassingOperation.Cassas.Count);
                    Console.WriteLine($"add new client in cassa {number}");
                    cassingOperation.GetCassa(number).Add(client);
                    Thread.Sleep(1000);
                }
            }
        }
        //public void AddPeople(ICassingOperation cassingOperation, List<IClient> clients)
        //{
        //    foreach(IClient client in clients)
        //    {
        //        if (cassingOperation.IsEmpty())
        //        {
        //            foreach (ICassing cassing in cassingOperation.Cassas)
        //            {
        //                if (cassing.IsEmpty())
        //                {
        //                    cassing.Add(client);
        //                    Console.WriteLine($"add new client in cassa {cassing.Id}");
        //                    Thread.Sleep(1000);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            Random random = new Random();
        //            int number = random.Next(0, cassingOperation.Cassas.Count);
        //            Console.WriteLine($"add new client in cassa {number}");
        //            cassingOperation.GetCassa(number).Add(client);
        //            Thread.Sleep(1000);
        //        }
        //    }
        //}                                                      
        static public void ProcessCassas(ICassingOperation cassingOperation)
        {
            //Thread[] threads = new Thread[cassingOperation.Cassas.Count];
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


            //for (int i = 0; i< cassingOperation.Cassas.Count; i++)
            //{
            //    threads[i] = cassingOperation.GetCassa(i).Threading;
            //    threads[i].Start(cassingOperation.GetCassa(i));
            //    threads[i].Join();
            //}
            Thread thread = new Thread(new ParameterizedThreadStart(AddPeople));
            thread.Start(cassingOperation);
            
            foreach(ICassing cassing in cassingOperation.Cassas)
            {
                Thread.Sleep((Configuration.countCasses+1)*1000);
                cassing.Threading.Start();
            }
        }
    }
}
