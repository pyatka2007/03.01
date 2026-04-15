using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp46
{
    public class Person
    {
        public int MaxHP; //Убрана лишняя инициализация полей
        public int HP;
        public int Strenght = 0;
        public int coin = 0;
        public string NamePerson;
        /// <summary>
        /// Конструктор класса для инициализации персонажа с указанием начального здоровья и имени
        /// </summary>
        /// <param name="HP">Начальное здоровье персонажа</param>
        /// <param name="Name">Имя персонажа</param>
        public Person(int HP = 100, string Name = "Враг")
        {
            NamePerson = Name;
            this.HP = HP;
            this.MaxHP = HP;
        }
        /// <summary>
        /// Метод для вывода информации о персонаже в консоль
        /// </summary>
        /// <param name="Hero">Экземпляр персонажа для вывода информации</param>
        static public void GetCharacter(Person Hero)
        {
            Console.WriteLine($"Имя героя = {Hero.NamePerson}");
            Console.WriteLine($"Здоровье = {Hero.HP}");
            Console.WriteLine($"MAX Здоровье = {Hero.MaxHP}");
            Console.WriteLine($"Деняк = {Hero.coin}");
            Console.WriteLine($"Уровень мира = {Map.levelWorld}");
        }

    }
}
