
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
            for (int i = 0; i < a.Count; i++)
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
                    for (int j = 0; j < Actions.Count; j++)
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
            if (Qtables.ContainsKey(state))
            {
                int index = Qtables[state].IndexOf(Qtables[state].Max());
                return actions[index];
            }
            string similarstate = FindTheSimilarState(state);
            return actions[Qtables[similarstate].IndexOf(Qtables[similarstate].Max())];
            //Random f = new();
            //return actions[f.Next(0, actions.Count)];
        }
        public static List<int> TransfomStateinList(string state)
        {
            List<int> values = new();
            bool isNumber = false;
            string number = "";
            string checkNumber = "0123456789";
            foreach (char c in state)
            {
                if (checkNumber.Contains(c))
                {
                    isNumber = true;
                }
                else
                {
                    isNumber = false;
                    if (number.Length > 0 )
                    {
                        values.Add(Convert.ToInt32(number));
                        number = "";
                    }
                }
                if (isNumber)
                {
                    number += c;
                }
            }
            if (isNumber)
            {
                values.Add(Convert.ToInt32(number));
            }
            return values;
        }
        public string FindTheSimilarState(string firststate)
        {
            List<string> keys = Qtables.Keys.ToList();
            keys.Sort();
            List<List<int>> keysfrequenzes = new();
            //state in a list of double
            List<int> valuefrequenzes = TransfomStateinList(firststate);
            //transform the list of keys in a list of list of double 
            foreach (string key in keys)
            {
                if (key != ExtraSpace)
                {
                    List<int> values = TransfomStateinList(key);
                    keysfrequenzes.Add(values);
                }
            }
            //calculate the cosine of firststate vector with all other vector 
            List<double> cosineDistance = new();
            foreach(List<int> l in keysfrequenzes)
            {
                cosineDistance.Add(CosineDistance(valuefrequenzes, l));
            }
            //return the minimun state with the minimun cosine distance
            return keys[cosineDistance.IndexOf(cosineDistance.Max()) + 1];
        }
        public double CosineDistance(List<int> vec1,List<int> vec2)
        {
            double s = 0;
            for (int i = 0; i < vec1.Count && i < vec2.Count; i++)
            {
                s += vec1[i] * vec2[i];
            }
            double v1 = 0;
            double v2 = 0;
            foreach (double d in vec1)
            {
                v1 += d * d;
            }
            foreach (double d in vec2)
            {
                v2 += d * d;
            }
            return s/(Math.Sqrt(v1) + Math.Sqrt(v2));
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
