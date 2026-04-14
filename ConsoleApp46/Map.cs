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
        private static IMapGenerator _generator;
        static public int levelWorld = 1;
        static Random rnd = new Random();
        public static void SetGenerator(IMapGenerator generator)
        {
            _generator = generator;
        }
        /// <summary>
        /// Метод для отображения карты в консоли
        /// </summary>
        /// <param name="mas">Двумерный массив символов, представляющий карту</param>
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
                        case 'E':
                            Console.ForegroundColor = ConsoleColor.Magenta;
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
        /// <summary>
        /// Метод для генерации игровой карты
        /// </summary>
        /// <param name="mas">Двумерный массив символов, представляющий карту</param>
        static public void Generation(char[,] mas)
        {
            if (_generator == null)
                throw new InvalidOperationException("Генератор не установлен. Вызовите SetGenerator перед Generation.");
            _generator.Generate(mas);
        }
    }
}
