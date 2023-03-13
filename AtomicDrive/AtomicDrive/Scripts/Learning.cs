
namespace AtomicDrive
{
    internal class Learning
    {
        public int Train { get; set; } = 180000;
        public string ExtraSpace { get; set; } = "extraspace";
        public string FileName { get; set; } = "log.txt";
        public int Face { get; set; } = 0;
        public Dictionary<string, List<double>> Qtables = new();
        public List<Step> Episode { get; set; } = new();
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
            if (!Qtables.ContainsKey(ExtraSpace))
            {
                Qtables.Add(ExtraSpace, l);
            }
        }
        public List<Step> GetSteps()
        {
            return Episode;
        }
        public string CreateState(Dictionary<int, int> frequences, int speed)
        {
            // Horizontal/Vertical/RightDiagonal/LeftDiagonal/Speed
            return $"H{frequences[0]}/V{frequences[90]}/RD{frequences[45]}/LD{frequences[135]}/S{speed}";
        }
        public void AddStateToQTable()
        {
            double alpha = 0.8;
            double gamma = 0.7;
            Episode.Add(new Step(ExtraSpace, null));
            for (int i = Episode.Count - 2; i >= 0; i--)
            {
                if (Qtables.Count == 0 || !(Qtables.ContainsKey(Episode[i].State)))
                {
                    Qtables.Add(Episode[i].State, new List<double>());
                    for (int j = 0; j < 5; j++)
                    {
                        Qtables[Episode[i].State].Add(0);
                    }
                }
                double news = (1 - alpha) * Qtables[Episode[i].State][Actions!.IndexOf(Episode[i].Action)] + alpha * (Episode[i+1].Reward + gamma * Qtables[Episode[i + 1].State].Max());
                Qtables[Episode[i].State][Actions.IndexOf(Episode[i].Action)] = news;
            }
            SaveLearn(FileName);
            DeleteEpisode();
        }
        public void DeleteEpisode()
        {
            Episode = new();
        }
        public void AddStepToEpisode(Step e)
        {
            Episode.Add(e);
        }
        public Action SelectAction(List<Action> actions, string state)
        {
            Random possibilityofRandAction = new();
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
            if(Qtables.ContainsKey(state))
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

            //non mi piace
            foreach (string key in keys)
            {
                if (key != ExtraSpace)
                {
                    string[] arr = key.Split('/');
                    foreach (string s in arr)
                    {
                        char[] charToRemove = { 'H', 'V', 'L', 'R', 'D', 'S' };
                        foreach (char c in charToRemove)
                        {
                            s.Replace(c, '&');
                        }

                    }
                    List<double> firstStateFrequenzes = new();
                    foreach (string val in arr)
                    {
                        firstStateFrequenzes.Add(Convert.ToDouble(val));
                    }
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
            if (!File.Exists(name))
            {
                File.Create(name);

            }
            var orderQtable = Qtables.OrderBy(x => x.Key);
            var a = orderQtable.Select(x => x.Key);
            var b = orderQtable.Select(x => x.Value);
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
    }
}
