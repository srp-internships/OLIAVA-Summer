using System;
using System.ComponentModel;
using System.Numerics;

namespace HigherMathematics
{
    public static class HigherMath
    {
        public static int Sum(int a, int b) => a + b;

        public static int Degree(int number, int power)
        {
            int degree = 1;
            for (int i = 0; i < power; i++)
                degree *= number;

            return degree;
        }

        public static int Fact(int n)
        {
            int factorial = 1;
            for (int i = 1; i <= n; i++)
                factorial *= i;

            return factorial;
        }
    }
}
