﻿using System.Reflection;

namespace AtomicDrive
{
    internal class Path
    {
        public int[,] Matrix { get; set; } = new int[25, 25];
        public Car.Directions StartDirection { get; set; }
        public (int, int) CarStartCoordinate { get; set; }
        public int CarPoints { get; set; }
        public (int, int) StartCoordinate { get; set; }
        public (int, int) EndCoordinate { get; set; }
        public int MoveReward { get; set; } = -1;
        public int LooseReward { get; set; } = -100;
        public int VictoryReward { get; set; } = 100;
        public List<string> Actions { get; set; }
        public Path()
        {
            StraightLine();
            //LeftBorsatoCurve();
            Actions = new()
            {
                "StraightLine",
                "RightCurve",
                "LeftCurve",
                "RoudaBout",
                "LeftBorsatoCurve"
            };
        }
        public void StraightLine()
        {
            int[,] arr =
            {
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            };
            Matrix = arr;
            SetCoordinate((3, 0), (21, 2));
            CarStartCoordinate = (12, 23);
            CarPoints = 15;
            StartDirection = Car.Directions.Nord;
        }
        public void RightCurve()
        {
            int[,] arr = {

                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                {1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },//2
                {1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },//3
                {1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },//4
                {1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },//5
                {1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },//6
                {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1 },
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1 },
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1 },
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1 },
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1 },
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1 },
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1 },
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1 },
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1 },
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1 },
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1 },
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1 },
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1 },
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            };
            Matrix = arr;
            SetCoordinate((23, 2), (24, 6));
            CarStartCoordinate = (12, 23);
            CarPoints = 30;
            StartDirection = Car.Directions.Nord;
        }
        public void LeftCurve()
        {
            int[,] arr = {
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1 },
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1 },
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1 },
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1 },
                {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1 },
                {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1 },
                {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1 },
                {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1 },
                {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1 },
                {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1 },
                {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1 },
                {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1 },
                {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1 },
                {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1 },
                {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1 },
                {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1 },
                {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1 },
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            };
            Matrix = arr;
            SetCoordinate((0, 2), (2, 6));
            CarStartCoordinate = (12, 23);
            CarPoints = 25;
            StartDirection = Car.Directions.Nord;
        }
        public void LeftBorsatoCurve()
        {
            int[,] arr = {
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            };
            Matrix = arr;
            SetCoordinate((23, 4), (24, 13));
            CarStartCoordinate = (12, 23);
            CarPoints = 25;
            StartDirection = Car.Directions.Nord;
        }
        public void RoudaBout()
        {
            int[,] arr = new int[25, 25]
            {
                { 1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1},
                { 1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
                { 1,1,1,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,1,1,1},
                { 1,1,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,1,1},
                { 1,1,1,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,1,1,1},
                { 1,1,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,1,1},
                { 1,1,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,1,1},
                { 1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,1},
                { 1,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,1},
                { 1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1},
                { 1,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,1},
                { 1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,1},
                { 1,1,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,1,1},
                { 1,1,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,1,1},
                { 1,1,1,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,1,1,1},
                { 1,1,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,1,1},
                { 1,1,1,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,1,1,1},
                { 1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
                { 1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            };
            Matrix = arr;
            CarStartCoordinate = (12, 23);
            SetCoordinate((9, 0), (15, 1));
            CarPoints = 30;
            StartDirection = Car.Directions.Nord;
        }
        public (int, int) GetRandomPosition()
        {
            Random r = new();
            (int, int) ris = (0, 0);
            while (true)
            {
                ris.Item1 = r.Next(0, Matrix.GetLength(1));
                ris.Item2 = r.Next(0, Matrix.GetLength(0));
                if (Matrix[ris.Item2, ris.Item1] == 0)
                {
                    return ris;
                }
            }
        }

        public void SetCoordinate((int, int) start, (int, int) finish)
        {
            StartCoordinate = start;
            EndCoordinate = finish;
        }
        public void ChangePath(int n)
        {
            string newPath = Actions[n];
            MethodInfo? m = this.GetType().GetMethod(newPath);
            m!.Invoke(this, null);
        }
        public static int[,] Invert(int[,] ar)
        {
            for (int i = 0; i < ar.GetLength(0); i++)
            {
                for (int j = 0; j < ar.GetLength(1); j++)
                {
                    if (ar[i, j] == 0)
                    {
                        ar[i, j] = 1;
                    }
                    else if (ar[i, j] == 1)
                    {
                        ar[i, j] = 0;
                    }
                }
            }
            return ar;
        }
        public int GetReward((int, int) oldPos, (int, int) newPos, int speed, Car.Directions oldDirection)
        {
            int wall = 1;
            int oldX = oldPos.Item1;
            int oldY = oldPos.Item2;
            int newX = newPos.Item1;
            int newY = newPos.Item2;
            int startXFLine = StartCoordinate.Item1;
            int startYFLine = StartCoordinate.Item2;
            int endXFLine = EndCoordinate.Item1;
            int endYFLine = EndCoordinate.Item2;

            if (oldX == newX && oldY == newY)
            {
                return MoveReward;
            }
            if (newY >= Matrix.GetLength(1) || newY < 0 || newX >= Matrix.GetLength(0) || newX < 0)
            {
                return LooseReward;
            }
            switch (oldDirection)
            {
                case Car.Directions.Nord:
                    for (int i = oldY; i >= newY; i--)
                    {
                        if (newX >= startXFLine && newX <= endXFLine && i >= startYFLine && i <= endYFLine)
                        {
                            return VictoryReward;
                        }
                        if (Matrix[i, newX] == wall)
                        {
                            return LooseReward;
                        }
                    }
                    return MoveReward;
                case Car.Directions.Est:
                    for (int i = oldX; i <= newX; i++)
                    {
                        if (newY >= startYFLine && newY <= endYFLine && i >= startXFLine && i <= endXFLine)
                        {
                            return VictoryReward;
                        }
                        if (Matrix[newY, i] == wall)
                        {
                            return LooseReward;
                        }
                    }
                    return MoveReward;
                case Car.Directions.Sud:
                    for (int i = oldY; i <= newY; i++)
                    {
                        if (newX >= startXFLine && newX <= endXFLine && i >= startYFLine && i <= endYFLine)
                        {
                            return VictoryReward;
                        }
                        if (Matrix[i, newX] == wall)
                        {
                            return LooseReward;
                        }
                    }
                    return MoveReward;
                case Car.Directions.Ovest:
                    for (int i = oldX; i >= newX; i--)
                    {
                        if (newY >= startYFLine && newY <= endYFLine && i >= startXFLine && i <= endXFLine)
                        {
                            return VictoryReward;
                        }

                        if (Matrix[newY, i] == wall)
                        {
                            return LooseReward;
                        }
                    }
                    return MoveReward;
                default:
                    return MoveReward;
            }
        }
    }
}
