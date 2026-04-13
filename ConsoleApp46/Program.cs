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
            try
            {
                string name = "";
                while (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Введите имя персонажа:");
                    name = Console.ReadLine().Trim();
                }

                char[,] mas = new char[25, 25];
                Map.Generation(mas);
                Person hero = new Person(100, name);

                // Создаем экземпляр объекта BasicArrayMover, который реализует интерфейс IArrayMover
                IArrayMover arrayMover = new BasicArrayMover();

                // Передаем экземпляр объекта BasicArrayMover в конструктор Move
                Move move = new Move(arrayMover);

                ConsoleKey Key;

                while ((Key = Console.ReadKey().Key) != ConsoleKey.Escape)
                {
                    Console.Clear();

                    switch (Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (Activity.GetIvent(hero, mas, -1, 0))
                                move.MoveUp(mas);
                            break;
                        case ConsoleKey.DownArrow:
                            if (Activity.GetIvent(hero, mas, 1, 0))
                                move.MoveDown(mas);
                            break;
                        case ConsoleKey.LeftArrow:
                            if (Activity.GetIvent(hero, mas, 0, -1))
                                move.MoveLeft(mas);
                            break;
                        case ConsoleKey.RightArrow:
                            if (Activity.GetIvent(hero, mas, 0, 1))
                                move.MoveRight(mas);
                            break;
                        default:
                            break;
                    }

                    Map.GetMap(mas);
                    Person.GetCharacter(hero);
                    // Например, нажата ли клавиша пробела
                    bool spacePressed = false; // или false, в зависимости от вашей логики

                    // Вызываем метод MoveEnemy2 из класса MoveEnemy
                    MoveEnemy.MoveEnemy2(mas, spacePressed);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.HandleException(ex);
            }
        }

    }
}
  

