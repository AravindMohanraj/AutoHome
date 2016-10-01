namespace AutoHome
{
    partial class Diagnosis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Diagnosis));
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.rbtnFrom = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.rbtnMonthwise = new System.Windows.Forms.RadioButton();
            this.rbtnDaywise = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtnYearwise = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnToday = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(192, 169);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(120, 26);
            this.dateTimePicker2.TabIndex = 25;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // rbtnFrom
            // 
            this.rbtnFrom.AutoSize = true;
            this.rbtnFrom.BackColor = System.Drawing.Color.Transparent;
            this.rbtnFrom.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.rbtnFrom.Location = new System.Drawing.Point(33, 134);
            this.rbtnFrom.Name = "rbtnFrom";
            this.rbtnFrom.Size = new System.Drawing.Size(89, 29);
            this.rbtnFrom.TabIndex = 22;
            this.rbtnFrom.TabStop = true;
            this.rbtnFrom.Text = "From";
            this.rbtnFrom.UseVisualStyleBackColor = false;
            this.rbtnFrom.CheckedChanged += new System.EventHandler(this.rbtnFrom_CheckedChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(33, 169);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(124, 26);
            this.dateTimePicker1.TabIndex = 24;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // rbtnMonthwise
            // 
            this.rbtnMonthwise.AutoSize = true;
            this.rbtnMonthwise.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnMonthwise.Location = new System.Drawing.Point(3, 114);
            this.rbtnMonthwise.Name = "rbtnMonthwise";
            this.rbtnMonthwise.Size = new System.Drawing.Size(156, 29);
            this.rbtnMonthwise.TabIndex = 20;
            this.rbtnMonthwise.TabStop = true;
            this.rbtnMonthwise.Text = "Month wise";
            this.rbtnMonthwise.UseVisualStyleBackColor = true;
            this.rbtnMonthwise.Click += new System.EventHandler(this.rbtnMonthwise_Click);
            // 
            // rbtnDaywise
            // 
            this.rbtnDaywise.AutoSize = true;
            this.rbtnDaywise.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnDaywise.Location = new System.Drawing.Point(11, 17);
            this.rbtnDaywise.Name = "rbtnDaywise";
            this.rbtnDaywise.Size = new System.Drawing.Size(126, 29);
            this.rbtnDaywise.TabIndex = 18;
            this.rbtnDaywise.TabStop = true;
            this.rbtnDaywise.Text = "Day wise";
            this.rbtnDaywise.UseVisualStyleBackColor = true;
            this.rbtnDaywise.Click += new System.EventHandler(this.rbtnDaywise_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "To";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbtnMonthwise);
            this.panel2.Controls.Add(this.rbtnDaywise);
            this.panel2.Controls.Add(this.rbtnYearwise);
            this.panel2.Location = new System.Drawing.Point(26, 347);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(164, 273);
            this.panel2.TabIndex = 20;
            // 
            // rbtnYearwise
            // 
            this.rbtnYearwise.AutoSize = true;
            this.rbtnYearwise.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnYearwise.Location = new System.Drawing.Point(11, 217);
            this.rbtnYearwise.Name = "rbtnYearwise";
            this.rbtnYearwise.Size = new System.Drawing.Size(134, 29);
            this.rbtnYearwise.TabIndex = 21;
            this.rbtnYearwise.TabStop = true;
            this.rbtnYearwise.Text = "Year wise";
            this.rbtnYearwise.UseVisualStyleBackColor = true;
            this.rbtnYearwise.Click += new System.EventHandler(this.rbtnYearwise_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Bisque;
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.rbtnToday);
            this.panel1.Controls.Add(this.rbtnFrom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(13, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1424, 662);
            this.panel1.TabIndex = 20;
            // 
            // rbtnToday
            // 
            this.rbtnToday.AutoSize = true;
            this.rbtnToday.BackColor = System.Drawing.Color.Transparent;
            this.rbtnToday.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnToday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.rbtnToday.Location = new System.Drawing.Point(39, 60);
            this.rbtnToday.Name = "rbtnToday";
            this.rbtnToday.Size = new System.Drawing.Size(96, 29);
            this.rbtnToday.TabIndex = 16;
            this.rbtnToday.TabStop = true;
            this.rbtnToday.Text = "Today";
            this.rbtnToday.UseVisualStyleBackColor = false;
            this.rbtnToday.CheckedChanged += new System.EventHandler(this.rbtnToday_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(318, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(748, 599);
            this.dataGridView1.TabIndex = 28;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::AutoHome.Properties.Resources.title_form;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(12, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1067, 54);
            this.panel4.TabIndex = 61;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(2, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Diagonosis\'s History";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(206)))), ((int)(((byte)(104)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(263, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Click Today or Enter Specific Date";
            // 
            // panel9
            // 
            this.panel9.BackgroundImage = global::AutoHome.Properties.Resources.top;
            this.panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel9.Location = new System.Drawing.Point(-3, 681);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1091, 20);
            this.panel9.TabIndex = 70;
            // 
            // Diagnosis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1364, 750);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Diagnosis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DIAGONOSI\'S";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Diagnosis_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.RadioButton rbtnFrom;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton rbtnMonthwise;
        private System.Windows.Forms.RadioButton rbtnDaywise;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbtnYearwise;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtnToday;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel9;

    }
}