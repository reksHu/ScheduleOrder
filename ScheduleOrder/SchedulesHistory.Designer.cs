namespace ScheduleOrder
{
    partial class SchedulesHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchedulesHistory));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelWeekDay = new System.Windows.Forms.Panel();
            this.dataGridHistory = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnWeekPicker = new System.Windows.Forms.Button();
            this.txtWeekDay = new System.Windows.Forms.TextBox();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.btnSetScheduleTemp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(31, 75);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 74);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panelWeekDay
            // 
            this.panelWeekDay.Location = new System.Drawing.Point(160, 75);
            this.panelWeekDay.Name = "panelWeekDay";
            this.panelWeekDay.Size = new System.Drawing.Size(855, 74);
            this.panelWeekDay.TabIndex = 2;
            // 
            // dataGridHistory
            // 
            this.dataGridHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHistory.Location = new System.Drawing.Point(31, 158);
            this.dataGridHistory.Name = "dataGridHistory";
            this.dataGridHistory.Size = new System.Drawing.Size(984, 468);
            this.dataGridHistory.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "选择排班日期(周为单位):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnWeekPicker
            // 
            this.btnWeekPicker.Image = ((System.Drawing.Image)(resources.GetObject("btnWeekPicker.Image")));
            this.btnWeekPicker.Location = new System.Drawing.Point(306, 21);
            this.btnWeekPicker.Name = "btnWeekPicker";
            this.btnWeekPicker.Size = new System.Drawing.Size(32, 23);
            this.btnWeekPicker.TabIndex = 7;
            this.btnWeekPicker.UseVisualStyleBackColor = true;
            // 
            // txtWeekDay
            // 
            this.txtWeekDay.Location = new System.Drawing.Point(170, 22);
            this.txtWeekDay.Name = "txtWeekDay";
            this.txtWeekDay.Size = new System.Drawing.Size(138, 20);
            this.txtWeekDay.TabIndex = 8;
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(171, 47);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 9;
            // 
            // btnSetScheduleTemp
            // 
            this.btnSetScheduleTemp.Location = new System.Drawing.Point(940, 632);
            this.btnSetScheduleTemp.Name = "btnSetScheduleTemp";
            this.btnSetScheduleTemp.Size = new System.Drawing.Size(75, 23);
            this.btnSetScheduleTemp.TabIndex = 10;
            this.btnSetScheduleTemp.Text = "选择为模板";
            this.btnSetScheduleTemp.UseVisualStyleBackColor = true;
            // 
            // SchedulesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 671);
            this.Controls.Add(this.btnSetScheduleTemp);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.txtWeekDay);
            this.Controls.Add(this.btnWeekPicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridHistory);
            this.Controls.Add(this.panelWeekDay);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SchedulesHistory";
            this.Text = "SchedulesHistory";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelWeekDay;
        private System.Windows.Forms.DataGridView dataGridHistory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnWeekPicker;
        private System.Windows.Forms.TextBox txtWeekDay;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Button btnSetScheduleTemp;
    }
}