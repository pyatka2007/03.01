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
                    if(mas[i,j] == (char)6 || mas[i,j] == (char)0177)
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
                    if (i < mas.GetLength(0)-1 && i >= 0)
                    {
                        map[i, j].Neighbors.Add(map[i + 1, j]);
                    }
                    if (j < mas.GetLength(1) - 1 && j >= 0)
                    {
                        map[i, j].Neighbors.Add(map[i, j + 1]);
                    }
                }
            }
            Node startNode = new Node(enemyX, enemyY);
            Node targetNode = new Node(heroX, heroY);
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
                foreach (Node node in path)
                {
                    Console.WriteLine("{0}, {1}", node.X, node.Y);
                }
            }
            else
            {
                Console.WriteLine("Путь не найден.");
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
        }
    }
    class Node // оценка общей стоимости прохода через узел при выборе наилучшего пути
    {
        /// <summary>
        /// Координата X узла.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Координата Y узла.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Список соседних узлов.
        /// </summary>
        public List<Node> Neighbors { get; set; }

        /// <summary>
        /// Родительский узел.
        /// </summary>
        public Node Parent { get; set; }
        public bool IsObstacle { get; set; }

        /// <summary>
        /// Конструктор класса Node.
        /// </summary>
        /// <param name="x">Координата X.</param>
        /// <param name="y">Координата Y.</param>
        public Node(int x, int y)
        {
            X = x;
            Y = y;
            Neighbors = new List<Node>();
            IsObstacle = false;
        }
    }
    class AStar
    {

        /// <summary>
        /// Находит кратчайший путь от начального узла до конечного.
        /// </summary>
        /// <param name="start">Начальный узел.</param>
        /// <param name="goal">Конечный узел.</param>
        /// <returns>Список узлов, составляющих кратчайший путь.</returns>
        public static List<Node> FindPath(Node start, Node goal, Node[,] map)
        {
            // ## Открытый набор

            // HashSet используется для хранения уникальных элементов.
            HashSet<Node> openSet = new HashSet<Node>();
            openSet.Add(start);

            // ## Закрытый набор

            HashSet<Node> closedSet = new HashSet<Node>();

            // ## Словарь оценок g(n)

            // Dictionary используется для хранения пар ключ-значение.
            Dictionary<Node, int> gScore = new Dictionary<Node, int>();
            gScore[start] = 0;

            // ## Словарь оценок h(n)

            Dictionary<Node, int> hScore = new Dictionary<Node, int>();
            hScore[start] = Heuristic(start, goal);

            // ## Словарь оценок f(n) = g(n) + h(n)

            Dictionary<Node, int> fScore = new Dictionary<Node, int>();
            fScore[start] = gScore[start] + hScore[start];

            // ## Основной цикл алгоритма

            while (openSet.Count > 0)
            {
                // ## Выбор текущей вершины с минимальной f-оценкой

                Node current = null;
                int minFScore = int.MaxValue;
                foreach (Node node in openSet)
                {
                    if (fScore[node] < minFScore)
                    {
                        minFScore = fScore[node];
                        current = node;
                    }
                }

                // ## Если текущая вершина - конечная, то путь найден

                if (current == goal)
                {
                    return ReconstructPath(current);
                }

                // ## Перемещение вершины из открытого набора в закрытый

                closedSet.Add(current);
                openSet.Remove(current);


                // ## Проверка соседей текущей вершины

                foreach (Node neighbor in current.Neighbors)
                {
                    // Проверка, находится ли сосед за пределами карты
                    if (neighbor.X > 0 || neighbor.X >= map.GetLength(0) ||
                        neighbor.Y > 0 || neighbor.Y >= map.GetLength(1))
                    {
                        continue;
                    }

                    // Проверка, является ли сосед препятствием
                    if (map[neighbor.X, neighbor.Y].IsObstacle)
                    {
                        continue;
                    }

                    // Проверка, находится ли сосед в закрытом наборе
                    if (closedSet.Contains(neighbor))
                    {
                        continue;
                    }

                    // Добавление соседа в открытый набор
                    openSet.Add(neighbor);

                    // Расчет временной оценки g(neighbor)
                    int tentativeGScore = gScore[current] + 1;

                    // Проверка, существует ли g(neighbor)
                    if (!gScore.ContainsKey(neighbor))
                    {
                        gScore[neighbor] = int.MaxValue;
                    }

                    // Обновление значений, если временная оценка меньше
                    if (tentativeGScore < gScore[neighbor])
                    {
                        gScore[neighbor] = tentativeGScore;
                        hScore[neighbor] = Heuristic(neighbor, goal);
                        fScore[neighbor] = gScore[neighbor] + hScore[neighbor];

                        // Инициализация Parent
                        neighbor.Parent = current;
                    }
                }

            }
            // ## Путь не найден
            return null;
        }
        /// <summary>
        /// Восстанавливает кратчайший путь от конечного узла до начального.
        /// </summary>
        /// <param name="node">Конечный узел.</param>
        /// <returns>Список узлов, составляющих кратчайший путь.</returns>
        private static List<Node> ReconstructPath(Node node)
        {
            List<Node> path = new List<Node>();
            while (node != null)
            {
                path.Add(node);
                node = node.Parent;
            }
            path.Reverse();
            return path;
        }

        /// <summary>
        /// Эвристическая функция, которая вычисляет евклидово расстояние между двумя узлами.
        /// </summary>
        /// <param name="node1">Первый узел.</param>
        /// <param name="node2">Второй узел.</param>
        /// <returns>Евклидово расстояние между двумя узлами.</returns>
        private static int Heuristic(Node node1, Node node2)
        {
            return Math.Abs(node1.X - node2.X) + Math.Abs(node1.Y - node2.Y);
        }
    }
}
