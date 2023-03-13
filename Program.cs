using System;

namespace OOP_Matrix
{

    public interface SizeInt
    {
        int length { get;}
    }

    public class Square_Matrix: SizeInt
    {

        public int length { get; set; }
        public int[,] A = new int[100, 100];



        public Square_Matrix()
        { }

        public Square_Matrix(int length, int[,] A)
        {
            this.length = length;
            for (int i = 1; i <= length; i++)
                for (int j = 1; j <= length; j++)
                    this.A[i, j] = A[i, j];
   
        }

        public void nhap()
        {

            Console.Write("Nhap do dai cua ma tran vuong: ");
            length = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap ma tran:");
            for (int i = 1; i <= length; i++)
                for (int j = 1; j <= length; j++)
                {
                    Console.Write("A[{0}],[{1}] = ", i, j);
                    this.A[i, j] = int.Parse(Console.ReadLine());
                }
        }

        public void xuat()
        {
            Console.WriteLine("In ma tran:");
            for (int i = 1; i <= length; i++)
            {
                for (int j = 1; j <= length; j++)
                {
                    Console.Write("{0} ", this.A[i, j]);
                }
                Console.WriteLine();
            }
        }

        public virtual int determinantOfMatrix()
        {
            int num1, num2, det = 1, index, total = 1;
            int n = length;
            int[,] mat = A;

            int[] temp = new int[n + 1];

            for (int i = 1; i <= n; i++)
            {
                index = i;

                while (index < n && mat[index, i] == 0) index++;

                if (index == n) continue;

                if (index != i)
                {

                    for (int j = 1; j <= n; j++)
                    {
                        (mat[index, j], mat[i, j]) = (mat[i, j], mat[index, j]);
                    }

                    det = (int)(det * Math.Pow(-1, index - i));
                }

                for (int j = 1; j <= n; j++)
                    temp[j] = mat[i, j];


                for (int j = i + 1; j <= n; j++)
                {
                    num1 = temp[i];
                    num2 = mat[j, i];

                    for (int k = 1; k <= n; k++)
                    {

                        mat[j, k] = (num1 * mat[j, k]) - (num2 * temp[k]);
                    }
                    total = total * num1;
                }
            }


            for (int i = 1; i <= n; i++)
                det = det * mat[i, i];
            return (det / total);
        }

        public bool check()
        {
            for (int i = 1; i <= length; i++)
                for (int j = 1; j <= length; j++)
                    if (i != j && A[i, j] != 0) return false;
            return true;
        }
    }


    class Diagonalizable_Matrix : Square_Matrix
    {
        public Diagonalizable_Matrix()
        { }


        public override int determinantOfMatrix()
        {
            int det = 1;
            for (int i = 1; i <= length; i++)
                det *= A[i, i];
            return det;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Square_Matrix A = new Diagonalizable_Matrix();
            A.nhap();
            A.xuat();
            Console.Write("Dinh thuc cua ma tran la: ");
            if (A.check() == false)
            {
                Square_Matrix B = new Square_Matrix();
                B.A = A.A;
                B.length = A.length;
                Console.WriteLine(B.determinantOfMatrix());
            }
            else
            {
                Console.WriteLine(A.determinantOfMatrix());
            }


            Console.ReadKey();
        }
    }
}

