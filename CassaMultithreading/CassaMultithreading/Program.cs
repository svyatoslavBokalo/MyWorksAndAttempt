// See https://aka.ms/new-console-template for more information
using CassaMultithreading;
using CassaMultithreading.Interface;
using CassaMultithreading.Person;

//Cassa cassa = new Cassa();
//cassa.Add(new Client(3));

//Station station = new Station(Configuration.countCasses);
//Generator.TestAddPeople(station, 10);
//Console.WriteLine(station.ToString());
//Console.WriteLine();

//Generator.ProcessCassas(station);

//========================================================================================================
//Reader reader = new Reader();
//List<IPerson> people = PersonParser.PeopleParse(reader);
//foreach(IPerson person in people)
//{
//    Console.WriteLine(person);
//}

//Reader reader = new Reader();
//List<IClient> clients = PersonParser.Clients_Parse(reader);
//foreach (IClient client in clients)
//{
//    Console.WriteLine(client);
//}

//========================================================================================================

//Cassa cassa = new Cassa();
//cassa.Add(new Client(3));

Station station = new Station(Configuration.countCasses);
Generator.ProcessCassas(station);