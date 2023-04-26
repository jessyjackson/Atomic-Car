namespace AtomicDrive
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtgView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.lst1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboPath = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTry = new System.Windows.Forms.TextBox();
            this.lblTrain = new System.Windows.Forms.Label();
            this.btnTraining = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgView
            // 
            this.dtgView.AllowUserToAddRows = false;
            this.dtgView.AllowUserToDeleteRows = false;
            this.dtgView.AllowUserToResizeColumns = false;
            this.dtgView.AllowUserToResizeRows = false;
            this.dtgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgView.Location = new System.Drawing.Point(12, 12);
            this.dtgView.MultiSelect = false;
            this.dtgView.Name = "dtgView";
            this.dtgView.ReadOnly = true;
            this.dtgView.RowTemplate.Height = 25;
            this.dtgView.ShowCellErrors = false;
            this.dtgView.ShowCellToolTips = false;
            this.dtgView.ShowEditingIcon = false;
            this.dtgView.ShowRowErrors = false;
            this.dtgView.Size = new System.Drawing.Size(1086, 958);
            this.dtgView.TabIndex = 0;
            this.dtgView.SelectionChanged += new System.EventHandler(this.dtgView_SelectionChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lst1
            // 
            this.lst1.FormattingEnabled = true;
            this.lst1.ItemHeight = 15;
            this.lst1.Location = new System.Drawing.Point(6, 52);
            this.lst1.Name = "lst1";
            this.lst1.Size = new System.Drawing.Size(181, 499);
            this.lst1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lst1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(1104, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 573);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "car";
            // 
            // cboPath
            // 
            this.cboPath.FormattingEnabled = true;
            this.cboPath.Location = new System.Drawing.Point(6, 22);
            this.cboPath.Name = "cboPath";
            this.cboPath.Size = new System.Drawing.Size(121, 23);
            this.cboPath.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1440, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "ChangePath";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboPath);
            this.groupBox2.Location = new System.Drawing.Point(1334, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 131);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Path";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtTry);
            this.groupBox3.Controls.Add(this.lblTrain);
            this.groupBox3.Controls.Add(this.btnTraining);
            this.groupBox3.Location = new System.Drawing.Point(1334, 149);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(223, 172);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Training";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 143);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Random";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of move";
            // 
            // txtTry
            // 
            this.txtTry.Location = new System.Drawing.Point(8, 33);
            this.txtTry.Name = "txtTry";
            this.txtTry.Size = new System.Drawing.Size(100, 23);
            this.txtTry.TabIndex = 2;
            this.txtTry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTry_KeyPress);
            // 
            // lblTrain
            // 
            this.lblTrain.AutoSize = true;
            this.lblTrain.Location = new System.Drawing.Point(6, 90);
            this.lblTrain.Name = "lblTrain";
            this.lblTrain.Size = new System.Drawing.Size(38, 15);
            this.lblTrain.TabIndex = 1;
            this.lblTrain.Text = "Train: ";
            // 
            // btnTraining
            // 
            this.btnTraining.Location = new System.Drawing.Point(6, 64);
            this.btnTraining.Name = "btnTraining";
            this.btnTraining.Size = new System.Drawing.Size(97, 23);
            this.btnTraining.TabIndex = 0;
            this.btnTraining.Text = "Enable/Disable";
            this.btnTraining.UseVisualStyleBackColor = true;
            this.btnTraining.Click += new System.EventHandler(this.btnTraining_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDelete);
            this.groupBox4.Location = new System.Drawing.Point(1334, 485);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(223, 100);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Save";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(6, 22);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 46);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Delete Saved File";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1566, 1061);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dtgView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dtgView;
        private Button button1;
        private ListBox lst1;
        private GroupBox groupBox1;
        private ComboBox cboPath;
        private Button button2;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button btnTraining;
        private Label lblTrain;
        private GroupBox groupBox4;
        private Button btnDelete;
        private Label label1;
        private TextBox txtTry;
        private Button button3;
    }
}