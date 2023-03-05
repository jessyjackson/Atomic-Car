
namespace AtomicDrive
{
    internal class Learning
    {
        public int Train { get; set; } = 190000;
        public string FileName { get; set; } = "log.txt";
        public int Face { get; set; } = 0;
        public Dictionary<string, List<double>> Qtables = new();
        public List<Episode> Episodes { get; set; } = new();
        public List<Action>? Actions { get; set; }
        public Learning(List<Action> a)
        {
            Actions = a;
            List<double> l = new();
            for (int i = 0; i < 5; i++)
            {
                l.Add(0);
            }
            if (File.Exists(FileName))
            {
                OpenSavedLearn(FileName);
            }
            if (!Qtables.ContainsKey("extraspace"))
            {
                Qtables.Add("extraspace", l);
            }
        }
        public string CreateState(Dictionary<int, int> frequences, int speed)
        {
            // Horizontal/Vertical/RightDiagonal/LeftDiagonal/Speed
            return $"H{frequences[0]}/V{frequences[90]}/RD{frequences[45]}/LD{frequences[135]}/S{speed}";
        }
        public void AddStateToQTable()
        {
            double alpha = 0.9;
            double gamma = 1;
            Episodes.Add(new Episode("extraspace", null));
            for (int i = Episodes.Count - 2; i >= 0; i--)
            {
                if (Qtables.Count == 0 || !(Qtables.ContainsKey(Episodes[i].State)))
                {
                    Qtables.Add(Episodes[i].State, new List<double>());
                    for (int j = 0; j < 5; j++)
                    {
                        Qtables[Episodes[i].State].Add(0);
                    }
                }
                double news = (1 - alpha) * Qtables[Episodes[i].State][Actions.IndexOf(Episodes[i].Action)] + alpha * (Episodes[i].Reward + gamma * Qtables[Episodes[i + 1].State].Max());
                Qtables[Episodes[i].State][Actions.IndexOf(Episodes[i].Action)] = news;
            }
            SaveLearn(FileName);
            Episodes.Clear();

        }
        public void AddStepToEpisode(Episode e)
        {
            Episodes.Add(e);
        }
        public Action SelectAction(List<Action> actions, string state)
        {
            Random possibilityofRandAction = new();
            //FindTheSimilarState(state);
            if (Face < Train)
            {
                //(n-x)/n
                if (possibilityofRandAction.Next(1, Train) < Train - Face)
                {
                    Random r = new();
                    return actions[r.Next(0, actions.Count)];
                }
                Face++;
            }
            if (Qtables.ContainsKey(state))
            {
                int index = Qtables[state].IndexOf(Qtables[state].Max());
                return actions[index];
            }
            //string similarstate = FindTheSimilarState(state);
            //return actions[Qtables[similarstate].IndexOf(Qtables[similarstate].Max())];
            Random f = new();
            return actions[f.Next(0, actions.Count)];
        }
        public string FindTheSimilarState(string firststate)
        {
            List<string> keys = Qtables.Keys.ToList();
            keys.Sort();
            List<List<double>> keysfrequenzes = new();
            foreach (string key in keys)
            {
                string[] arr = key.Split('/');
                foreach (string s in arr)
                {
                    char[] charToRemove = { 'H', 'V', 'L', 'R', 'D', 'S' };
                }
            }

            return "";
        }
        public void OpenSavedLearn(string name)
        {
            string[] line = File.ReadAllLines(name);
            Dictionary<string, List<double>> learn = new();
            foreach (string s in line)
            {
                string[] KeyAndElement = s.Split('\\');
                string key = KeyAndElement[0].Trim('[', ']');
                string value = KeyAndElement[1].Trim('[', ']');
                value = value.Trim(';');
                string[] valueString = value.Split(';');
                double[] values = new double[valueString.Length];
                for (int i = 0; i < valueString.Count(); i++)
                {
                    if (valueString[i] != "")
                    {
                        values[i] = Convert.ToDouble(valueString[i]);
                    }
                }
                learn.Add(key, values.ToList());
            }
            Qtables = learn;
        }
        public void SaveLearn(string name)
        {
            // line is made in this way [key]\[Action0;Action1;Action2...]
            foreach (var r in Qtables)
            {
                Console.Write(r.Key);
                foreach (var strin in r.Value)
                {
                    Console.Write(" " + strin);
                }
                Console.WriteLine();
            }
            if (File.Exists(name))
            {
                var a = Qtables.OrderBy(x => x.Key).Select(x => x.Key);
                var b = Qtables.OrderBy(x => x.Key).Select(x => x.Value);
                List<string> fil = new();
                foreach (var element in Qtables)
                {
                    string ris = "[" + element.Key + "]\\[";
                    foreach (var number in element.Value)
                    {
                        ris += number + ";";
                    }
                    ris += "]";
                    fil.Add(ris);
                }
                fil.Sort();
                File.WriteAllLines(name, fil);

            }
            else
            {
                File.Create(name);
            }
        }
    }
}
