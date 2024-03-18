using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp46
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите имя персонажа");
            string name = Console.ReadLine();
            char[,] map = new char[25, 25];
            Map.Array(map);
            Person hero = new Person(150, name);
            ConsoleKey Key;
            while ((Key = Console.ReadKey().Key) != ConsoleKey.Escape)
            {
                Console.Clear();
                switch (Key)
                {
                    case ConsoleKey.UpArrow:
                        if (Map.GetIvent(hero, map, -1, 0))
                            Map.UpArray(map);
                        break;
                    case ConsoleKey.DownArrow:
                        if (Map.GetIvent(hero, map, +1, 0))
                            Map.DownArray(map);
                        break;
                    case ConsoleKey.LeftArrow:
                        if (Map.GetIvent(hero, map, 0, -1))
                            Map.LeftArray(map);
                        break;
                    case ConsoleKey.RightArrow:
                        if (Map.GetIvent(hero, map, 0, +1))
                            Map.RightArray(map);
                        break;
                    default:
                        break;
                }
                Map.GetMap(map);
                Person.GetCharacter(hero);
            }
        }
    }
}
  

