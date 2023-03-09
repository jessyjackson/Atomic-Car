using System;

namespace AtomicDrive
{
    internal class Car
    {
        public Learning Qlearn;
        public Camera Camera = new();
        public enum Directions
        {
            //this order for increment operator
            Nord,
            Est,
            Sud,
            Ovest
        }
        public enum NameActions
        {
            Accelarate,
            Decelerate,
            TurnRight,
            TurnLeft,
            Continue,
        }
        public int Move { get; set; } = 0;
        public int Speed { get; set; }
        public int Points { get; set; }
        public int StartPoints { get; set; }
        public Directions Direction { get; set; }
        public Directions OldDirection { get; set; }
        public (int,int) StartPosition { get; set; }
        public (int, int) CarPosition { get; set; }//item1 = x; item2 = y
        public (int,int) OldPosition { get; set; }
        public List<Action> Actions { get; set; }
        public Action Action { get; set; }

        public Car((int, int) position, int points)
        {
            Direction = Directions.Nord;
            StartPoints = points;
            Points = points;
            Actions = new List<Action>
            {
                Accelarete,
                Decelerate,
                TurnRight,
                TurnLeft,
                Continue,
            };
            Speed = 1;
            StartPosition = position;
            CarPosition = StartPosition;
            Qlearn = new(Actions);
        }
        public void Continue() { MoveCar(); }
        public void TurnRight()
        {
            int value = (int)Direction;
            value++;
            value %= 4;
            Direction = (Directions)value;
        }
        public void TurnLeft()
        {
            int value = (int)Direction;
            value--;
            if (value == -1)
            {
                value = 3;
            }
            Direction = (Directions)value;
        }
        public void Accelarete()
        {
            if (Speed != 4)
            {
                Speed++;
            }
            MoveCar();
        }
        public void Decelerate()
        {
            if (Speed != 0)
            {
                Speed--;
            }
            MoveCar();
        }
        public void MoveCar()
        {
            CarPosition = Direction switch
            {
                Directions.Nord => (CarPosition.Item1, (CarPosition.Item2 - Speed)),
                Directions.Est => ((CarPosition.Item1 + Speed), CarPosition.Item2),
                Directions.Sud => (CarPosition.Item1, (CarPosition.Item2 + Speed)),
                Directions.Ovest => ((CarPosition.Item1 - Speed), CarPosition.Item2),
                _ => CarPosition,
            };
        }
        public int HandleAction(Path path)
        {
            //create state
            string state = Qlearn.CreateState(Camera.ReduceVision(Camera.RotateMatrix(Camera.Vision(path.Matrix, CarPosition, Direction), Direction)), Speed);
            //invoke action
            Action = Qlearn.SelectAction(Actions, state);
            OldPosition = CarPosition;
            OldDirection = Direction;
            Action.Invoke();
            Move++;
            //Create eppisode
            Step e = new(state, Action);
            //rewards
            int r = path.GetReward(OldPosition, CarPosition, Speed, OldDirection);
            Points += r;
            e.Reward = r;
            //position
            e.Position = CarPosition;
            //add eppisode to learning list
            Qlearn.AddStepToEpisode(e);
            //console log
            //ConsoleLog(state, r);
            //return 1 for victory, -1 for loose, 0 for nothing
            if (Points < 0 || path.Loose == r)
            {
                return -1;
            }
            if (r == path.Victory)
            {
                return 1;
            }
            return 0;
        }
        public void ConsoleLog(string state,int reward)
        {
            Console.WriteLine("Move:" + Move);
            Console.WriteLine("Points: " + Points);
            Console.WriteLine("stato: " + state);
            Console.WriteLine("Reward: " + reward);
            Console.WriteLine("Old Position" + OldPosition);
            Console.WriteLine("New Position: " + CarPosition);
            Console.WriteLine("Speed:" + Speed);
            Console.WriteLine("Old Direction: " + OldDirection);
            Console.WriteLine("New Direction: " + Direction);
            Console.WriteLine("Indice azione: " + (NameActions)Actions.IndexOf(Action));
        }
        public List<Step> StopAndReset()
        {
            List<Step> episode = Qlearn.GetSteps();
            Qlearn.AddStateToQTable();
            episode.RemoveAt(episode.Count - 1);
            CarPosition = StartPosition;
            Points = StartPoints; 
            Speed = 1;
            Direction = Directions.Nord;
            Move = 0;
            return episode;
        }
    }
}
