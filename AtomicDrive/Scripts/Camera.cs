using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AtomicDrive.Car;

namespace AtomicDrive
{
    internal class Camera
    {
        public int VisionRange { get; set; } = 9;
        public List<List<int>> Vision(int[,] path,(int,int) carPosition,Directions direction)
        {
            List<List<int>> matrix = new();
            int x = carPosition.Item1;
            int y = carPosition.Item2;
            if (direction == Directions.Nord)
            {

                for (int i = Math.Max((y - VisionRange - 1), 0); i < y - 1; i++)
                {
                    List<int> list = new();
                    matrix.Add(list);
                    for (int j = Math.Max((x - (VisionRange / 2)), 0); j < Math.Min((x + (VisionRange / 2) + 1), path.GetLength(1)); j++)
                    {
                        list.Add(path[i, j]);
                    }

                }
            }
            else if (direction == Directions.Est)
            {

                for (int i = Math.Max((y - (VisionRange / 2)), 0); i < Math.Min((y + (VisionRange / 2) + 1), path.GetLength(0)); i++)
                {
                    List<int> list = new();
                    matrix.Add(list);
                    for (int j = Math.Min((x + 1), (path.GetLength(1))); j < Math.Min((x + (VisionRange + 1)), path.GetLength(1)); j++)
                    {
                        list.Add(path[i, j]);
                    }
                }

            }
            else if (direction == Directions.Sud)
            {
                for (int i = Math.Min((y + 1), (path.GetLength(0))); i < Math.Min((y + 1 + VisionRange), path.GetLength(0)); i++)
                {
                    List<int> list = new();
                    matrix.Add(list);
                    for (int j = Math.Max(0, (x - (VisionRange / 2))); j < Math.Min(path.GetLength(1), (x + (VisionRange / 2) + 1)); j++)
                    {
                        list.Add(path[i, j]);
                    }
                }

            }
            else if (direction == Directions.Ovest)
            {

                for (int i = Math.Max((y - (VisionRange / 2)), 0); i < Math.Min(path.GetLength(0), (y + (VisionRange / 2) + 1)); i++)
                {
                    List<int> list = new();
                    matrix.Add(list);
                    for (int j = Math.Max((x - 1 - VisionRange), 0); j < x - 1; j++)
                    {
                        list.Add(path[i, j]);
                    }
                }
            }
            return matrix;
        }
        public int[,] RotateMatrix(List<List<int>> matrix,Directions direction)
        {
            int[,] m = new int[0, 0];
            if (matrix.Count < 1)
            {
                return m;
            }
            if (matrix[0].Count < 1)
            {
                return m;
            }
            if (direction == Directions.Nord)
            {

                m = new int[matrix.Count, matrix[0].Count];
                int c = 0;
                int r = 0;
                for (int i = 0; i < matrix.Count; i++)
                {
                    for (int j = 0; j < matrix[r].Count; j++)
                    {
                        m[i, j] = matrix[r][c];
                        c++;
                    }
                    r++;
                    c = 0;
                }
            }
            else if (direction == Directions.Est)
            {
                m = new int[matrix[0].Count, matrix.Count];
                int c = (matrix[0].Count - 1);
                int r = 0;
                for (int i = 0; i < matrix[r].Count; i++)
                {
                    for (int j = 0; j < matrix.Count; j++)
                    {
                        m[i, j] = matrix[r][c];
                        r++;
                    }
                    r = 0;
                    c--;
                }
            }
            else if (direction == Directions.Sud)
            {
                m = new int[matrix.Count, matrix[0].Count];
                int c = matrix[matrix.Count - 1].Count - 1;
                int r = matrix.Count - 1;
                for (int i = 0; i < matrix.Count; i++)
                {
                    for (int j = 0; j < matrix[r].Count; j++)
                    {
                        m[i, j] = matrix[r][c];
                        c--;
                    }
                    c = matrix[matrix.Count - 1].Count - 1;
                    r--;
                }
            }
            else if (direction == Directions.Ovest)
            {
                m = new int[matrix[0].Count, matrix.Count];
                int c = 0;
                int r = matrix.Count - 1;
                for (int i = 0; i < matrix[r].Count; i++)
                {
                    for (int j = 0; j < matrix.Count; j++)
                    {
                        m[i, j] = matrix[r][c];
                        r--;
                    }
                    c++;
                    r = matrix.Count - 1;
                }

            }
            return m;
        }
        public Dictionary<int, int> ReduceVision(int[,] vision)
        {
            Dictionary<int, int> angles = new()
            {
                [0] = 0,
                [45] = 0,
                [135] = 0,
                [90] = 0,
            };

            for (int y = 1; y < vision.GetLength(1) - 1; y++)
            {
                for (int x = 1; x < vision.GetLength(0) - 1; x++)
                {
                    int gx = (1 * (vision[(x - 1), y])) - (vision[(x + 1), y]);
                    int gy = (1 * (vision[x, (y - 1)])) - (vision[x, (y + 1)]);
                    if (gx != 0 || gy != 0)
                    {
                        double r = Math.Atan2(gy, gx);
                        int grades = (int)(r * (180 / Math.PI));
                        if (grades == -45)
                        {
                            grades = 135;
                        }
                        else if (grades == -90)
                        {
                            grades = 90;
                        }
                        else if (grades == -135)
                        {
                            grades = 45;
                        }
                        else if (grades == 180)
                        {
                            grades = 0;
                        }
                        angles[grades]++;
                    }
                }

            }

            return angles;
        }
    }
}
