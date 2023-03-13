namespace AtomicDrive
{
    public partial class Form1 : Form
    {
        private Car car;
        private Path path;
        private const int MORE_PIXEL = 5;
        private int MoveNumber = 20000;
        public Form1()
        {
            InitializeComponent();
            path = new();
            car = new(path.CarStartCoordinate,path.CarPoints, path.StartDirection);
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
                    dtgView[i, j].Style.BackColor = Color.White;
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
            int rH = (dtgView.Height / dtgView.RowCount)- 1;
            if (rH > 0)
            {
                for (int i = 0; i < dtgView.RowCount; i++)
                {
                    dtgView.Rows[i].Height = rH;
                }
            }
            int cH = (dtgView.Width / dtgView.ColumnCount) - 1;
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
            List<Step> episode = new() ;
            for (int i = 0; i < MoveNumber; i++)
            {
                int n = car.HandleAction(path);
                lst1.Items.Add(car.Move + " " + (Car.NameActions)car.Actions.IndexOf(car.Action) + " " + car.Direction);
                dtgView[car.CarPosition.Item1 + MORE_PIXEL, car.CarPosition.Item2 + MORE_PIXEL].Style.BackColor = Color.Violet;
                if (n == -1)
                {
                    string s = car.Direction.ToString();
                    car.AddState();
                    car.StopAndReset();
                    lst1.Items.Add("Schiantata:" + s);
                }
                if (n == 1)
                {
                    var tempEpisode = car.GetSteps();
                    car.AddState();
                    car.StopAndReset();
                    if (episode.Count == 0)
                    {
                        episode = tempEpisode;
                    }
                    else if (episode.Count > tempEpisode.Count)
                    {
                        episode = tempEpisode;
                    }
                    lst1.Items.Add("Vittoria#############################");
                    if (car.Qlearn.Train == 0)
                    {
                        break;
                    }
                }
            }
            //potrebbero sovrascriversi i dati nuovi con quelli vecchi, bisogna vedere se quando la macchina si schianta ritorna a capo con tutto e se quando alla fine di un 
            //ciclo ne faccio partire una altro bisogna controllare che tutto si resetti per bene
            //e aggiunge azioni mai fatte
            if (episode.Count > 0)
            {
                episode.RemoveAt(episode.Count - 1);
            }
            foreach (var step in episode)
            {
                dtgView[step.Position.Item1 + MORE_PIXEL, step.Position.Item2 + MORE_PIXEL].Style.BackColor = Color.Blue;
            }
            car.StopAndReset();
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
            car.ChangePath(path.CarStartCoordinate, path.CarPoints,path.StartDirection);
            DrawPath();
            lst1.Items.Clear();
            car.StopAndReset();
        }

        private void btnTraining_Click(object sender, EventArgs e)
        {
            EnableDisableTraining();
        }
        public void EnableDisableTraining()
        {
            if (txtTry.Text.Length > 0)
            {
                MoveNumber = Convert.ToInt32(txtTry.Text);
            }
            if (car.Qlearn.Train == 0)
            {
                car.Qlearn.Train = (int)(MoveNumber - (MoveNumber * (0.1)));
                car.Qlearn.Face = 0;
                lblTrain.Text = "Training Enable, " + MoveNumber + ", move\n" + " " + car.Qlearn.Train + " training move";
            }
            else
            {
                car.Qlearn.Train = 0;
                car.Qlearn.Face = 0;
                lblTrain.Text = "Training Disable, " + MoveNumber + ", move\n" + " " + car.Qlearn.Train + " training move";
            }
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
    }
}