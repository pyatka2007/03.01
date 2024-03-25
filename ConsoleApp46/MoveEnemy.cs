using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp46
{
    public class MoveEnemy
    {
        // <summary>
        /// Метод для перемещения врага по карте к игроку (2) с использованием алгоритма A*
        /// </summary>
        /// <param name="mas">Двумерный массив символов, представляющий карту</param>
        static public void MoveEnemy2(char[,] mas)
        {
            int enemyX = -1;
            int enemyY = -1;
            int heroX = -1;  
            int heroY = -1;

            // Находим текущее положение врага 'E' и позицию цели '2' на карте
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (mas[i, j] == 'E')
                    {
                        enemyX = i;
                        enemyY = j;
                    }
                    else if (mas[i, j] == (char)2)
                    {
                        heroX = i;
                        heroY = j;
                    }
                }
            }
            if (enemyX == -1 || enemyY == -1 || heroX == -1 || heroY == -1)
            {
                // Убедимся, что оба положения врага и героя найдены
                return;
            }

            Node[,] map = new Node[mas.GetLength(0), mas.GetLength(1)];
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {

                    map[i, j] = new Node(i, j);
                    if (mas[i, j] == (char)6 || mas[i, j] == (char)0177)
                    {
                        map[i, j].IsObstacle = true;
                    }
                }
            }
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (i > 0 && i < mas.GetLength(0))
                    {
                        map[i, j].Neighbors.Add(map[i - 1, j]);
                    }
                    if (j > 0 && j < mas.GetLength(1))
                    {
                        map[i, j].Neighbors.Add(map[i, j - 1]);
                    }
                    if (i < mas.GetLength(0) - 1 && i >= 0)
                    {
                        map[i, j].Neighbors.Add(map[i + 1, j]);
                    }
                    if (j < mas.GetLength(1) - 1 && j >= 0)
                    {
                        map[i, j].Neighbors.Add(map[i, j + 1]);
                    }
                }
            }
            Node startNode = map[enemyX, enemyY];
            Node targetNode = map[heroX, heroY];
            List<Node> path = null;
            if (map != null)
            {
                path = AStar.FindPath(startNode, targetNode, map);
            }
            else
            {
                // Обработать ошибку, например вывести сообщение об отсутствии карты
                Console.WriteLine("Карта не создана.");
            }
            if (path != null)
            {
                // Очищаем текущую позицию врага
                mas[enemyX, enemyY] = '.';
                // Перемещаем врага к следующему узлу пути
                Node nextNode = path[2]; // [0] - начальное положение (текущая позиция врага)
                enemyX = nextNode.X;
                enemyY = nextNode.Y;
                mas[enemyX, enemyY] = 'E'; // Обновляем позицию врага на карте
            }

            for (int i = (mas.GetLength(0) - 1); i >= 0; i--) // Когда E догнал игрока поражение
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (enemyX == heroX && enemyY == heroY)
                    {
                        Console.Clear();
                        Console.WriteLine("поражение");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
    
}
