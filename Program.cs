using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integral
{
    class SubIntegralFun
    {

        static public double sif1(double x)//подинтегральная функция
        {
            int k = 4; int b = 2;
            return (double)(k * x * x - b * Math.Pow(x, 4));//ставишь функцию какую надо
                                                            //return (double)(Math.Sin(x)); Проверял работоспособность
        }

    }//class SubIntegralFun

    class Интеграл
    {

        struct Integral
        {
            public double a, b;
            public int m;// m количество шагов
            public Integral(double ina, double inb, int inm)
            {
                if (ina < inb) { a = ina; b = inb; }
                else { b = ina; a = inb; }
                m = inm;

            }
        }
        static void Main(string[] args)
        {
            double S;
            Integral MyIntegral = new Integral(-1, 1, 400);
            S = trapec(MyIntegral);
            Console.WriteLine("Площадь равна: {0}", S);
            Console.ReadKey();
        }

        static double trapec(Integral I)//Вычисляет частную сумму по методу трапеций
        {
            double x = I.a, sum = SubIntegralFun.sif1(x), e = (I.b - I.a) / I.m;// деления всего промежутка интегрирования на отрезки одинаковой длины e
            for (int i = 1; i <= I.m; i++)
            {
                x += e;// 
                sum += SubIntegralFun.sif1(x);
            }

            x = I.b; sum += SubIntegralFun.sif1(x) / 2;
            return (sum * e);
        }
    }//class Интеграл
}
