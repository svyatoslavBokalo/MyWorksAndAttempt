using System;
using System.IO;

namespace MultithreadingFirst
{
    public class MyData
    {
        public int a, b;
        public int[] mas;
        public int startIndex;
        public int count;
        public int sum;

        public MyData(int[] mas, int startIndex, int count)
        {
            this.mas = mas;
            this.startIndex = startIndex;
            this.count = count;
            this.sum = 0;
        }
    }

    public class Parametr
    {
        public double[,] matr;
        public double sum;
        public int startRow;
        public int endRow;
        public int startColumn;
        public int endColumn;

        public Parametr(double[,] matr, int startRow, int endRow, int startColumn, int endColumn)
        {
            this.matr = matr;
            this.startRow = startRow;
            this.startColumn = startColumn;
            this.endRow = endRow;
            this.endColumn = endColumn;
        }
    }

    public class ThreadExample
    {
        public int sum;
        public ThreadExample()
        {
            this.sum = 0;
        }
        // The ThreadProc method is called when the thread starts.
        // It loops ten times, writing to the console and yielding
        // the rest of its time slice each time, and then ends.
        public static void ThreadProc(object data)
        {
            //MyData data1 = (MyData)data;
            //for (int i = data1.startIndex; i < data1.startIndex+data1.count; i++)
            //{
            //    data1.sum += data1.mas[i];
            //    //Thread.Sleep(2000);
            //}
            //data = data1;

            Matrix data1 = (Matrix)data;
            for(int i = data1.startRow; i < data1.endRow; i++)
            {
                for(int j = data1.startColumn; j < data1.endColumn; j++)
                {
                    data1.sum += data1[i, j];
                }
            }
            data = data1;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double[,] matr = new double[12, 12];
            Random rnd = new Random();
            for(int i = 0; i < 12; i++)
            {
                for(int j = 0; j < 12; j++)
                {
                    matr[i, j] = rnd.Next(-10, 10);
                }
            }

            Matrix matrix = new Matrix(matr);
            matrix.Show();
            double sum1 = 0;
            for (int i = 0; i < matrix.RowCount/2; i++)
            {
                for(int j = 0; j < matrix.ColumnCount/2; j++)
                {
                    sum1 += matrix[i, j];
                }
                
            }

            double sum2 = 0;
            for (int i = 0; i < matrix.RowCount/2; i++)
            {
                for (int j = matrix.ColumnCount / 2; j < matrix.ColumnCount; j++)
                {
                    sum2 += matrix[i, j];
                }

            }

            double sum3 = 0;
            for (int i = matrix.RowCount / 2; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColumnCount / 2; j++)
                {
                    sum3 += matrix[i, j];
                }

            }

            double sum4 = 0;
            for (int i = matrix.RowCount / 2; i < matrix.RowCount; i++)
            {
                for (int j = matrix.ColumnCount / 2; j < matrix.ColumnCount; j++)
                {
                    sum4 += matrix[i, j];
                }

            }
            Console.WriteLine($"sum1 = {sum1} \t sum2 = {sum2} \t sum3 = {sum3} \t sum4 = {sum4} \n sum = {sum1 + sum2 + sum3 + sum4}");

            int n = 6;
            int m = 6;
            int countThread = 2;
            int countElementForRow = matrix.RowCount/ (n);
            int countElementForColumn = matrix.ColumnCount / (m);

            
            Matrix[] myMatrix = new Matrix[n*m];
            int k = 0;
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    myMatrix[k] = new Matrix(matr, i*countElementForRow, i * countElementForRow+countElementForRow,
                        j*countElementForColumn, j * countElementForColumn + countElementForColumn);
                    k++;
                }
            }

            Thread[] threads = new Thread[countThread];
            for (int i = 0; i < n*m/countThread; i++)
            {
                for(int j = 0; j < countThread; j++)
                {
                    threads[j] = new Thread(new ParameterizedThreadStart(ThreadExample.ThreadProc));
                    threads[j].Start(myMatrix[i*countThread+j]);
                    threads[j].Join();
                }
            }

            double allSum = 0;
            foreach(Matrix el in myMatrix)
            {
                allSum += el.sum;
                Console.WriteLine("sum = " + el.sum);
            }
            Console.WriteLine("all sum = " + allSum.ToString());


            




            //foreach(MyData data in myDatas)
            //{
            //    Console.WriteLine("sum = " + data.sum);
            //}
            //int[] mas = new int[10];
            //Random rnd = new Random();
            //for (int i = 0; i < mas.Length; i++)
            //{
            //    mas[i] = rnd.Next(-100, 100);
            //}
            //int sum1 = 0;
            //for (int i = 0; i < mas.Length / 2; i++)
            //{
            //    sum1 += mas[i];
            //}
            //int sum2 = 0;
            //for (int i = mas.Length / 2; i < mas.Length; i++)
            //{
            //    sum2 += mas[i];
            //}
            //Console.WriteLine($"sum1 = {sum1} \t sum2 = {sum2} \t\t sum = {sum1 + sum2}");

            //int countThread = 2;
            //int countElement = mas.Length / countThread;
            //Thread[] threads = new Thread[countThread];
            //MyData[] myDatas = new MyData[countThread];
            //for(int i = 0; i<countThread; i++)
            //{
            //    threads[i] = new Thread(new ParameterizedThreadStart(ThreadExample.ThreadProc));
            //    myDatas[i] = new MyData(mas, i * countElement, countElement);
            //    threads[i].Start(myDatas[i]);
            //    threads[i].Join();
            //}

            //foreach(MyData data in myDatas)
            //{
            //    Console.WriteLine("sum = " + data.sum);
            //}
        }
    }
}