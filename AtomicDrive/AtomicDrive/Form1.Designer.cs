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
            ((System.ComponentModel.ISupportInitialize)(this.dtgView)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.dtgView.Size = new System.Drawing.Size(595, 573);
            this.dtgView.TabIndex = 0;
            this.dtgView.SelectionChanged += new System.EventHandler(this.dtgView_SelectionChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(613, 35);
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
            this.groupBox1.Location = new System.Drawing.Point(613, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 573);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Car";
            // 
            // cboPath
            // 
            this.cboPath.FormattingEnabled = true;
            this.cboPath.Location = new System.Drawing.Point(922, 36);
            this.cboPath.Name = "cboPath";
            this.cboPath.Size = new System.Drawing.Size(121, 23);
            this.cboPath.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(949, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "ChangePath";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(843, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 131);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Path";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 597);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cboPath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtgView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgView)).EndInit();
            this.groupBox1.ResumeLayout(false);
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
    }
}