using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp46
{
    public interface IArrayMover
    {
        void MoveUp(char[,] mas);
        void MoveDown(char[,] mas);
        void MoveLeft(char[,] mas);
        void MoveRight(char[,] mas);
    }

    public class BasicArrayMover : IArrayMover
    {
        public void MoveUp(char[,] mas)
        {
            char[] temp = new char[mas.GetLength(0)];
            for (int i = (mas.GetLength(0) - 1); i >= 0; i--)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (i == (mas.GetLength(0) - 1))
                    {
                        temp[j] = mas[i, j];
                    }
                    else if (i == 0)
                    {
                        mas[i, j] = temp[j];
                    }
                    if (i != 0)
                    {
                        mas[i, j] = mas[i - 1, j];
                    }
                    if (i == (mas.GetLength(0) - 1) / 2 && j == (mas.GetLength(1) - 1) / 2)
                    {
                        mas[i, j] = (char)2;
                    }
                    if (i == (mas.GetLength(0) - 1) / 2 && j == (mas.GetLength(1) - 1) / 2)
                    {
                        mas[i + 1, j] = '.';
                    }
                }
            }
           
        }

        public void MoveDown(char[,] mas)
        {
            char[] temp = new char[mas.GetLength(0)];

            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        temp[j] = mas[i, j];
                    }
                    else if (i == (mas.GetLength(0) - 1))
                    {
                        mas[i, j] = temp[j];
                    }
                    if (i != (mas.GetLength(0) - 1))
                    {
                        mas[i, j] = mas[i + 1, j];
                    }
                    if (i == (mas.GetLength(0) - 1) / 2 && j == (mas.GetLength(1) - 1) / 2)
                    {
                        mas[i, j] = (char)2;
                    }
                    if (i == (mas.GetLength(0) - 1) / 2 && j == (mas.GetLength(1) - 1) / 2)
                    {
                        mas[i - 1, j] = '.';
                    }
                }
            }
        }

        public void MoveLeft(char[,] mas)
        {
            char[] temp = new char[mas.GetLength(1)];

            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = (mas.GetLength(1) - 1); j >= 0; j--)
                {
                    if (j == (mas.GetLength(1) - 1))
                    {
                        temp[i] = mas[i, j];
                    }
                    else if (j == 0)
                    {
                        mas[i, j] = temp[i];
                    }
                    if (j != 0)
                    {
                        mas[i, j] = mas[i, j - 1];
                    }
                    if (i == (mas.GetLength(0) - 1) / 2 && j == (mas.GetLength(1) - 1) / 2)
                    {
                        mas[i, j] = (char)2;
                    }
                    if (i == (mas.GetLength(0) - 1) / 2 && j == (mas.GetLength(1) - 1) / 2)
                    {
                        mas[i, j + 1] = '.';
                    }
                }
            }
           
        }

        public void MoveRight(char[,] mas)
        {
            char[] temp = new char[mas.GetLength(1)];

            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        temp[i] = mas[i, j];
                    }
                    else if (j == (mas.GetLength(1) - 1))
                    {
                        mas[i, j] = temp[i];
                    }
                    if (j != (mas.GetLength(1) - 1))
                    {
                        mas[i, j] = mas[i, j + 1];
                    }
                    if (i == (mas.GetLength(0) - 1) / 2 && j == (mas.GetLength(1) - 1) / 2)
                    {
                        mas[i, j] = (char)2;
                    }
                    if (i == (mas.GetLength(0) - 1) / 2 && j == (mas.GetLength(1) - 1) / 2)
                    {
                        mas[i, j - 1] = '.';
                    }
                }
            }
            
        }
    }

    public class Move
    {
        private readonly IArrayMover _arrayMover;

        public Move(IArrayMover arrayMover)
        {
            _arrayMover = arrayMover;
        }

        public void MoveUp(char[,] mas)
        {
            _arrayMover.MoveUp(mas);
            Activity.Win(mas);
        }

        public void MoveDown(char[,] mas)
        {
            _arrayMover.MoveDown(mas);
            Activity.Win(mas);
        }

        public void MoveLeft(char[,] mas)
        {
            _arrayMover.MoveLeft(mas);
            Activity.Win(mas);
        }

        public void MoveRight(char[,] mas)
        {
            _arrayMover.MoveRight(mas);
            Activity.Win(mas);
        }
    }



    }
