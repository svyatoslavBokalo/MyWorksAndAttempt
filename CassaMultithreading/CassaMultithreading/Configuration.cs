using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassaMultithreading
{
    static internal class Configuration
    {
        static public int countCasses = 3;
        static public int timeService = 1;
        //отже цей параметер для того аби описати, яка відстань буде між касами
        static public int distanceBetweenCasses = 7;
        //цей параметр для задання початкової кординати кас
        static public double startCordinate = 3.5;
    }
}
