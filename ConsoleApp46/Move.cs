using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp46
{
    class Move
    {
        static public void UpArray(char[,] mas)
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
            Activity.Win(mas);
        }
        static public void DownArray(char[,] mas)
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
            Activity.Win(mas);
        }
        static public void LeftArray(char[,] mas)
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
            Activity.Win(mas);
        }
        static public void RightArray(char[,] mas)
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
            Activity.Win(mas);
        }
    }
}
