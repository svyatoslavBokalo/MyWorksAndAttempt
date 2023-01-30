using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassaMultithreading
{
    internal class Reader : IExpresionReader
    {
        private string filePath;

        public string FilePAth
        { 
            get => filePath;
            set
            {
                if (value != null) filePath = value;
            }
         }

        public Reader(string filePath)
        {
            this.filePath = filePath;
        }

        public Reader()
        {
            filePath = "..\\..\\Data\\Client.txt";
        }

        public List<string> ReadExpresion(string filePath = @"C:\Users\Lenovo\source\MyGit\MyWorksAndAttempt\CassaMultithreading\CassaMultithreading\Data\CLients.txt")
        {
            if (filePath == null || filePath == "") throw new FileNotFoundException();
            if (!File.Exists(filePath))  File.Create(filePath);

            List<string> result = new();
            using(StreamReader sr = new(filePath))
            {
                while (!sr.EndOfStream)
                {
                    result.Add(sr.ReadLine());
                }
                sr.Close();
            }

            return result;
        }
    }
}
