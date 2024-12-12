namespace LKSMart
{
    partial class ActivityControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dateSampai = new System.Windows.Forms.DateTimePicker();
            this.dateDari = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataRead = new System.Windows.Forms.DataGridView();
            this.labelTanggal = new System.Windows.Forms.Label();
            this.labelWaktu = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.labelCurentPage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataRead)).BeginInit();
            this.SuspendLayout();
            // 
            // dateSampai
            // 
            this.dateSampai.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateSampai.Location = new System.Drawing.Point(27, 163);
            this.dateSampai.Name = "dateSampai";
            this.dateSampai.Size = new System.Drawing.Size(319, 26);
            this.dateSampai.TabIndex = 5;
            // 
            // dateDari
            // 
            this.dateDari.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDari.Location = new System.Drawing.Point(27, 131);
            this.dateDari.Name = "dateDari";
            this.dateDari.Size = new System.Drawing.Size(116, 26);
            this.dateDari.TabIndex = 6;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(101)))), ((int)(((byte)(134)))));
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Location = new System.Drawing.Point(225, 249);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(76, 37);
            this.btnFilter.TabIndex = 7;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(101)))), ((int)(((byte)(134)))));
            this.label1.Location = new System.Drawing.Point(20, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 37);
            this.label1.TabIndex = 8;
            this.label1.Text = "LOG ACTIVITY";
            // 
            // dataRead
            // 
            this.dataRead.AllowUserToAddRows = false;
            this.dataRead.AllowUserToDeleteRows = false;
            this.dataRead.AllowUserToResizeColumns = false;
            this.dataRead.AllowUserToResizeRows = false;
            this.dataRead.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataRead.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataRead.ColumnHeadersHeight = 34;
            this.dataRead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataRead.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataRead.Location = new System.Drawing.Point(27, 437);
            this.dataRead.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataRead.Name = "dataRead";
            this.dataRead.ReadOnly = true;
            this.dataRead.RowHeadersVisible = false;
            this.dataRead.RowHeadersWidth = 62;
            this.dataRead.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataRead.Size = new System.Drawing.Size(682, 287);
            this.dataRead.TabIndex = 9;
            // 
            // labelTanggal
            // 
            this.labelTanggal.AutoSize = true;
            this.labelTanggal.Location = new System.Drawing.Point(542, 35);
            this.labelTanggal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTanggal.Name = "labelTanggal";
            this.labelTanggal.Size = new System.Drawing.Size(18, 20);
            this.labelTanggal.TabIndex = 10;
            this.labelTanggal.Text = "1";
            // 
            // labelWaktu
            // 
            this.labelWaktu.AutoSize = true;
            this.labelWaktu.Location = new System.Drawing.Point(488, 102);
            this.labelWaktu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWaktu.Name = "labelWaktu";
            this.labelWaktu.Size = new System.Drawing.Size(18, 20);
            this.labelWaktu.TabIndex = 11;
            this.labelWaktu.Text = "1";
            // 
            // btnNext
            // 
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(466, 310);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(50, 50);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Location = new System.Drawing.Point(388, 310);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(50, 50);
            this.btnPrevious.TabIndex = 12;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // labelCurentPage
            // 
            this.labelCurentPage.AutoSize = true;
            this.labelCurentPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labelCurentPage.Location = new System.Drawing.Point(400, 228);
            this.labelCurentPage.Name = "labelCurentPage";
            this.labelCurentPage.Size = new System.Drawing.Size(18, 20);
            this.labelCurentPage.TabIndex = 13;
            this.labelCurentPage.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(555, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 22);
            this.label3.TabIndex = 15;
            this.label3.Text = "Pages / Dashboard";
            // 
            // ActivityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelCurentPage);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.labelWaktu);
            this.Controls.Add(this.labelTanggal);
            this.Controls.Add(this.dataRead);
            this.Controls.Add(this.dateSampai);
            this.Controls.Add(this.dateDari);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.label1);
            this.Name = "ActivityControl";
            this.Size = new System.Drawing.Size(750, 769);
            this.Load += new System.EventHandler(this.ActivityControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataRead)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateSampai;
        private System.Windows.Forms.DateTimePicker dateDari;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataRead;
        private System.Windows.Forms.Label labelTanggal;
        private System.Windows.Forms.Label labelWaktu;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label labelCurentPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
