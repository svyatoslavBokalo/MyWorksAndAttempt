using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MultithreadingFirst
{
    class Matrix
    {
        private int rowCount;
        private int columnCount;
        private double[,] matr;
        public double sum;
        public int startRow;
        public int endRow;
        public int startColumn;
        public int endColumn;

        public int RowCount { get => rowCount; set => rowCount = value; }
        public int ColumnCount { get => columnCount; set => columnCount = value; }
        public double[,] Matr { get => matr; set => matr = value; }
        public Matrix()
        {
            this.rowCount = 0;
            this.columnCount = 0;
            this.matr = new double[0,0];
        }
        public Matrix(int rowCount = 1, int columnCount = 1)
        {
            this.rowCount = rowCount;
            this.columnCount = columnCount;
            this.matr = new double[rowCount, columnCount];
        }



        public Matrix(double[,] a)
        {
            this.rowCount = a.GetLength(0);
            this.columnCount = a.GetLength(1);
            this.matr = new double[a.GetLength(0), a.GetLength(1)];
            for(int i = 0; i< a.GetLength(0); i++)
            {
                for(int j = 0; j < a.GetLength(1); j++)
                {
                    this.matr[i, j] = a[i, j];
                }
            }
        }

        public Matrix(double[] a)
        {
            this.rowCount = a.Length;
            this.columnCount = 1;
            this.matr = new double[a.GetLength(0), 1];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                this.matr[i, 0] = a[i];
            }
        }

        public Matrix(StreamReader sr)
        {
            ReadFromFile(sr);
        }

        public Matrix(Matrix matrix)
        {
            this.rowCount = matrix.rowCount;
            this.columnCount = matrix.columnCount;
            this.Clone(matrix);
        }

        public Matrix(int rowCount, int columCount, double[,] matr)
        {
            this.rowCount = rowCount;
            this.columnCount = columCount;
            this.matr = matr;
        }

        public Matrix(double[,] matr, int startRow,int endRow, int startColumn, int endColumn)
        {
            this.rowCount = matr.GetLength(0);
            this.columnCount = matr.GetLength(1);
            this.matr = matr;
            this.startRow = startRow;
            this.startColumn = startColumn;
            this.endRow = endRow;
            this.endColumn = endColumn;
        }


        public Matrix DirectMove(Matrix left)
        {
            Matrix res = new Matrix(left);
            double cof = 0;
            double v = 0;

            for (int i = 0; i < left.ColumnCount; i++)
            {
                double max = Math.Abs(res[i, i]);
                int numberMax = i;

                for (int k = i; k < left.RowCount; k++)
                {
                    if (Math.Abs(res[k, i]) > max)
                    {
                        max = Math.Abs(res[k, i]);
                        numberMax = k;
                    }
                }

                if (i != numberMax)
                {
                    for (int j = i; j < left.ColumnCount; j++)
                    {
                        double buff = res[i, j];
                        res[i, j] = res[numberMax, j];
                        res[numberMax, j] = buff;
                    }
                }

                v = res[i, i];

                for (int j = i + 1; j < left.RowCount; j++)
                {
                    cof = res[j, i];
                    for (int k = i; k < left.ColumnCount; k++)
                    {
                        res[j, k] = res[j, k] * v - res[i, k] * cof;
                    }
                    //right[j, 0] = right[j, 0] * v - right[i, 0] * cof;
                }
            }

            return res;

        }



        public Matrix ReversMove(Matrix left, Matrix right)
        {
            Matrix x = new Matrix(right.RowCount, 1);

            for (int i = x.RowCount - 1; i > -1; i--)
            {
                double s = 0;
                for (int k = i + 1; k < left.ColumnCount; k++)
                {
                    s += left[i, k] * x[k, 0];
                }
                x[i, 0] = (right[i, 0] - s) / left[i, i];
            }

            return x;
        }


        

        public void ReadFromFile(StreamReader sr)
        {
            string line = sr.ReadLine();
            rowCount = int.Parse(line.Split()[0]);
            columnCount = int.Parse(line.Split()[1]);
            matr = new double[rowCount, columnCount];

            for(int i = 0; i < rowCount; i++)
            {
                line = sr.ReadLine();
                string[] mas = line.Split();
                for(int j = 0; j < columnCount; j++)
                {
                    matr[i, j] = double.Parse(mas[j]);
                }
            }
        }

        public void FillingTheMatrix()
        {
            for(int i = 0; i < rowCount; i++)
            {
                string line = Console.ReadLine();
                string[] mas = line.Split();
                for(int j = 0; j < columnCount; j++)
                {
                    double number = double.Parse(mas[j]);
                    matr[i, j] = number;
                }
            }
               
        }

        static public Matrix operator+(Matrix m1, Matrix m2)
        {
            Matrix res = new Matrix(m1.RowCount, m1.ColumnCount);

            if (m1.rowCount == m2.rowCount && m1.rowCount == m2.rowCount)
            {
                for (int i = 0; i < m1.rowCount; i++)
                {
                    for (int j = 0; j < m1.columnCount; j++)
                    {
                        res.matr[i, j] = m1.matr[i,j] + m2.Matr[i, j];
                    }
                }
            }
            else
            {
                throw new Exception("incorrect size of matrix");
            }
            return res;
        }

        static public Matrix operator -(Matrix m1, Matrix m2)
        {
            Matrix res = new Matrix(m1.RowCount, m1.ColumnCount);

            if (m1.rowCount == m2.rowCount && m1.rowCount == m2.rowCount)
            {
                for (int i = 0; i < m1.rowCount; i++)
                {
                    for (int j = 0; j < m1.columnCount; j++)
                    {
                        res.matr[i, j] = m1.matr[i,j] - m2.matr[i, j];
                    }
                }
            }
            else
            {
                throw new Exception("incorrect size of matrix");
            }
            return res;
        }

        static public Matrix operator *(Matrix m1, Matrix m2)
        {
            Matrix res = new Matrix(m1.RowCount, m2.ColumnCount);
            
            if (m1.ColumnCount == m2.RowCount)
            {
                for(int i = 0; i < m1.RowCount; i++)
                {
                    for(int j = 0; j < m2.ColumnCount; j++)
                    {
                        double sum = 0;
                        for(int k = 0; k < m1.ColumnCount; k++)
                        {
                            sum += m1.Matr[i, k] * m2.Matr[k, j];
                        }
                        res.Matr[i, j] = sum;
                    }
                }
            }
            else
            {
                throw new Exception("incorrect size of matrix");
            }
            return res;
        }

        public double this[int i, int j]
        {
            get
            {
                if((i>rowCount || i < 0) || (j > columnCount || j < 0))
                {
                    throw new Exception("incorrect index");
                }
                return matr[i, j];
            }
            set
            {
                if ((i > rowCount || i < 0) || (j > columnCount || j < 0))
                {
                    throw new Exception("incorrect index");
                }
                this.matr[i, j] = value;
            }
        }

        public double Norma()
        {
            double res = 0;

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    res += matr[i, j] * matr[i, j];
                }
            }

            return Math.Sqrt(res);
        }

        public double Norma1()
        {
            double res = Math.Abs(matr[0,0]);
            for(int i = 0; i < rowCount; i++)
            {
                for(int j = 0; j < columnCount; j++)
                {
                    if (Math.Abs(matr[i, j]) > res)
                    {
                        res = Math.Abs(matr[i, j]);
                    }
                }
            }

            return res;
        }

        public void Clone(Matrix matrix)
        {
            this.matr = new double[matrix.rowCount, matrix.columnCount];
            for (int i = 0; i < matrix.rowCount; i++)
            {
                for (int j = 0; j < matrix.columnCount; j++)
                {
                    matr[i, j] = matrix[i, j];
                }
            }
        }

        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    res += string.Format("{0:f6}", matr[i, j]) + " ";
                }
                res += "\n";
            }
            return res;
        }

        public void Show()
        {
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    Console.Write(string.Format("{0,5:0.0}", matr[i, j]) + " ");
                }
                Console.WriteLine();
            }
        }

        //public void 
    }
}
