using System.Collections.Generic;

namespace CassaMultithreading
{
    internal interface IResultWriter
    {
        void WritePerson(List<string> calculateExpressions,
            string filePath = @"..\..\Files\Result.txt");
    }
}
