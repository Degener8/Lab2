using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static bool CheckPos( int h, int v)
        {
            if (((h >= 65 && h <= 72) 
                    || (h >= 97 && h <= 104))
                && (v >= 1 && v <= 8))
                return false;
            else return true;
        }
        
        static void GetFigure(out int fgre)
        {
            Console.Write("1) Пешка\n2) Конь\n3) Ладья\n4) Слон\n5) Ферзь\n6) Король \nВведите номер фигуры из представленного выше списка: ");
            fgre = 0;
            fgre = int.Parse(Console.ReadLine()); 
            if (fgre < 1 || fgre > 6)
            {
                Console.WriteLine("Вы должны были ввести число от 1 до 6.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        static void GetPos(out int h1, out int v1, out int h2, out int v2)
        {
            do
            {
                Console.Write("Введите начальные координаты фигуры:");
                string pos1 = Console.ReadLine();
                h1 = Convert.ToInt32(pos1[0]);
                v1 = int.Parse(pos1.Substring(1));
                Console.WriteLine(h1);
                Console.WriteLine(v1);
            } 
            while (CheckPos(h1, v1));

            do
            {
                Console.Write("Введите конечные координаты фигуры:");
                string pos2 = Console.ReadLine();
                h2 = Convert.ToInt32(pos2[0]);
                v2 = int.Parse(pos2.Substring(1));
                Console.WriteLine(h2);
                Console.WriteLine(v2);
            }
            while (CheckPos(h2, v2));
        }

        static void GetMove(int h1, int v1, int h2, int v2, out int dh, out int dv)
        {
            dh = Math.Abs(h1 - h2);
            dv = Math.Abs(v1 - v2);
        }

        static void CheckMove()
        {
            int fgre, h1, v1, h2, v2, dh, dv;
            GetFigure(out fgre);
            GetPos(out h1, out v1, out h2, out v2);
            GetMove(h1, v1, h2, v2, out dh, out dv);

            switch(fgre)
            {
                case 1:
                    if ((v1 == 2 && dh == 0 && v2 == 4)
                        || (v1 == 7 && dh == 0 && v2 == 5)
                        || (dh == 0 && dv == 1))
                        Console.WriteLine("Верно.");
                    else Console.WriteLine("Неверно.");
                    break;
                case 2:
                    if ((dh == 1 && dv == 2) || (dh == 2 && dv == 1))
                        Console.WriteLine("Верно.");
                    else Console.WriteLine("Неверно.");
                    break;
                case 3:
                    if ((dh == 0 && dv > 0) || (dh > 0 && dv == 0))
                        Console.WriteLine("Верно.");
                    else Console.WriteLine("Неверно.");
                    break;
                case 4:
                    if (dh == dv && dv > 0)
                        Console.WriteLine("Верно.");
                    else Console.WriteLine("Неверно.");
                    break;
                case 5:
                    if (((dh == 0 && dv > 0) || (dh > 0 && dv == 0))
                        || (dh == dv && dv > 0))
                        Console.WriteLine("Верно.");
                    else Console.WriteLine("Неверно.");
                    break;
                case 6:
                    if (((dh == 0 && dv == 1) || (dh == 1 && dv == 0))
                        || (dh == dv && dv == 1))
                        Console.WriteLine("Верно.");
                    else Console.WriteLine("Неверно.");
                    break;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте.");
            CheckMove();
            Console.ReadKey();
        }
    }
}
