using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp46
{
    internal class Map
    {
        static public int levelWorld = 1;
        static Random rnd = new Random();
        static public void GetMap(char[,] mas)
        {
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    switch (mas[i, j])
                    {
                        case '0':
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case (char)1:
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case (char)3:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case (char)19:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case (char)0177:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case (char)2:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                        case (char)06:
                            switch (rnd.Next(4))
                            {
                               
                                case 1:
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    break;
                                case 2:
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    break;
                                default:
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    break;
                            }
                            break;
                        default:
                            
                            break;
                    }
                    Console.Write(mas[i, j] + " ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
        static public void Generation(char[,] mas)
        {
            Random rnd = new Random();
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    int count = rnd.Next(100);

                    mas[i, j] = '.';
                    if (count < 2)
                    {
                        mas[i, j] = (char)1;
                    }
                    if (count >= 98)
                    {
                        mas[i, j] = (char)3;
                    }
                    if (count >= 10 && count < 17)
                    {
                        for (int k = i - 1; k <= i + 1; k++)
                        {
                            for (int l = j - 1; l <= j + 1; l++)
                            {
                                if (k >= 0 && k < mas.GetLength(0) && l >= 0 && l < mas.GetLength(1))
                                {
                                    mas[k, l] = (char)06;
                                }
                            }
                        }
                    }
                    if (count >= 5 && count < 10)
                    {
                        int X = i;
                        int Y = j;
                        for (int t = 0; t < 10; t++)
                        {
                            mas[X++, Y++] = (char)0177;
                            if (X > mas.GetLength(0) - 1 || Y > mas.GetLength(1) - 1)
                                break;
                        }
                    }
                    if (levelWorld > 1)
                    {
                        mas[mas.GetLength(0) / 4, mas.GetLength(1) / 2] = (char)19;
                    }
                }
            }
        }
    }
}
