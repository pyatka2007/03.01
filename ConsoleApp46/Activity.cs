using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp46
{
    internal class Activity
    {
        /// <summary>
        /// Метод для проверки условия победы в игре
        /// </summary>
        /// <param name="mas">Игровое поле</param>
        /// <returns>True, если условие победы выполнено, иначе False</returns>
        static public bool Win(char[,] mas) 
        {
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (mas[i, j] == (char)1 || mas[i, j] == '0')
                    {
                        return false;
                    }
                    
                }
            }
            mas[10, 10] = '0';
            return true;
        }
        /// <summary>
        /// Метод для проведения битвы между героем и врагом
        /// </summary>
        /// <param name="Hero">Герой</param>
        /// <param name="mas">Игровое поле</param>
        static public void Batle(Person Hero, char[,] mas)
        {
            Console.Clear();
            Person Enemy = new Person(Map.levelWorld * 10);
            Random rnd = new Random();

            while (Enemy.HP > 0 && Hero.HP > 0)
            {
                int Shot = rnd.Next(10);
                Enemy.HP -= Shot + Hero.Strenght;
                Shot = rnd.Next(10);
                Hero.HP -= Shot + Map.levelWorld * 5;
            }
            if (Enemy.HP < Hero.HP)
            {
                Hero.coin += rnd.Next(100);
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Поражение");
                Console.ReadLine();
            }

        }

        /// <summary>
        /// Метод для увеличения максимального здоровья героя
        /// </summary>
        /// <param name="Hero">Герой</param>
        /// <param name="mas">Игровое поле</param>
        static void Heart(Person Hero, char[,] mas)
        {
            Console.Clear();
            Hero.MaxHP += 10;
            Hero.HP += Hero.MaxHP / 10;

        }
        /// <summary>
        /// Метод для взаимодействия с порталом
        /// </summary>
        /// <param name="Hero">Герой</param>
        /// <param name="mas">Игровое поле</param>
        static void Portal(Person Hero, char[,] mas)
        {
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (mas[i, j] == (char)3)
                    {
                        Hero.coin += 100;
                    }
                }
            }
            Hero.HP = Hero.MaxHP;
            Map.Generation(mas);
        }
        /// <summary>
        /// Метод для взаимодействия с кузницей
        /// </summary>
        /// <param name="Hero">Герой</param>
        static void Forge(Person Hero)
        {
            Console.WriteLine("Выберите действие");
            Console.WriteLine("1. Улучшить силу на 2");
            Console.WriteLine("Для выхода нажмите Enter");
            Console.WriteLine($"Оставшиеся деньги {Hero.coin}");
            ConsoleKey key;
            while ((key = Console.ReadKey().Key) != ConsoleKey.Enter)
            {
                switch (key)
                {
                    case ConsoleKey.NumPad1:
                        if (Hero.coin > 250)
                        {
                            Hero.Strenght += 2;
                            Hero.coin -= 250;
                            Console.WriteLine($"Сила увеличена на 2, Текущая сила = {Hero.Strenght}");
                            Console.WriteLine($"Оставшиеся деньги {Hero.coin}");
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно деняк");
                        }
                        break;
                }

            }
        }
        /// <summary>
        /// Метод для обработки событий при взаимодействии героя с окружением
        /// </summary>
        /// <param name="Hero">Герой</param>
        /// <param name="mas">Игровое поле</param>
        /// <param name="A">Смещение A</param>
        /// <param name="B">Смещение B</param>
        /// <returns>True, если обработка события прошла успешно, иначе False</returns>
        static public bool GetIvent(Person Hero, char[,] mas, int A = 0, int B = 0)
        {
            char key = mas[((mas.GetLength(0) - 1) / 2) + A, ((mas.GetLength(1) - 1) / 2) + B];

            switch (key)
            {
                case (char)1:
                    Batle(Hero, mas);
                    break;
                case (char)3:
                    Heart(Hero, mas);
                    break;
                case '0':
                    Map.levelWorld++;
                    Portal(Hero, mas);
                    break;
                case (char)19:
                    Forge(Hero);
                    break;
                case (char)0177:
                    return false;
                case (char)06:
                    return false;
                default:
                    break;
            }
            return true;

        }
    }

}
