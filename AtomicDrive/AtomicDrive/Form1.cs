namespace AtomicDrive
{
    public partial class Form1 : Form
    {
        private Car car;
        private Path path;
        private const int MORE_PIXEL = 5;
        private int MoveNumber = 1000;
        public bool Random = false;
        public Form1()
        {
            InitializeComponent();
            path = new();
            car = new(path.CarStartCoordinate,path.CarMaxPoints, path.StartDirection);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboPath.Items.AddRange(path.Actions.ToArray());
            dtgView.ColumnHeadersVisible = false;
            dtgView.RowHeadersVisible = false;
            DrawPath();
            EnableDisableTraining();
        }
        public void DrawPath()
        {

            dtgView.RowCount = path.Matrix.GetLength(0) + MORE_PIXEL * 2;
            dtgView.ColumnCount = path.Matrix.GetLength(1) + MORE_PIXEL * 2;
            AdjustRowColumnHeight();
            for (int i = 0; i < dtgView.RowCount; i++)
            {
                for (int j = 0; j < dtgView.ColumnCount; j++)
                {
                    dtgView[j,i].Style.BackColor = Color.White;
                }
            }
            for (int i = path.StartCoordinate.Item1; i <= path.EndCoordinate.Item1; i++)
            {
                for (int j = path.StartCoordinate.Item2; j <= path.EndCoordinate.Item2; j++)
                {
                    dtgView[i + MORE_PIXEL, j + MORE_PIXEL].Style.BackColor = Color.Red;
                }
            }
            for (int i = 0; i < path.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < path.Matrix.GetLength(1); j++)
                {
                    if (path.Matrix[i, j] == 1)
                    {
                        dtgView[j + MORE_PIXEL, i + MORE_PIXEL].Style.BackColor = Color.Black;
                    }
                }
            }
            dtgView[car.CarPosition.Item1 + MORE_PIXEL, car.CarPosition.Item2 + MORE_PIXEL].Style.BackColor = Color.DarkOrange;
}
        private void AdjustRowColumnHeight()
        {
            int rH = (dtgView.Height / dtgView.RowCount);
            if (rH > 0)
            {
                for (int i = 0; i < dtgView.RowCount; i++)
                {
                    dtgView.Rows[i].Height = rH;
                }
            }
            int cH = (dtgView.Width / dtgView.ColumnCount);
            if (cH > 0)
            {
                for (int i = 0; i < dtgView.ColumnCount; i++)
                {
                    dtgView.Columns[i].Width = cH;
                }
            }
        }
        public void DriveCar()
        {
            //questo è brutto
            car.StopAndReset(path,false);
            List<Step> episode = new();
            int state = 0;
            int move = 0;
            do
            {
                int actionResult = car.HandleAction(path);
                lst1.Items.Add(car.Move + " " + (Car.NameActions)car.Actions.IndexOf(car.Action) + " " + car.Direction);
                dtgView[car.CarPosition.Item1 + MORE_PIXEL, car.CarPosition.Item2 + MORE_PIXEL].Style.BackColor = Color.Violet;
                if (actionResult == -1)
                {
                    string s = car.Direction.ToString();
                    car.AddState();
                    car.StopAndReset(path, Random);
                   // lst1.Items.Add("numero mossa" + state);
                   lst1.Items.Add("Lost in direction: " + s + "-----------------");
                    state++;   
                }
                else if (actionResult == 1)
                {
                    var tempEpisode = car.GetSteps();
                    car.AddState();
                    car.StopAndReset(path, Random);
                    if (episode.Count == 0)
                    {
                        episode = tempEpisode;
                    }
                    else if (episode.Count > tempEpisode.Count)
                    {
                        episode = tempEpisode;
                    }
                    //lst1.Items.Add("numero mossa" + state);
                    lst1.Items.Add("Victory#############################");
                    if (car.Qlearn.Train == 0)
                    {
                        break;
                    }
                }
                move++;

            } while (state < MoveNumber);

            if (episode.Count > 0)
            {
                episode.RemoveAt(episode.Count - 1);
            }
            foreach (var step in episode)
            {
                dtgView[step.Position.Item1 + MORE_PIXEL, step.Position.Item2 + MORE_PIXEL].Style.BackColor = Color.Blue;
            }
            car.StopAndReset(path,false);
            car.Qlearn.Face = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DrawPath();
            lst1.Items.Clear();
            DriveCar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            path.ChangePath(cboPath.SelectedIndex);
            car.ChangePath(path.CarStartCoordinate, path.CarMaxPoints,path.StartDirection);
            DrawPath();
            lst1.Items.Clear();
            car.StopAndReset(path,false);
            InfoText();
        }

        private void btnTraining_Click(object sender, EventArgs e)
        {
            EnableDisableTraining();
            car.StopAndReset(path,false);
        }
        public void EnableDisableTraining()
        {
            if (txtTry.Text.Length > 0)
            {
                MoveNumber = Convert.ToInt32(txtTry.Text);
            }
            if (car.Qlearn.Train == 0)
            {
                float average = (((path.CarMaxPoints + path.CarMinMove) / 2) * MoveNumber);
                car.Qlearn.Train = (int)(average - (average * (0.3)));
                car.Qlearn.Face = 0;
            }
            else
            {
                car.Qlearn.Train = 0;
                car.Qlearn.Face = 0;
            }
            InfoText();
        }
        private void dtgView_SelectionChanged(object sender, EventArgs e)
        {
            dtgView.ClearSelection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            File.WriteAllText(car.Qlearn.FileName, String.Empty);
        }

        private void txtTry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random = !Random;
            InfoText();
        }
        public void InfoText()
        {
            float average = (((path.CarMaxPoints + path.CarMinMove) / 2) * MoveNumber);
            if (car.Qlearn.Train == 0)
            {

                lblTrain.Text =   "Training disable\n" 
                                + "Number of attempts: " + MoveNumber +"\n"
                                + "Random position: " + Random + "\n";
            }
            else
            {
                //lblTrain.Text = "Training Enable, " + MoveNumber + ",move\n" + average + "effective average move\n" + car.Qlearn.Train + " training move " + "\nRandom position: " + Random + "\n";
                lblTrain.Text = "Training enable\n"
                + "Number of attempts: " + MoveNumber + "\n"
                + "Random position: " + Random + "\n";
            }
        }
    }
}