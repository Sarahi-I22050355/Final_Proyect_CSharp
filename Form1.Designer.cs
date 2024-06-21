namespace Final_Proyect_CSharp
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
            dgvSongs = new DataGridView();
            btnCSV = new Button();
            btnXML = new Button();
            btnJSON = new Button();
            button1 = new Button();
            btnSaveSQL = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSongs).BeginInit();
            SuspendLayout();
            // 
            // dgvSongs
            // 
            dgvSongs.BackgroundColor = SystemColors.ControlDarkDark;
            dgvSongs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSongs.Location = new Point(12, 12);
            dgvSongs.Name = "dgvSongs";
            dgvSongs.RowHeadersWidth = 51;
            dgvSongs.Size = new Size(666, 377);
            dgvSongs.TabIndex = 0;
            dgvSongs.CellValueChanged += dgvSongs_CellValueChanged;
            // 
            // btnCSV
            // 
            btnCSV.Location = new Point(694, 149);
            btnCSV.Name = "btnCSV";
            btnCSV.Size = new Size(103, 44);
            btnCSV.TabIndex = 1;
            btnCSV.Text = "CSV";
            btnCSV.UseVisualStyleBackColor = true;
            btnCSV.Click += btnCSV_Click;
            // 
            // btnXML
            // 
            btnXML.Location = new Point(694, 199);
            btnXML.Name = "btnXML";
            btnXML.Size = new Size(103, 44);
            btnXML.TabIndex = 2;
            btnXML.Text = "XML";
            btnXML.UseVisualStyleBackColor = true;
            btnXML.Click += btnXML_Click;
            // 
            // btnJSON
            // 
            btnJSON.Location = new Point(694, 249);
            btnJSON.Name = "btnJSON";
            btnJSON.Size = new Size(103, 44);
            btnJSON.TabIndex = 3;
            btnJSON.Text = "JSON";
            btnJSON.UseVisualStyleBackColor = true;
            btnJSON.Click += btnJSON_Click;
            // 
            // button1
            // 
            button1.Location = new Point(694, 299);
            button1.Name = "button1";
            button1.Size = new Size(103, 44);
            button1.TabIndex = 4;
            button1.Text = "PDF";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnSaveSQL
            // 
            btnSaveSQL.Location = new Point(694, 26);
            btnSaveSQL.Name = "btnSaveSQL";
            btnSaveSQL.Size = new Size(103, 44);
            btnSaveSQL.TabIndex = 5;
            btnSaveSQL.Text = "Save";
            btnSaveSQL.UseVisualStyleBackColor = true;
            btnSaveSQL.Click += btnSaveSQL_Click;
            // 
            // button2
            // 
            button2.Location = new Point(694, 76);
            button2.Name = "button2";
            button2.Size = new Size(103, 44);
            button2.TabIndex = 6;
            button2.Text = "Reset";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 192);
            ClientSize = new Size(812, 411);
            Controls.Add(button2);
            Controls.Add(btnSaveSQL);
            Controls.Add(button1);
            Controls.Add(btnJSON);
            Controls.Add(btnXML);
            Controls.Add(btnCSV);
            Controls.Add(dgvSongs);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRUD";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSongs).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvSongs;
        private Button btnCSV;
        private Button btnXML;
        private Button btnJSON;
        private Button button1;
        private Button btnSaveSQL;
        private Button button2;
        private Button btnOpenFile;
    }

}
