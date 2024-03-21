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
            char[,] mas = new char[25, 25];
            Map.Generation(mas);
            Person hero = new Person(100, name);
            ConsoleKey Key;
            while ((Key = Console.ReadKey().Key) != ConsoleKey.Escape)
            {
                Console.Clear();
                switch (Key)
                {
                    case ConsoleKey.UpArrow:
                        if (Activity.GetIvent(hero, mas, -1, 0))
                            Move.UpArray(mas);
                        break;
                    case ConsoleKey.DownArrow:
                        if (Activity.GetIvent(hero, mas, +1, 0))
                            Move.DownArray(mas);
                        break;
                    case ConsoleKey.LeftArrow:
                        if (Activity.GetIvent(hero, mas, 0, -1))
                            Move.LeftArray(mas);
                        break;
                    case ConsoleKey.RightArrow:
                        if (Activity.GetIvent(hero, mas, 0, +1))
                            Move.RightArray(mas);
                        break;
                    default:
                        break;
                }
                Map.GetMap(mas);
                Person.GetCharacter(hero);
                MoveEnemy.MoveEnemy2(mas);
                
               

            }
        }
    }
}
  

