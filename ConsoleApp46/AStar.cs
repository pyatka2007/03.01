using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp46
{
    static class AStar //добавлен static
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
                    if (neighbor.X < 0 || neighbor.X >= map.GetLength(0) ||
                        neighbor.Y < 0 || neighbor.Y >= map.GetLength(1))
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
            return new List<Node>(); //замена null на new List<Node>()
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
        public static int CalculateHeuristic(Node node1, Node node2)
        {
            return Heuristic(node1, node2);
        }
    }
}
