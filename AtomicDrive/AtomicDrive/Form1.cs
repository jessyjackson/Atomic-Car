namespace AtomicDrive
{
    public partial class Form1 : Form
    {
        private Car c;
        private Path p;
        private int morePixel = 5;
        private int Try = 20000;
        public Form1()
        {
            InitializeComponent();
            p = new();
            c = new(p.CarStartCoordinate,p.CarPoints);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboPath.Items.AddRange(p.Actions.ToArray());
            dtgView.ColumnHeadersVisible = false;
            dtgView.RowHeadersVisible = false;
            DrawPath();
            EnableDisableTraining();
        }
        public void DrawPath()
        {

            dtgView.RowCount = p.Matrix.GetLength(0) + morePixel * 2;
            dtgView.ColumnCount = p.Matrix.GetLength(1) + morePixel * 2;
            AdjustRowColumnHeight();
            for (int i = 0; i < dtgView.RowCount; i++)
            {
                for (int j = 0; j < dtgView.ColumnCount; j++)
                {
                    dtgView[i, j].Style.BackColor = Color.White;
                }
            }
            for (int i = p.StartCoordinate.Item1; i <= p.EndCoordinate.Item1; i++)
            {
                for (int j = p.StartCoordinate.Item2; j <= p.EndCoordinate.Item2; j++)
                {
                    dtgView[i + morePixel, j + morePixel].Style.BackColor = Color.Red;
                }
            }
            for (int i = 0; i < p.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < p.Matrix.GetLength(1); j++)
                {
                    if (p.Matrix[i, j] == 1)
                    {
                        dtgView[j + morePixel, i + morePixel].Style.BackColor = Color.Black;
                    }
                }
            }
            dtgView[c.CarPosition.Item1 + morePixel, c.CarPosition.Item2 + morePixel].Style.BackColor = Color.DarkOrange;
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
            for (int i = 0; i < Try; i++)
            {
                int n = c.HandleAction(p);
                lst1.Items.Add(c.Move + " " + (Car.NameActions)c.Actions.IndexOf(c.Action));
                dtgView[c.CarPosition.Item1 + morePixel, c.CarPosition.Item2 + morePixel].Style.BackColor = Color.Violet;
                if (n == -1)
                {
                    c.StopAndReset();
                    lst1.Items.Add("Schiantata");
                }
                if (n == 1)
                {
                    episode = c.StopAndReset();
                    lst1.Items.Add("Vittoria");
                    if (c.Qlearn.Train == 0)
                    {
                        break;
                    }
                }
            }
            foreach (var step in episode)
            {
                dtgView[step.Position.Item1 + morePixel, step.Position.Item2 + morePixel].Style.BackColor = Color.Blue;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            lst1.Items.Clear();
            DrawPath();
            DriveCar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p.ChangePath(cboPath.SelectedIndex);
            DrawPath();
        }

        private void btnTraining_Click(object sender, EventArgs e)
        {
            EnableDisableTraining();
        }
        public void EnableDisableTraining()
        {
            if (c.Qlearn.Train == 0)
            {
                c.Qlearn.Train = (int)(Try - (Try * (0.1)));
            }
            else
            {
                c.Qlearn.Train = 0;
            }
            lblTrain.Text = "Training Enable, " + c.Qlearn.Train + " try";
        }
        private void dtgView_SelectionChanged(object sender, EventArgs e)
        {
            dtgView.ClearSelection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //File.Delete(c.Qlearn.FileName);
            //File.Create(c.Qlearn.FileName);
        }
    }
}