using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp46
{
     class Node
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
        public int Weight { get; set; }
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
}
