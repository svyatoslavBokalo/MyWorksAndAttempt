using CassaMultithreading.Interface;
using CassaMultithreading.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
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
        //static public void AddPeople(object arg)
        //{
        //    //CassingAndListClientscs cassingAndListClientscs = (CassingAndListClientscs)arg;
        //    ICassingOperation cassingOperation = (ICassingOperation)arg;
        //    Reader reader = new Reader();
        //    List<IClient> clients = PersonParser.Clients_Parse(reader);

        //    foreach (IClient client in clients)
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

        static public void AddPeople(object arg)
        {
            ICassingOperation cassingOperation = (ICassingOperation)arg;
            Reader reader = new Reader();
            List<IClient> clients = PersonParser.Clients_Parse(reader);

            foreach (IClient client in clients)
            {
                //тут я додаватиму координати клієнтам
                client.TimeCordinate = RandomGenerationCordinate(cassingOperation.DistanceForCasses().Item1, cassingOperation.DistanceForCasses().Item2);
                long cassa_id;
                if(cassingOperation.AllEmpty())
                {
                    //Console.WriteLine(GetIDCasses(cassingOperation, client.TimeCordinate));
                    cassa_id = cassingOperation.GetCassa((int)GetIDCasses(cassingOperation, client.TimeCordinate) -1).Id;
                    cassingOperation.GetCassa((int)GetIDCasses(cassingOperation, client.TimeCordinate)-1).Add(client);
                    Console.WriteLine($"add new client in cassa {cassingOperation.GetCassa((int)GetIDCasses(cassingOperation, client.TimeCordinate)-1).Id}|| cordinate = {client.TimeCordinate}");
                    Thread.Sleep(1000);
                }
                else
                {
                    if (cassingOperation.IsEmpty())
                    {
                        ICassing cassa = cassingOperation.GetEmptyCassa();
                        cassingOperation.GetEmptyCassa().Add(client);
                        Console.WriteLine($"add new client in cassa {cassa.Id}|| cordinate = {client.TimeCordinate}");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        cassa_id = cassingOperation.GetCassa((int)GetIDCasses(cassingOperation, client.TimeCordinate)-1).Id;
                        cassingOperation.GetCassa((int)GetIDCasses(cassingOperation, client.TimeCordinate) - 1).Add(client);
                        Console.WriteLine($"add new client in cassa {cassingOperation.GetCassa((int)GetIDCasses(cassingOperation, client.TimeCordinate)-1).Id}|| cordinate = {client.TimeCordinate}");
                        Thread.Sleep(1000);
                    }
                }
            }
        }

        static public double RandomGenerationCordinate(double start, double end)
        {
            Random random = new Random();
            return random.Next((int)start, (int)end) + Math.Round(random.NextDouble(), 3);
        }
        //цей метод для вибрання найближчої каси
        static public long GetIDCasses(ICassingOperation cassingOperation, double cordinate)
        {
            long cassa_id = 0;
            double minDistance = double.MaxValue;
            foreach(ICassing cassing in cassingOperation.Cassas)
            {
                if(Math.Abs(cassing.Cordinate - cordinate) < minDistance)
                {
                    minDistance = Math.Abs(cassing.Cordinate - cordinate);
                    cassa_id = cassing.Id;
                }
            }
            return cassa_id;
        }

        static public void ProcessCassas(ICassingOperation cassingOperation)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(AddPeople));
            thread.Start(cassingOperation);
            Thread.Sleep((Configuration.countCasses +1) * 1000);

            // доробити потоки для кас, зробити так аби обробка всіх кас йшла одночасно, а не поки одна закінчить
            foreach (ICassing cassing in cassingOperation.Cassas)
            {
                cassing.Threading.Start();
            }
        }
    }
}
