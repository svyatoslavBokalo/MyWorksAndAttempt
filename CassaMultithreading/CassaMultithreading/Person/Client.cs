using CassaMultithreading.Interface;
using CassaMultithreading.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CassaMultithreading
{
    internal class Client: Person.Person, IClient
    {
        private int countProduct;
        private double timeCordinate;
        #region constructure
        public Client(): base()
        {
            CountProduct = 1;

        }

        public Client(int countProduct): base()
        {
            this.CountProduct = countProduct;
        }
        public Client(long id, string? surname, string? name, uint age, int status, int countProduct) : base(id, surname, name, age, status)
        {
            this.CountProduct = countProduct;
        }
        public Client(long id, string? surname, string? name, uint age, string? status,int countProduct) : base(id, surname, name, age, status)
        {
            this.CountProduct = countProduct;
        }
        public Client(long id, string? surname, string? name, uint age, string? status, int countProduct, double _timeCordinate) : base(id, surname, name, age, status)
        {
            this.CountProduct = countProduct;
            this.timeCordinate = _timeCordinate;
        }
        #endregion
        public int CountProduct { get => countProduct; 
            set
            {
                if (value < 0)
                {
                    throw new InvalidDataException("count product must be more than 0");
                }
                countProduct = value;
            }
        }

        public double TimeCordinate { get =>this.timeCordinate; set => this.timeCordinate=value; }

        public override string? ToString()
        {
            return $"{this.Id} - {this.Surname} - {this.Name} - {this.Age} - {PersonParser.ReverseStatusParse(this.Status)} - {this.CountProduct}";
        }
    }
}
