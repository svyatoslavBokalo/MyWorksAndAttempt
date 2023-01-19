// See https://aka.ms/new-console-template for more information
using CassaMultithreading;

//Cassa cassa = new Cassa();
//cassa.Add(new Person(3));

Station station = new Station(Configuration.countCasses);
Generator.AddPeople(station, 10);
Console.WriteLine(station.ToString());
Console.WriteLine();

Generator.ProcessCassas(station);

