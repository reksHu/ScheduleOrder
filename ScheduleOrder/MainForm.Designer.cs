﻿namespace ScheduleOrder
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabReport = new System.Windows.Forms.TabPage();
            this.btnExportReport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridReporting = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.datePickerReporing = new System.Windows.Forms.DateTimePicker();
            this.jobManager = new System.Windows.Forms.TabPage();
            this.lbJobMsg = new System.Windows.Forms.Label();
            this.btnJobRollback = new System.Windows.Forms.Button();
            this.btn_JobClear = new System.Windows.Forms.Button();
            this.btnJobSave = new System.Windows.Forms.Button();
            this.jobGridView = new System.Windows.Forms.DataGridView();
            this.JobName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userManager = new System.Windows.Forms.TabPage();
            this.btnNusersRollback = new System.Windows.Forms.Button();
            this.btn_NursersClear = new System.Windows.Forms.Button();
            this.btnNurserSave = new System.Windows.Forms.Button();
            this.nurseGrid = new System.Windows.Forms.DataGridView();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nurseLevelIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nurseId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.schedule = new System.Windows.Forms.TabPage();
            this.btnUploadSchedule = new System.Windows.Forms.Button();
            this.lable_message = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSechduleRollback = new System.Windows.Forms.Button();
            this.btnWeekPicker = new System.Windows.Forms.Button();
            this.txtWeekDay = new System.Windows.Forms.TextBox();
            this.monthCalendarMain = new System.Windows.Forms.MonthCalendar();
            this.btnViewScheduleHistory = new System.Windows.Forms.Button();
            this.btnScheduleSave = new System.Windows.Forms.Button();
            this.dataGridView_home = new System.Windows.Forms.DataGridView();
            this.panel_week = new System.Windows.Forms.Panel();
            this.pic_schedule_time = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.lbMsg = new System.Windows.Forms.Label();
            this.lb_ExcelVersion = new System.Windows.Forms.Label();
            this.lb_version = new System.Windows.Forms.Label();
            this.contextMenu_rightclick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.StripMenuItem_Combine = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItem_NightShift = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItem_Night1 = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItem_Night2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReporting)).BeginInit();
            this.jobManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jobGridView)).BeginInit();
            this.userManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nurseGrid)).BeginInit();
            this.schedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_home)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_schedule_time)).BeginInit();
            this.tabMain.SuspendLayout();
            this.contextMenu_rightclick.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabReport
            // 
            this.tabReport.Controls.Add(this.btnExportReport);
            this.tabReport.Controls.Add(this.label2);
            this.tabReport.Controls.Add(this.dataGridReporting);
            this.tabReport.Controls.Add(this.label1);
            this.tabReport.Controls.Add(this.datePickerReporing);
            this.tabReport.Location = new System.Drawing.Point(4, 22);
            this.tabReport.Name = "tabReport";
            this.tabReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabReport.Size = new System.Drawing.Size(1102, 618);
            this.tabReport.TabIndex = 4;
            this.tabReport.Text = "统计报表";
            this.tabReport.UseVisualStyleBackColor = true;
            // 
            // btnExportReport
            // 
            this.btnExportReport.Location = new System.Drawing.Point(980, 559);
            this.btnExportReport.Name = "btnExportReport";
            this.btnExportReport.Size = new System.Drawing.Size(86, 23);
            this.btnExportReport.TabIndex = 4;
            this.btnExportReport.Text = "导出到Excel";
            this.btnExportReport.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "统计出所选月份每位护士的值班情况.";
            // 
            // dataGridReporting
            // 
            this.dataGridReporting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReporting.Location = new System.Drawing.Point(25, 84);
            this.dataGridReporting.MinimumSize = new System.Drawing.Size(800, 0);
            this.dataGridReporting.Name = "dataGridReporting";
            this.dataGridReporting.Size = new System.Drawing.Size(1041, 469);
            this.dataGridReporting.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择查询月份";
            // 
            // datePickerReporing
            // 
            this.datePickerReporing.Location = new System.Drawing.Point(107, 31);
            this.datePickerReporing.Name = "datePickerReporing";
            this.datePickerReporing.Size = new System.Drawing.Size(136, 20);
            this.datePickerReporing.TabIndex = 0;
            // 
            // jobManager
            // 
            this.jobManager.Controls.Add(this.lbJobMsg);
            this.jobManager.Controls.Add(this.btnJobRollback);
            this.jobManager.Controls.Add(this.btn_JobClear);
            this.jobManager.Controls.Add(this.btnJobSave);
            this.jobManager.Controls.Add(this.jobGridView);
            this.jobManager.Location = new System.Drawing.Point(4, 22);
            this.jobManager.Name = "jobManager";
            this.jobManager.Size = new System.Drawing.Size(1102, 618);
            this.jobManager.TabIndex = 3;
            this.jobManager.Text = "岗位管理";
            this.jobManager.UseVisualStyleBackColor = true;
            // 
            // lbJobMsg
            // 
            this.lbJobMsg.AutoSize = true;
            this.lbJobMsg.Location = new System.Drawing.Point(410, 20);
            this.lbJobMsg.Name = "lbJobMsg";
            this.lbJobMsg.Size = new System.Drawing.Size(35, 13);
            this.lbJobMsg.TabIndex = 4;
            this.lbJobMsg.Text = "label4";
            // 
            // btnJobRollback
            // 
            this.btnJobRollback.Location = new System.Drawing.Point(594, 484);
            this.btnJobRollback.Name = "btnJobRollback";
            this.btnJobRollback.Size = new System.Drawing.Size(75, 23);
            this.btnJobRollback.TabIndex = 3;
            this.btnJobRollback.Text = "还原";
            this.btnJobRollback.UseVisualStyleBackColor = true;
            // 
            // btn_JobClear
            // 
            this.btn_JobClear.Location = new System.Drawing.Point(91, 482);
            this.btn_JobClear.Name = "btn_JobClear";
            this.btn_JobClear.Size = new System.Drawing.Size(75, 23);
            this.btn_JobClear.TabIndex = 2;
            this.btn_JobClear.Text = "清空数据";
            this.btn_JobClear.UseVisualStyleBackColor = true;
            // 
            // btnJobSave
            // 
            this.btnJobSave.Location = new System.Drawing.Point(680, 483);
            this.btnJobSave.Name = "btnJobSave";
            this.btnJobSave.Size = new System.Drawing.Size(75, 23);
            this.btnJobSave.TabIndex = 1;
            this.btnJobSave.Text = "保存";
            this.btnJobSave.UseVisualStyleBackColor = true;
            // 
            // jobGridView
            // 
            this.jobGridView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.jobGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.jobGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jobGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.JobName,
            this.JobIndex,
            this.id});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.jobGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.jobGridView.Location = new System.Drawing.Point(91, 37);
            this.jobGridView.MultiSelect = false;
            this.jobGridView.Name = "jobGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.jobGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.jobGridView.Size = new System.Drawing.Size(665, 442);
            this.jobGridView.TabIndex = 0;
            // 
            // JobName
            // 
            this.JobName.DataPropertyName = "JobName";
            this.JobName.Frozen = true;
            this.JobName.HeaderText = "岗位名称";
            this.JobName.Name = "JobName";
            this.JobName.Width = 420;
            // 
            // JobIndex
            // 
            this.JobIndex.DataPropertyName = "JobIndex";
            this.JobIndex.Frozen = true;
            this.JobIndex.HeaderText = "岗位系数";
            this.JobIndex.Name = "JobIndex";
            this.JobIndex.Width = 200;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.Frozen = true;
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // userManager
            // 
            this.userManager.Controls.Add(this.btnNusersRollback);
            this.userManager.Controls.Add(this.btn_NursersClear);
            this.userManager.Controls.Add(this.btnNurserSave);
            this.userManager.Controls.Add(this.nurseGrid);
            this.userManager.Location = new System.Drawing.Point(4, 22);
            this.userManager.Name = "userManager";
            this.userManager.Padding = new System.Windows.Forms.Padding(3);
            this.userManager.Size = new System.Drawing.Size(1102, 618);
            this.userManager.TabIndex = 1;
            this.userManager.Text = "人员管理";
            this.userManager.UseVisualStyleBackColor = true;
            // 
            // btnNusersRollback
            // 
            this.btnNusersRollback.Location = new System.Drawing.Point(647, 468);
            this.btnNusersRollback.Name = "btnNusersRollback";
            this.btnNusersRollback.Size = new System.Drawing.Size(75, 23);
            this.btnNusersRollback.TabIndex = 4;
            this.btnNusersRollback.Text = "还原";
            this.btnNusersRollback.UseVisualStyleBackColor = true;
            // 
            // btn_NursersClear
            // 
            this.btn_NursersClear.Location = new System.Drawing.Point(90, 467);
            this.btn_NursersClear.Name = "btn_NursersClear";
            this.btn_NursersClear.Size = new System.Drawing.Size(75, 23);
            this.btn_NursersClear.TabIndex = 3;
            this.btn_NursersClear.Text = "清空数据";
            this.btn_NursersClear.UseVisualStyleBackColor = true;
            // 
            // btnNurserSave
            // 
            this.btnNurserSave.Location = new System.Drawing.Point(738, 467);
            this.btnNurserSave.Name = "btnNurserSave";
            this.btnNurserSave.Size = new System.Drawing.Size(75, 23);
            this.btnNurserSave.TabIndex = 2;
            this.btnNurserSave.Text = "保存";
            this.btnNurserSave.UseVisualStyleBackColor = true;
            // 
            // nurseGrid
            // 
            this.nurseGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nurseGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.nurseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.nurseGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserName,
            this.Level,
            this.nurseLevelIndex,
            this.nurseId});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.nurseGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.nurseGrid.Location = new System.Drawing.Point(90, 37);
            this.nurseGrid.Name = "nurseGrid";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nurseGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.nurseGrid.Size = new System.Drawing.Size(723, 424);
            this.nurseGrid.TabIndex = 1;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "NurseName";
            this.UserName.HeaderText = "护士姓名";
            this.UserName.Name = "UserName";
            this.UserName.Width = 240;
            // 
            // Level
            // 
            this.Level.DataPropertyName = "Level";
            this.Level.HeaderText = "护士层级";
            this.Level.Name = "Level";
            this.Level.Width = 200;
            // 
            // nurseLevelIndex
            // 
            this.nurseLevelIndex.DataPropertyName = "LevelIndex";
            this.nurseLevelIndex.HeaderText = "护士层级系数";
            this.nurseLevelIndex.Name = "nurseLevelIndex";
            this.nurseLevelIndex.Width = 240;
            // 
            // nurseId
            // 
            this.nurseId.DataPropertyName = "id";
            this.nurseId.HeaderText = "Id";
            this.nurseId.Name = "nurseId";
            this.nurseId.Visible = false;
            // 
            // schedule
            // 
            this.schedule.Controls.Add(this.btnUploadSchedule);
            this.schedule.Controls.Add(this.lable_message);
            this.schedule.Controls.Add(this.btnPrint);
            this.schedule.Controls.Add(this.btnSechduleRollback);
            this.schedule.Controls.Add(this.btnWeekPicker);
            this.schedule.Controls.Add(this.txtWeekDay);
            this.schedule.Controls.Add(this.monthCalendarMain);
            this.schedule.Controls.Add(this.btnViewScheduleHistory);
            this.schedule.Controls.Add(this.btnScheduleSave);
            this.schedule.Controls.Add(this.dataGridView_home);
            this.schedule.Controls.Add(this.panel_week);
            this.schedule.Controls.Add(this.pic_schedule_time);
            this.schedule.Controls.Add(this.label3);
            this.schedule.Location = new System.Drawing.Point(4, 22);
            this.schedule.Name = "schedule";
            this.schedule.Padding = new System.Windows.Forms.Padding(3);
            this.schedule.Size = new System.Drawing.Size(1102, 618);
            this.schedule.TabIndex = 0;
            this.schedule.Text = "排班安排";
            this.schedule.UseVisualStyleBackColor = true;
            // 
            // btnUploadSchedule
            // 
            this.btnUploadSchedule.Location = new System.Drawing.Point(609, 559);
            this.btnUploadSchedule.Name = "btnUploadSchedule";
            this.btnUploadSchedule.Size = new System.Drawing.Size(75, 23);
            this.btnUploadSchedule.TabIndex = 18;
            this.btnUploadSchedule.Text = "上传排班表";
            this.btnUploadSchedule.UseVisualStyleBackColor = true;
            // 
            // lable_message
            // 
            this.lable_message.AutoSize = true;
            this.lable_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable_message.ForeColor = System.Drawing.Color.ForestGreen;
            this.lable_message.Location = new System.Drawing.Point(633, 16);
            this.lable_message.Name = "lable_message";
            this.lable_message.Size = new System.Drawing.Size(64, 25);
            this.lable_message.TabIndex = 0;
            this.lable_message.Text = "label2";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(713, 559);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(88, 23);
            this.btnPrint.TabIndex = 17;
            this.btnPrint.Text = "打印到Excel";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnSechduleRollback
            // 
            this.btnSechduleRollback.Location = new System.Drawing.Point(828, 559);
            this.btnSechduleRollback.Name = "btnSechduleRollback";
            this.btnSechduleRollback.Size = new System.Drawing.Size(75, 23);
            this.btnSechduleRollback.TabIndex = 16;
            this.btnSechduleRollback.Text = "还原";
            this.btnSechduleRollback.UseVisualStyleBackColor = true;
            // 
            // btnWeekPicker
            // 
            this.btnWeekPicker.Image = ((System.Drawing.Image)(resources.GetObject("btnWeekPicker.Image")));
            this.btnWeekPicker.Location = new System.Drawing.Point(269, 24);
            this.btnWeekPicker.Name = "btnWeekPicker";
            this.btnWeekPicker.Size = new System.Drawing.Size(27, 23);
            this.btnWeekPicker.TabIndex = 15;
            this.btnWeekPicker.UseVisualStyleBackColor = true;
            // 
            // txtWeekDay
            // 
            this.txtWeekDay.Location = new System.Drawing.Point(148, 24);
            this.txtWeekDay.Name = "txtWeekDay";
            this.txtWeekDay.Size = new System.Drawing.Size(122, 20);
            this.txtWeekDay.TabIndex = 14;
            // 
            // monthCalendarMain
            // 
            this.monthCalendarMain.Location = new System.Drawing.Point(148, 50);
            this.monthCalendarMain.Name = "monthCalendarMain";
            this.monthCalendarMain.TabIndex = 13;
            // 
            // btnViewScheduleHistory
            // 
            this.btnViewScheduleHistory.Location = new System.Drawing.Point(370, 22);
            this.btnViewScheduleHistory.Name = "btnViewScheduleHistory";
            this.btnViewScheduleHistory.Size = new System.Drawing.Size(164, 23);
            this.btnViewScheduleHistory.TabIndex = 12;
            this.btnViewScheduleHistory.Text = "查看历史排班记录";
            this.btnViewScheduleHistory.UseVisualStyleBackColor = true;
            // 
            // btnScheduleSave
            // 
            this.btnScheduleSave.Location = new System.Drawing.Point(926, 559);
            this.btnScheduleSave.Name = "btnScheduleSave";
            this.btnScheduleSave.Size = new System.Drawing.Size(75, 23);
            this.btnScheduleSave.TabIndex = 11;
            this.btnScheduleSave.Text = "保 存";
            this.btnScheduleSave.UseVisualStyleBackColor = true;
            // 
            // dataGridView_home
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_home.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView_home.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_home.ColumnHeadersVisible = false;
            this.dataGridView_home.ContextMenuStrip = this.contextMenu_rightclick;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_home.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView_home.Location = new System.Drawing.Point(16, 146);
            this.dataGridView_home.Name = "dataGridView_home";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_home.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView_home.Size = new System.Drawing.Size(985, 407);
            this.dataGridView_home.TabIndex = 10;
            // 
            // panel_week
            // 
            this.panel_week.Location = new System.Drawing.Point(146, 74);
            this.panel_week.Name = "panel_week";
            this.panel_week.Size = new System.Drawing.Size(855, 66);
            this.panel_week.TabIndex = 9;
            // 
            // pic_schedule_time
            // 
            this.pic_schedule_time.Image = ((System.Drawing.Image)(resources.GetObject("pic_schedule_time.Image")));
            this.pic_schedule_time.Location = new System.Drawing.Point(16, 74);
            this.pic_schedule_time.Name = "pic_schedule_time";
            this.pic_schedule_time.Size = new System.Drawing.Size(120, 66);
            this.pic_schedule_time.TabIndex = 0;
            this.pic_schedule_time.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "选择排班日期(周为单位):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.schedule);
            this.tabMain.Controls.Add(this.userManager);
            this.tabMain.Controls.Add(this.jobManager);
            this.tabMain.Controls.Add(this.tabReport);
            this.tabMain.Location = new System.Drawing.Point(25, 21);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1110, 644);
            this.tabMain.TabIndex = 0;
            // 
            // lbMsg
            // 
            this.lbMsg.AutoSize = true;
            this.lbMsg.Location = new System.Drawing.Point(855, 674);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(35, 13);
            this.lbMsg.TabIndex = 1;
            this.lbMsg.Text = "label2";
            // 
            // lb_ExcelVersion
            // 
            this.lb_ExcelVersion.AutoSize = true;
            this.lb_ExcelVersion.Location = new System.Drawing.Point(42, 674);
            this.lb_ExcelVersion.Name = "lb_ExcelVersion";
            this.lb_ExcelVersion.Size = new System.Drawing.Size(35, 13);
            this.lb_ExcelVersion.TabIndex = 19;
            this.lb_ExcelVersion.Text = "label4";
            // 
            // lb_version
            // 
            this.lb_version.AutoSize = true;
            this.lb_version.Location = new System.Drawing.Point(1018, 24);
            this.lb_version.Name = "lb_version";
            this.lb_version.Size = new System.Drawing.Size(35, 13);
            this.lb_version.TabIndex = 20;
            this.lb_version.Text = "label4";
            // 
            // contextMenu_rightclick
            // 
            this.contextMenu_rightclick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenuItem_Combine,
            this.StripMenuItem_NightShift});
            this.contextMenu_rightclick.Name = "contextMenu_rightclick";
            this.contextMenu_rightclick.Size = new System.Drawing.Size(153, 70);
            // 
            // StripMenuItem_Combine
            // 
            this.StripMenuItem_Combine.Name = "StripMenuItem_Combine";
            this.StripMenuItem_Combine.Size = new System.Drawing.Size(152, 22);
            this.StripMenuItem_Combine.Text = "合并班次";
            // 
            // StripMenuItem_NightShift
            // 
            this.StripMenuItem_NightShift.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenuItem_Night1,
            this.StripMenuItem_Night2});
            this.StripMenuItem_NightShift.Name = "StripMenuItem_NightShift";
            this.StripMenuItem_NightShift.Size = new System.Drawing.Size(152, 22);
            this.StripMenuItem_NightShift.Text = "设定夜班";
            // 
            // StripMenuItem_Night1
            // 
            this.StripMenuItem_Night1.Name = "StripMenuItem_Night1";
            this.StripMenuItem_Night1.Size = new System.Drawing.Size(152, 22);
            this.StripMenuItem_Night1.Text = "上夜";
            // 
            // StripMenuItem_Night2
            // 
            this.StripMenuItem_Night2.Name = "StripMenuItem_Night2";
            this.StripMenuItem_Night2.Size = new System.Drawing.Size(152, 22);
            this.StripMenuItem_Night2.Text = "下夜";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 696);
            this.Controls.Add(this.lb_version);
            this.Controls.Add(this.lb_ExcelVersion);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.tabMain);
            this.Name = "MainForm";
            this.Text = "安州区人民医院护士排班系统--主页面";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabReport.ResumeLayout(false);
            this.tabReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReporting)).EndInit();
            this.jobManager.ResumeLayout(false);
            this.jobManager.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jobGridView)).EndInit();
            this.userManager.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nurseGrid)).EndInit();
            this.schedule.ResumeLayout(false);
            this.schedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_home)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_schedule_time)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.contextMenu_rightclick.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

     

       
        #endregion

        private System.Windows.Forms.TabPage tabReport;
        private System.Windows.Forms.DataGridView dataGridReporting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePickerReporing;
        private System.Windows.Forms.TabPage jobManager;
        private System.Windows.Forms.Button btnJobSave;
        private System.Windows.Forms.DataGridView jobGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobName;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.TabPage userManager;
        private System.Windows.Forms.Button btnNurserSave;
        private System.Windows.Forms.DataGridView nurseGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn nurseLevelIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn nurseId;
        private System.Windows.Forms.TabPage schedule;
        private System.Windows.Forms.Button btnSechduleRollback;
        private System.Windows.Forms.Button btnWeekPicker;
        private System.Windows.Forms.TextBox txtWeekDay;
        private System.Windows.Forms.MonthCalendar monthCalendarMain;
        private System.Windows.Forms.Button btnViewScheduleHistory;
        private System.Windows.Forms.Button btnScheduleSave;
        private System.Windows.Forms.DataGridView dataGridView_home;
        private System.Windows.Forms.Panel panel_week;
        private System.Windows.Forms.PictureBox pic_schedule_time;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lable_message;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_NursersClear;
        private System.Windows.Forms.Button btn_JobClear;
        private System.Windows.Forms.Button btnNusersRollback;
        private System.Windows.Forms.Button btnJobRollback;
        private System.Windows.Forms.Button btnExportReport;
        private System.Windows.Forms.Label lbJobMsg;
        private System.Windows.Forms.Button btnUploadSchedule;
        private System.Windows.Forms.Label lb_ExcelVersion;
        private System.Windows.Forms.Label lb_version;
        private System.Windows.Forms.ContextMenuStrip contextMenu_rightclick;
        private System.Windows.Forms.ToolStripMenuItem StripMenuItem_Combine;
        private System.Windows.Forms.ToolStripMenuItem StripMenuItem_NightShift;
        private System.Windows.Forms.ToolStripMenuItem StripMenuItem_Night1;
        private System.Windows.Forms.ToolStripMenuItem StripMenuItem_Night2;


    }
}

