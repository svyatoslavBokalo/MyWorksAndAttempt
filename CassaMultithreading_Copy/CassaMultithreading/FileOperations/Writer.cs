using CassaMultithreading.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassaMultithreading
{
    internal class Writer
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

        public Writer(string filePath)
        {
            this.filePath = filePath;
        }

        public Writer()
        {

            filePath = @"C:\Users\Lenovo\source\MyGit\MyWorksAndAttempt\CassaMultithreading\CassaMultithreading\Data\WriterData.txt";
        }

        public void WritePerson(IClient person, string filePath = @"C:\Users\Lenovo\source\MyGit\MyWorksAndAttempt\CassaMultithreading\CassaMultithreading\Data\WriterData.txt")
        {
            if (filePath == null || filePath == "") throw new FileNotFoundException();
            if (!File.Exists(filePath)) File.Create(filePath);

            using (StreamWriter sw = new(filePath, true))
            {
                    sw.WriteLine(person.ToString());
                sw.Close();
            }
        }

        public void WriteOnFile(string str)
        {
            if (filePath == null || filePath == "") throw new FileNotFoundException();
            if (!File.Exists(filePath)) File.Create(filePath);

            using (StreamWriter sw = new(filePath, true))
            {
                sw.WriteLine(str);
                sw.Close();
            }
        }
    }
}
