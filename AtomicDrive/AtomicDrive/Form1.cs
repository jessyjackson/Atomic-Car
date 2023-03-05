namespace AtomicDrive
{
    public partial class Form1 : Form
    {
        private Car c;
        private Path p;
        private int morePixel = 5;
        public Form1()
        {
            InitializeComponent();
            p = new();
            c = new(p.CarStartCoordinate);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboPath.Items.AddRange(p.Actions.ToArray());
            dtgView.ColumnHeadersVisible = false;
            dtgView.RowHeadersVisible = false;
            DrawPath();
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
            dtgView[c.CarPosition.Item1 + morePixel, c.CarPosition.Item2 + morePixel].Style.BackColor = Color.Violet;
        }
        private void AdjustRowColumnHeight()
        {
            int rH = (dtgView.Height / dtgView.RowCount) - 1;
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

        private async Task StartGame()
        {
            lst1.Items.Clear();
            int n;
            for (int i = 0; i < 200000; i++)
            {
                n = c.HandleAction(p);
                lst1.Items.Add(c.Move + " " + (Car.CarActions)c.Actions.IndexOf(c.Action));
                dtgView[c.CarPosition.Item1 + morePixel, c.CarPosition.Item2 + morePixel].Style.BackColor = Color.Violet;

                if (n == -1)
                {
                    c.StopAndReset();
                    lst1.Items.Add("Schiantata");
                }
                if (n == 1)
                {
                    c.StopAndReset();
                    lst1.Items.Add("Vittoria");
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawPath();
            StartGame();
        }

        private void dtgView_SelectionChanged(object sender, EventArgs e)
        {
            dtgView.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p.ChangePath(cboPath.SelectedIndex);
            DrawPath();
        }
    }
}