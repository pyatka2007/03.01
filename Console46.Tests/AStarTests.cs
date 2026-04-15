using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp46;

namespace Console46.Tests
{
    [TestFixture]
    public class AStarTests
    {
        [Test]
        public void FindPath_OnEmptyMap_ReturnsPath()
        {
            // Создаём карту 3x3 без препятствий
            Node[,] map = new Node[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    map[i, j] = new Node(i, j);
            // Добавляем соседей
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (i > 0) map[i, j].Neighbors.Add(map[i - 1, j]);
                    if (i < 2) map[i, j].Neighbors.Add(map[i + 1, j]);
                    if (j > 0) map[i, j].Neighbors.Add(map[i, j - 1]);
                    if (j < 2) map[i, j].Neighbors.Add(map[i, j + 1]);
                }
            Node start = map[0, 0];
            Node goal = map[2, 2];
            List<Node> path = AStar.FindPath(start, goal, map);
            Assert.IsNotNull(path);
            Assert.That(path.Count, Is.GreaterThan(0));
            Assert.AreEqual(goal, path[path.Count - 1]);
        }

        [Test]
        public void FindPath_WhenNoPath_ReturnsEmptyList()
        {
            // Создаём карту с препятствиями
            Node[,] map = new Node[2, 2];
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    map[i, j] = new Node(i, j) { IsObstacle = false };
            // Блокируем все соседние клетки
            map[0, 1].IsObstacle = true;
            map[1, 0].IsObstacle = true;
            // Добавляем соседей
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    if (i > 0) map[i, j].Neighbors.Add(map[i - 1, j]);
                    if (i < 1) map[i, j].Neighbors.Add(map[i + 1, j]);
                    if (j > 0) map[i, j].Neighbors.Add(map[i, j - 1]);
                    if (j < 1) map[i, j].Neighbors.Add(map[i, j + 1]);
                }
            Node start = map[0, 0];
            Node goal = map[1, 1];
            List<Node> path = AStar.FindPath(start, goal, map);
            Assert.IsEmpty(path);
        }
    }
}