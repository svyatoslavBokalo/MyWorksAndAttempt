using CassaMultithreading.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassaMultithreading.Person
{
    internal class PersonParser
    {
        // this method parser for status of person
        // example: if person is a soldier so his or her status be number 6
        // example: if person is a veteran so his or her status be number 1
        static public int StatusParse(string status)
        {
            int res = -1;
            status = status.Trim();
            switch (status)
            {
                case "veteran":
                    { 
                        res = 1; 
                    }
                    break;
                case "cripple":
                    { 
                        res = 2; 
                    }
                    break;
                case "elderly":
                    { 
                        res = 3; 
                    }
                    break;
                case "soldier":
                    {
                        res = 4;
                    }
                    break;
                default:
                    res = 5;
                    break;
            }
            return res;
        }

        //this method convert my status: int to status:string
        static public string ReverseStatusParse(int status)
        {
            string res = "";
            switch (status)
            {
                case 1:
                    {
                        res = "veteran";
                    }
                    break;
                case 2:
                    {
                        res = "cripple";
                    }
                    break;
                case 3:
                    {
                        res = "elderly";
                    }
                    break;
                case 4:
                    {
                        res = "soldier";
                    }
                    break;
                default:
                    res = "all";
                    break;
            }
            return res;
        }

        static public IPerson PersonParse(string line)
        {
            IPerson person = new Person();
            string[] mas = line.Split(",");
            person.Id = long.Parse(mas[0]);
            person.Surname = mas[1];
            person.Name = mas[2];
            person.Age = uint.Parse(mas[3]);
            person.Status = StatusParse(mas[4]);
            return person;
        }

        

        static public List<IPerson> PeopleParse(List<string> reader)
        {
            List<IPerson> persons = new List<IPerson>();
            foreach(string line in reader)
            {
                persons.Add(PersonParse(line));
            }
            return persons;
        }

        static public List<IPerson> PeopleParse(Reader reader)
        {
            List<IPerson> persons = new List<IPerson>();
            List<string> lstPeople = reader.ReadExpresion(@"C:\Users\Lenovo\source\MyGit\MyWorksAndAttempt\CassaMultithreading\CassaMultithreading\Data\People.txt");
            foreach (string line in lstPeople)
            {
                persons.Add(PersonParse(line));
            }
            return persons;
        }

        static public IClient ClientParse(string line)
        {
            IClient client = new Client();
            string[] mas = line.Split(",");
            client.Id = long.Parse(mas[0]);
            client.Surname = mas[1];
            client.Name = mas[2];
            client.Age = uint.Parse(mas[3]);
            client.Status = StatusParse(mas[4]);
            client.CountProduct = int.Parse(mas[5]);
            return client;
        }

        static public List<IClient> Clients_Parse(List<string> reader)
        {
            List<IClient> clients = new List<IClient>();
            foreach (string line in reader)
            {
                clients.Add(ClientParse(line));
            }
            return clients;
        }

        static public List<IClient> Clients_Parse(Reader reader)
        {
            List<IClient> clients = new List<IClient>();
            List<string> lstClients = reader.ReadExpresion();
            foreach (string line in lstClients)
            {
                clients.Add(ClientParse(line));
            }
            return clients;
        }
    }
}
