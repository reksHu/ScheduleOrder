using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScheduleOrder.Utils;

namespace ScheduleOrder
{
    public partial class MainForm : Form
    {
        private static string APPPATH = System.Windows.Forms.Application.StartupPath;
        private bool _monthPickerSelected = false; //用于监控是否点击过month picker日期选择按钮
        public MainForm()
        {
            InitializeComponent();
            //path.Text = System.Windows.Forms.Application.StartupPath;
            pic_schedule_time.Visible = false;
            dataGridView_home.Visible = false;
            txtWeekDay.Enabled = true;
            txtWeekDay.ReadOnly = true;

            btnScheduleSave.Visible = false;


            btnScheduleSave.Click += new EventHandler(btnScheduleSave_Click);
            btnSechduleRollback.Click += new EventHandler(btnSechduleRollback_Click);
            btnSechduleRollback.Visible = false;

            dataGridView_home.CellClick += new DataGridViewCellEventHandler(dataGridView_home_CellClick);
            dataGridView_home.AllowUserToAddRows = false;
            btnViewScheduleHistory.Click += new EventHandler(btnViewScheduleHistory_Click);
            //dataGridView_home.ContextMenu = contextMenu_rightclick;

            /// 处理鼠标右键事件
            //dataGridView_home.CellMouseClick += new DataGridViewCellMouseEventHandler(dataGridView_home_CellMouseClick);
            StripMenuItem_Combine.Click += new EventHandler(StripMenuItem_Combine_Click);
            StripMenuItem_Night1.Click += new EventHandler(StripMenuItem_Night1_Click);
            ///结束右键处理事件

            dataGridView_home.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridView_home_RowPostPaint);
            jobGridView.RowPostPaint += new DataGridViewRowPostPaintEventHandler(jobGridView_RowPostPaint);
            nurseGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(nurseGrid_RowPostPaint);

            //排班页面中的日期选择控件
            monthCalendarMain.Visible = false;
            monthCalendarMain.FirstDayOfWeek = Day.Monday;
            monthCalendarMain.ShowWeekNumbers = true;
            monthCalendarMain.MouseLeave += new EventHandler(monthCalendarMain_MouseLeave);
            monthCalendarMain.DateSelected += new DateRangeEventHandler(monthCalendarMain_DateSelected);
            btnWeekPicker.Click += new EventHandler(btnWeekPicker_Click);

            //护士人员管理节点
            btnNurserSave.Click += new EventHandler(btnNurseSave_Click);
            btnNusersRollback.Click += new EventHandler(btnNusersRollback_Click);
            // data file clean up, 暂时不实现 
            btn_JobClear.Click += new EventHandler(btn_JobClear_Click);
            btn_JobClear.Visible = false;

            //岗位管理节点
            btnJobSave.Click += new EventHandler(btn_jobSave_Click);
            btnJobRollback.Click += new EventHandler(btnJobRollback_Click);

            //统计报表节点
            datePickerReporing.CustomFormat = "yyyy年MM";
            datePickerReporing.Format = DateTimePickerFormat.Custom;
            datePickerReporing.ValueChanged += new EventHandler(datePickerReporing_ValueChanged);
            btnExportReport.Click += new EventHandler(btnExportReport_Click);
            dataGridReporting.AllowUserToAddRows = false;
            //dataGridReporting.Enabled = false;
            dataGridReporting.Visible = false;

            btnPrint.Click += new EventHandler(btnPrint_Click);
            btnPrint.Visible = false;


            btnUploadSchedule.Click += new EventHandler(btnUploadSchedule_Click);
            btnUploadSchedule.Visible = false;


            

            ////////Common configuration//////////////////
            //lbMsg.Text = "设计制作人：胡鸿春，联系方式:153 8810 9543";
            lbMsg.Text = "联系人：胡鸿春(153 8810 9543), 吕波(152 8111 1616)";

            lable_message.Visible = false;


            btn_NursersClear.Click += new EventHandler(btn_NursersClear_Click);

            btn_NursersClear.Visible = false;

            lbJobMsg.Text = "注意:岗位名称和岗位系数不能为空，否则数据保存不成功。";
            lbJobMsg.ForeColor = Color.Green;

            lb_ExcelVersion.Text = ExcelHelper.GetExcelVersion();

            lb_version.Text = "当前系统版本 0.91";

        }

        /// <summary>
        /// 上夜点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void StripMenuItem_Night1_Click(object sender, EventArgs e)
        {

        }


        void StripMenuItem_Combine_Click(object sender, EventArgs e)
        {
            if (dataGridView_home.CurrentCell != null 
                && dataGridView_home.CurrentCell.Value != null 
                && !string.IsNullOrEmpty(dataGridView_home.CurrentCell.Value.ToString()))
            {
                //DataGridViewColumn column = dataGridView_home.CurrentCell.OwningColumn;
                int columnIndex = dataGridView_home.CurrentCell.ColumnIndex;
                int rowIndex = dataGridView_home.CurrentCell.RowIndex;
                //表示选中了下午单元格,设置上午单元格值
                if (columnIndex % 2 == 0)
                { 
                    dataGridView_home.Rows[rowIndex].Cells[columnIndex - 1].Value = dataGridView_home.CurrentCell.Value.ToString();
                    dataGridView_home.Rows[rowIndex].Cells[columnIndex - 1].Tag = dataGridView_home.CurrentCell.Tag;
                }
                else {
                    dataGridView_home.Rows[rowIndex].Cells[columnIndex + 1].Value = dataGridView_home.CurrentCell.Value.ToString();
                    dataGridView_home.Rows[rowIndex].Cells[columnIndex + 1].Tag = dataGridView_home.CurrentCell.Tag;               
                }

                //dataGridView_home.CurrentCell.Value = jobBox.Text;
                //dataGridView_home.CurrentCell.Tag = jobBox.SelectedValue;

            }
            else {
                MessageBox.Show("请先选择班次，再进行班次合并.");
            }
        }

        void btnExportReport_Click(object sender, EventArgs e)
        {
            try
            {
                lable_message.Text = "正在导出，请稍等...";
                lable_message.Visible = true;
                DateTime datetime = datePickerReporing.Value;
                //string filePath = Miscellaneous.GetExcelsFileFullPath(string.Format("绩效统计-{0}.xlsx", datetime.ToString("yyyy-MM")));
                string filePath = Miscellaneous.GetExcelsFileFullPath(string.Format("绩效统计-{0}.xls", datetime.ToString("yyyy-MM")));
                DataTable dt = DatagridviewHelper.ConvertDataGridViewToTable(dataGridReporting);
                ExcelHelper.WriteExcel(filePath, this.dataGridReporting);
                MessageBox.Show("导出成功", "提示消息");
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出失败:" + ex.Message, "操作失败");
            }
            finally {
                lable_message.Text = string.Empty;
                lable_message.Visible = false;
            }
        }




        private void MainForm_Load(object sender, EventArgs e)
        {
            //护士管理
            nurseGrid.DataSource = NursesDataBindingSource();

            //岗位管理
            jobGridView.DataSource = DataBindingJobsSource();

            dataGridView_home.AutoGenerateColumns = true;
            dataGridView_home.EditMode = DataGridViewEditMode.EditOnEnter;
            //自动保存

            //InitHomeGridComponet();

            BindHomeJobDrop();
        }

        void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                lable_message.Visible = true;
                lable_message.Text = "正在保存，请稍等....";
                DateTime dtMonthCal = monthCalendarMain.SelectionStart;
                DateTime startWeek = dtMonthCal.AddDays(1 - Convert.ToInt16(dtMonthCal.DayOfWeek.ToString("d")));
                List<string> weekdays = Miscellaneous.GenerateWeekDaysList(startWeek);
                //PrintHelper print = new PrintHelper();
                //DataSet ds = new DataSet();
                DataTable dt = DatagridviewHelper.ConvertDataGridViewToTable(dataGridView_home);

                //is updated?
                //DateTime dt_month = monthCalendarMain.SelectionStart;
                //DateTime startWeek = dt_month.AddDays(1 - Convert.ToInt16(dt_month.DayOfWeek.ToString("d")));
                string fileXmlFullPath = Miscellaneous.GetSchedulerXMLFullPath(startWeek.ToString("yyyyMMdd"));
                DataTable sourceTable = LoadHomeSchedules(fileXmlFullPath);
                //比较两个datatable, 如果不相同则先保存再打印
                bool isSame =  DatagridviewHelper.CompareDataTable(dt, sourceTable,"姓名");
                if (!isSame) {
                    ScheduleSaveAction();
                }

                //ds.Tables.Add(dt);
                string tempExcelPath = Miscellaneous.GetScheduleTempExcelFile();
                if (String.IsNullOrEmpty(tempExcelPath))
                {
                    MessageBox.Show("排班模板Excel文件不存在,请指定正确路径再保存为Excel", "文件检查失败");
                }
                else
                {
                    ExcelHelper.DataTableToExcelForSchedule(Miscellaneous.GetScheduleTempExcelFile(), dt, weekdays);
                    //NPOIHelper.DataTableToExcelForSchedule_NPOI(tempExcelPath, dt, weekdays);
                    MessageBox.Show("保存Excel文件成功", "文件保存成功");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存文件出错:" + ex.Message, "文件检查失败");
            }
            finally
            {
                lable_message.Text = string.Empty;
                lable_message.Visible = false;
            }
        }


        void btnUploadSchedule_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DateTime dtMonthCal = monthCalendarMain.SelectionStart;
            DateTime startWeek = dtMonthCal.AddDays(1 - Convert.ToInt16(dtMonthCal.DayOfWeek.ToString("d")));
            List<string> weekdays = Miscellaneous.GenerateWeekDaysList(startWeek);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName.ToString();
                List<string> nursersName = XMLHelper.GetNursersName(Miscellaneous.GetNurseXMLFullPath());
                List<string> jobsName = XMLHelper.GetJobsName(Miscellaneous.GetJobXMLFullPath());
                //只读取/处理表文件中的姓名和排班信息，如果姓名或者排班信息在系统中找不到，则抛出错误
                ExcelHelper.UploadAndSaveExcel(fileName,nursersName,jobsName);
            }
        }

        

        private void CreateReportHeader()
        {
            DataTable dtHeader = new DataTable();
            DataRow headerRow = dtHeader.NewRow();
            DateTime dt = monthCalendarMain.SelectionStart;
            DateTime startWeek = dt.AddDays(1 - Convert.ToInt16(dt.DayOfWeek.ToString("d")));
            string dayOfWeek = startWeek.DayOfWeek.ToString();
            for (int i = 0; i < 7; i++)
            {
                DateTime offSet = startWeek.AddDays(i);
                //l.Text = offSet.ToString("yyyy-MM-dd");
            }


        }


        void datePickerReporing_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = datePickerReporing.Value;
            InitReportingForm(dt.ToString("MM"));

        }

        private void InitReportingForm(string month)
        {
            try
            {
                //List<string> files = XMLHelper.GetSchedulerReportingFiles(month, folderName);

                Dictionary<string, JobsCount> reportingDict = DataInit.GetSchedulesDataForReporint(month);
                DataTable reportingTable = InitReporingForJobs();
                foreach (var item in reportingDict)
                {
                    DataRow row = reportingTable.NewRow();
                    row["姓名"] = item.Key.ToString();
                    Dictionary<string, double> counts = item.Value.GetJobDict();
                    foreach (var job in counts)
                    {
                        row[job.Key] = job.Value;
                    }
                    reportingTable.Rows.Add(row);
                }
                dataGridReporting.DataSource = reportingTable;
                dataGridReporting.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("报表数据初始化出错了：" + ex.Message,"错误提示");
                dataGridReporting.Visible = false;
            }

        }

        private DataTable InitReporingForJobs()
        {
            List<string> jobsName = XMLHelper.GetJobsName(Miscellaneous.GetJobXMLFullPath());
            DataTable dt = new DataTable();
            dt.Columns.Add("姓名");
            foreach (var item in jobsName)
            {
                dt.Columns.Add(item);
            }
            return dt;

        }

        void btnSechduleRollback_Click(object sender, EventArgs e)
        {
            InitScheduleGridComponet("");
            Control[] boxs = dataGridView_home.Controls.Find("jobBox", true);
            if (boxs != null && boxs.Count() > 0)
            {
                boxs[0].Visible = false;
            }
        }

       

        void monthCalendarMain_MouseLeave(object sender, EventArgs e)
        {
            monthCalendarMain.Visible = false;
        }
        void monthCalendarMain_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime date = monthCalendarMain.SelectionStart;

            monthCalendarMain.Visible = false;
            _monthPickerSelected = true;

            txtWeekDay.Text = date.ToString("yyyy年MM月dd日");
            schedule_dateTimePicker_ValueChanged(sender, e);
        }


        void btnWeekPicker_Click(object sender, EventArgs e)
        {
            monthCalendarMain.Visible = true;
            Control[] boxs = dataGridView_home.Controls.Find("jobBox", true);
            if (boxs != null && boxs.Count() > 0)
            {
                boxs[0].Visible = false;
            }
        }

        public void UpdateScheduleGridComponet(string fileXmlFullPath) {
            if (_monthPickerSelected)
            {
                InitScheduleGridComponet(fileXmlFullPath);
            }
            else {
                MessageBox.Show("模板生成无效:请先选择一个排班记录!","无效操作");
            }
        }

        public void InitScheduleGridComponet(string fileXmlFullPath)
        {
            if (string.IsNullOrEmpty(fileXmlFullPath)) {
                DateTime dt = monthCalendarMain.SelectionStart;
                DateTime startWeek = dt.AddDays(1 - Convert.ToInt16(dt.DayOfWeek.ToString("d")));
                fileXmlFullPath = Miscellaneous.GetSchedulerXMLFullPath(startWeek.ToString("yyyyMMdd"));
            }
            //fileXmlFullPath = "E:\\projects\\ScheduleOrder\\ScheduleOrder\\bin\\Debug\\data\\Schedules-20190128.xml";

            dataGridView_home.DataSource = LoadHomeSchedules(fileXmlFullPath);

            //DataTable dtGrid = GetHomeGridData();
            //dataGridView_home.DataSource = dtGrid;
            dataGridView_home.Columns[0].Frozen = true;
            dataGridView_home.Columns[0].ReadOnly = true;
            for (int i = 1; i < 15; i++)
            {
                dataGridView_home.Columns[i].Width = 60;
            }
        }


        void btnScheduleSave_Click(object sender, EventArgs e)
        {
            try
            {
                ScheduleSaveAction();
                MessageBox.Show("保存成功", "排班信息保存提示");
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误:" + ex.Message, "排班信息保存提示");
            }
            

        }

        /// <summary>
        /// 保存排班安排
        /// </summary>
        private void ScheduleSaveAction()
        {
            DateTime dt = monthCalendarMain.SelectionStart;
            DateTime startWeek = dt.AddDays(1 - Convert.ToInt16(dt.DayOfWeek.ToString("d")));

            string fileXmlFullPath = Miscellaneous.GetSchedulerXMLFullPath(startWeek.ToString("yyyyMMdd"));
            bool isExisted = DataInit.IsFileExited(fileXmlFullPath);
            if (!isExisted)
            {
                CreateSchedule(fileXmlFullPath, startWeek);
            }
            else
            {
                UpdateSchedule(fileXmlFullPath, startWeek);
            }
           
        }

        private void CreateSchedule(string fileXmlFullPath, DateTime startWeek)
        {
            //string weekFirstDay = startWeek.DayOfWeek.ToString();
            //string fileXmlFullPath = GetSchedulerXMLFullPath(startWeek.ToString("yyyyMMdd"));
            int rowCount = dataGridView_home.Rows.Count;

            List<Schedules> schedulesList = GenerateScheduleList(startWeek);

            DataInit.AddSchedulerNodes(fileXmlFullPath, schedulesList);

        }

        private void UpdateSchedule(string fileXmlFullPath, DateTime startWeek)
        {
            List<Schedules> schedulesList = GenerateScheduleList(startWeek);

            DataInit.UpdateSchedulerNodes(fileXmlFullPath, schedulesList);
            //MessageBox.Show("保存成功", "排班信息保存提示");

        }

        private List<Schedules> GenerateScheduleList(DateTime startWeek)
        {
            List<Schedules> schedulesList = new List<Schedules>();
            int rowCount = dataGridView_home.Rows.Count;
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                Schedules schedule = new Schedules();

                if (dataGridView_home.Rows[rowIndex].Cells[0].Value == null)
                {
                    break;
                }
                string nurserName = dataGridView_home.Rows[rowIndex].Cells[0].Value.ToString();

                schedule.ScheduledNurser = XMLHelper.GetNurserFromName(Miscellaneous.GetNurseXMLFullPath(), nurserName);
                schedule.WeekFirstDay = startWeek.ToString("yyyy-MM-dd");
                schedule.JobsList = new List<ScheduleJob>();

                for (int i = 1; i < 8; i++)
                {

                    string jobName_Morning = dataGridView_home.Rows[rowIndex].Cells["M" + i].Value.ToString();
                    string jobName_Afternoon = dataGridView_home.Rows[rowIndex].Cells["A" + i].Value.ToString();

                    string jobRating_Morning = dataGridView_home.Rows[rowIndex].Cells["M" + i].Tag == null ? "" : dataGridView_home.Rows[rowIndex].Cells["M" + i].Tag.ToString();
                    string jobRating_Afternoon = dataGridView_home.Rows[rowIndex].Cells["A" + i].Tag == null ? "" : dataGridView_home.Rows[rowIndex].Cells["A" + i].Tag.ToString();

                    ScheduleJob job = new ScheduleJob();
                    job.ScheduledWeekday = i.ToString();

                    job.Tasks = new List<TaskDetail>();
                    job.Tasks.Add(new TaskDetail()
                    {
                        JobDayType = ScheduledType.Morning.ToString(),
                        JobName = jobName_Morning,
                        JobRating = jobRating_Morning
                    }
                    );
                    job.Tasks.Add(new TaskDetail()
                    {
                        JobDayType = ScheduledType.Afternoon.ToString(),
                        JobName = jobName_Afternoon,
                        JobRating = jobRating_Afternoon
                    });
                    schedule.JobsList.Add(job);

                }
                schedulesList.Add(schedule);
            }
            return schedulesList;
        }



        void dataGridView_home_CellClick(object sender, EventArgs e)
        {
            if (dataGridView_home.CurrentCell != null)
            {
                DataGridViewColumn column = dataGridView_home.CurrentCell.OwningColumn;
                string colName = column.Name;
                int columnIndex = dataGridView_home.CurrentCell.ColumnIndex;
                int rowIndex = dataGridView_home.CurrentCell.RowIndex;
                Rectangle rect = dataGridView_home.GetCellDisplayRectangle(columnIndex, rowIndex, false);
                Control[] boxs = dataGridView_home.Controls.Find("jobBox", true);
                if (boxs.Count() > 0)
                {
                    ComboBox jobBox = (ComboBox)boxs[0];
                    jobBox.Left = rect.Left;
                    jobBox.Top = rect.Top;
                    jobBox.Width = rect.Width;
                    jobBox.Height = rect.Height;

                    if (string.IsNullOrEmpty(dataGridView_home.CurrentCell.Value.ToString()))
                    {
                        jobBox.SelectedIndex = 0;
                    }
                    else {
                        //jobBox.SelectedValue = dataGridView_home.CurrentCell.Tag.ToString();
                        jobBox.Text = dataGridView_home.CurrentCell.Value.ToString(); 
                    }

                    if (colName.StartsWith("M") || colName.StartsWith("A"))
                    {
                        jobBox.Visible = true;

                    }
                    else
                    {
                        jobBox.Visible = false;
                    }

                }

            }

        }

        //在每行的左边为每行添加一个从1开始递增的序号
        void dataGridView_home_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            GridPrimaryKeyDisplay(e, dataGridView_home);
        }

        //在每行的左边为每行添加一个从1开始递增的序号
        private void jobGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            GridPrimaryKeyDisplay(e, jobGridView);
        }
        void nurseGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            GridPrimaryKeyDisplay(e, nurseGrid);
        }

        private void GridPrimaryKeyDisplay(DataGridViewRowPostPaintEventArgs e, DataGridView gridview)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                gridview.RowHeadersWidth - 4,
                e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                gridview.RowHeadersDefaultCellStyle.Font,
                rectangle,
                gridview.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }




        private BindingSource DataBindingJobsSource()
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            string xmlfileFullPath = Miscellaneous.GetJobXMLFullPath();
            //string rootElement = "Jobs";
            ds.ReadXml(xmlfileFullPath);

            return new BindingSource(ds.Tables[0], null);

        }


        private BindingSource NursesDataBindingSource()
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            string fileLocation = System.IO.Path.Combine(APPPATH, "data");
            string xmlFileName = "Nursers.xml";
            string xmlfileFullPath = System.IO.Path.Combine(fileLocation, xmlFileName);
            ds.ReadXml(xmlfileFullPath);

            return new BindingSource(ds.Tables[0], null);
        }

        /// <summary>
        /// 生成空白内容的排班信息
        /// </summary>
        /// <returns></returns>
        private DataTable GenerateDefaultScheduleData()
        {

            DataTable home_table = new DataTable();
            string fileLocation = System.IO.Path.Combine(APPPATH, "data");
            string xmlFileName = "Nursers.xml";
            string xmlfileFullPath = System.IO.Path.Combine(fileLocation, xmlFileName);
            home_table.Columns.Add("姓名");
            for (int i = 1; i < 8; i++)
            {
                home_table.Columns.Add("M" + i);
                home_table.Columns.Add("A" + i);

            }
            List<String> nursers = XMLHelper.GetNursersName(xmlfileFullPath);
            foreach (String item in nursers)
            {
                DataRow nameRow = home_table.NewRow();
                nameRow[0] = item;

                for (int i = 1; i < 15; i++) //generate each day morning and afternoon
                {
                    nameRow[i] = string.Empty;
                }

                home_table.Rows.Add(nameRow);
            }

            return home_table;

        }

        /// <summary>
        /// 上传文件时，转换成datatable
        /// </summary>
        /// <param name="schedulesList"></param>
        /// <returns></returns>
        private DataTable LoadUploadSchedules(List<Schedules> schedulesList) { 
                //保证文件中没有排班信息，排班页面也能正常显示
            if (schedulesList != null && schedulesList.Count() > 0)
            {

                DataTable home_table = new DataTable();
                List<String> nursers = new List<string>();
                home_table.Columns.Add("姓名");
                for (int i = 1; i < 8; i++)
                {
                    home_table.Columns.Add("M" + i);
                    home_table.Columns.Add("A" + i);

                }
                foreach (var item in schedulesList)
                {
                    DataRow nameRow = home_table.NewRow();
                    nameRow[0] = item.ScheduledNurser.NurserName;
                    List<ScheduleJob> scheduledJobs = item.JobsList;
                    int index = 1;
                    foreach (var job in scheduledJobs)
                    {
                        List<TaskDetail> tasks = job.Tasks;
                        foreach (var task in tasks)
                        {
                            nameRow[index] = task.JobName;
                            index++;
                        }
                    }
                    home_table.Rows.Add(nameRow);
                }
                return home_table;
            }
            return null;
        }

        /// <summary>
        /// 点击排班日期后，加载组织排班信息
        /// </summary>
        /// <param name="fileXmlFullPath"></param>
        /// <returns></returns>
        private DataTable LoadHomeSchedules(string fileXmlFullPath)
        {
            bool isExisted = DataInit.IsFileExited(fileXmlFullPath);

            if (isExisted)
            {
                List<Schedules> schedulesList = XMLHelper.GetSchedules(fileXmlFullPath);
                //保证文件中没有排班信息，排班页面也能正常显示
                if (schedulesList != null && schedulesList.Count() > 0)
                {

                    DataTable home_table = new DataTable();
                    List<String> nursers = new List<string>();
                    home_table.Columns.Add("姓名");
                    for (int i = 1; i < 8; i++)
                    {
                        home_table.Columns.Add("M" + i);
                        home_table.Columns.Add("A" + i);

                    }
                    foreach (var item in schedulesList)
                    {
                        DataRow nameRow = home_table.NewRow();
                        nameRow[0] = item.ScheduledNurser.NurserName;
                        List<ScheduleJob> scheduledJobs = item.JobsList;
                        int index = 1;
                        foreach (var job in scheduledJobs)
                        {
                            List<TaskDetail> tasks = job.Tasks;
                            foreach (var task in tasks)
                            {
                                nameRow[index] = task.JobName;
                                index++;
                            }
                        }
                        home_table.Rows.Add(nameRow);
                    }
                    return home_table;
                }
                else
                {
                    return GenerateDefaultScheduleData();
                }
            }
            return GenerateDefaultScheduleData();

        }

        /// <summary>
        /// 生成排班信息中的排班下拉项
        /// </summary>
        private void BindHomeJobDrop()
        {
            List<Job> jobs = XMLHelper.GetJobs(Miscellaneous.GetJobXMLFullPath());
            //List<String> nursers = XMLHelper.GetNursersName(GetNurseXMLFullPath());
            DataTable dtJobs = new DataTable();
            dtJobs.Columns.Add("Id");
            dtJobs.Columns.Add("Name");
            ComboBox cmb_temp = new ComboBox();
            foreach (Job item in jobs)
            {
                DataRow nameRow = dtJobs.NewRow();

                //ComboBoxItem boxItem = new ComboBoxItem(item.JobIndex, item.JobName);
                nameRow["Id"] = item.JobIndex;
                nameRow["Name"] = item.JobName;
                dtJobs.Rows.Add(nameRow);
            }
            cmb_temp.ValueMember = "Id";
            cmb_temp.Name = "jobBox";
            cmb_temp.DisplayMember = "Name";
            cmb_temp.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_temp.Visible = false;
            cmb_temp.DataSource = dtJobs;
            
            dataGridView_home.Controls.Add(cmb_temp);

            cmb_temp.SelectedIndexChanged += new EventHandler(cmb_Job_SelectedIndexChanged);

        }

        private void UpdateScheduleJobDrop()
        {
            //if (!_monthPickerSelected)
            //{ //用户还没有选择排版日期，即排班计划还没有生成
            //    BindHomeJobDrop();
            //}
            Control[] jobBox = dataGridView_home.Controls.Find("jobBox", false);

            List<Job> jobs = XMLHelper.GetJobs(Miscellaneous.GetJobXMLFullPath());
            DataTable dtJobs = new DataTable();
            dtJobs.Columns.Add("Id");
            dtJobs.Columns.Add("Name");

            foreach (Job item in jobs)
            {
                DataRow nameRow = dtJobs.NewRow();

                //ComboBoxItem boxItem = new ComboBoxItem(item.JobIndex, item.JobName);
                nameRow["Id"] = item.JobIndex;
                nameRow["Name"] = item.JobName;
                dtJobs.Rows.Add(nameRow);
            }
            ComboBox cmb_temp = jobBox[0] as ComboBox;
            cmb_temp.ValueMember = "Id";
            cmb_temp.DisplayMember = "Name";
            cmb_temp.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_temp.DataSource = dtJobs;
        }

        void cmb_Job_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox jobBox = (ComboBox)sender;
            //jobBox.SelectedValue  // jobindex
            if (dataGridView_home.CurrentCell != null)
            {
                dataGridView_home.CurrentCell.Value = jobBox.Text;
                dataGridView_home.CurrentCell.Tag = jobBox.SelectedValue;
            }

        }


        private void schedule_dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            
            ScheduleTimePickerChangeAction();

        }

        private void ScheduleTimePickerChangeAction()
        {
            DateTime dt = monthCalendarMain.SelectionStart;
            int a = Convert.ToInt16(dt.DayOfWeek);
            DateTime startWeek = dt.AddDays(1 - Convert.ToInt16(dt.DayOfWeek.ToString("d")));
            //string dayOfWeek = startWeek.DayOfWeek.ToString();

            panel_week.Controls.Clear();

            int P_int_x = 10;
            int l2_int_x = 10;
            int l_morning_x = 10;
            int l_afternoon_x = 70;

            for (int i = 0; i < 7; i++)
            {
                DateTime offSet = startWeek.AddDays(i);

                Label l = new Label();
                l.Width = 120;
                l.Height = 25;
                l.Location = new Point(P_int_x, 0);
                P_int_x += 120;
                l.BorderStyle = BorderStyle.FixedSingle;
                l.TextAlign = ContentAlignment.MiddleCenter;
                l.Text = offSet.ToString("yyyy-MM-dd");

                Label l2 = new Label();
                l2.Text = offSet.DayOfWeek.ToString();
                l2.Width = 120;
                l2.Height = 25;
                l2.Location = new Point(l2_int_x, 20);
                l2_int_x += 120;

                l2.TextAlign = ContentAlignment.MiddleCenter;
                l2.BorderStyle = BorderStyle.FixedSingle;

                Label l_morning = new Label();
                l_morning.Text = "上午";
                l_morning.Width = 60;
                l_morning.Height = 25;
                l_morning.BorderStyle = BorderStyle.FixedSingle;
                l_morning.TextAlign = ContentAlignment.MiddleCenter;
                l_morning.Location = new Point(l_morning_x, 40);
                l_morning_x += 120;

                Label l_afternoon = new Label();
                l_afternoon.Text = "下午";
                l_afternoon.Width = 60;
                l_afternoon.Height = 25;
                l_afternoon.BorderStyle = BorderStyle.FixedSingle;
                l_afternoon.TextAlign = ContentAlignment.MiddleCenter;

                l_afternoon.Location = new Point(l_afternoon_x, 40);
                l_afternoon_x += 120;


                panel_week.Controls.Add(l);
                panel_week.Controls.Add(l2);
                panel_week.Controls.Add(l_morning);
                panel_week.Controls.Add(l_afternoon);

            }
            pic_schedule_time.Visible = true;
            dataGridView_home.Visible = true;
            InitScheduleGridComponet("");
            btnScheduleSave.Visible = true;
            btnSechduleRollback.Visible = true;
            btnPrint.Visible = true;
            //btnUploadSchedule.Visible = true;
        }


        void btn_jobSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool schedulesFilesExisted = XMLHelper.hasSchedulesFilesExisted("data");
                //MessageBox.Show("schedulesFilesExisted:" + schedulesFilesExisted);
                if (schedulesFilesExisted)
                {
                    MessageBoxButtons messBtn = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show("此操作可能会影响生成报表，确定要修改岗位信息吗？", "保存修改", messBtn);
                    if (dr == DialogResult.OK)
                    {
                        SaveJobAction();
                    }
                    else
                    { //load jobs file data again.
                        jobGridView.DataSource = DataBindingJobsSource();
                    }

                }
                else
                {
                    //MessageBox.Show("SaveJobAction:" + schedulesFilesExisted);
                    SaveJobAction();
                }
                UpdateScheduleJobDrop();
                MessageBox.Show("保存成功。");
                
            }
            catch (Exception ex) {
                MessageBox.Show("保存失败:"+ex.Message,"操作失败提示");
            }

        }

        private void SaveJobAction()
        {
            DataTable souceJobData = null;
            DataTable gridJobData = null;
            List<Job> jobs = null;
            try
            {
                int rowCount = jobGridView.RowCount;
                string jobxmlfileFullPath = Miscellaneous.GetJobXMLFullPath();
                //MessageBox.Show(jobxmlfileFullPath);
                souceJobData = XMLHelper.GetJobsDataTable();
                gridJobData = DatagridviewHelper.ConvertDataGridViewToTable(jobGridView);

                bool isSame = DatagridviewHelper.CompareDataTable(souceJobData, gridJobData,"JobName");

                if (!isSame)
                {
                    jobs = DataInit.CovertJobTableToLists(gridJobData);
                    XMLHelper.UpdateJobNodes(jobxmlfileFullPath, jobs);

                    //for (int index = 0; index < rowCount - 1; index++)
                    //{
                    //    string jobTitle = jobGridView.Rows[index].Cells[0].Value.ToString();
                    //    string jobRating = jobGridView.Rows[index].Cells[1].Value.ToString();
                    //    string id = jobGridView.Rows[index].Cells[2].Value.ToString();
                    //    if (!string.IsNullOrEmpty(jobTitle) && !string.IsNullOrEmpty(jobRating))
                    //    {
                    //        Job job = new Job();
                    //        job.JobName = jobTitle;
                    //        job.JobIndex = jobRating;
                    //        //it's a new row if empty
                    //        if (string.IsNullOrEmpty(id))
                    //        {
                    //            DataInit.AddJobNode(jobxmlfileFullPath, job);
                    //        }
                    //        else
                    //        {
                    //            job.Id = id;
                    //            DataInit.UpdateJobNode(jobxmlfileFullPath, "Jobs", job);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("岗位名称或者岗位系数不能为空", "保存失败");
                    //    }

                    //}

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据保存错误:" + ex.Message, "系统错误提示");
            }
            finally {
                souceJobData = null;
                gridJobData = null;
                jobs = null;
            }
        }

        private void btnNurseSave_Click(object sender, EventArgs e)
        {

            bool schedulesFilesExisted = XMLHelper.hasSchedulesFilesExisted("data");
            if (schedulesFilesExisted)
            {
                MessageBoxButtons messBtn = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("此操作可能会影响生成报表，确定要修改人员信息吗？", "保存修改", messBtn);
                if (dr == DialogResult.OK)
                {
                    SaveNurseAction();
                }
                else
                {
                    nurseGrid.DataSource = NursesDataBindingSource();
                }
            }
            else
            {
                SaveNurseAction();
            }


        }

        private void SaveNurseAction()
        {
            string xmlfileFullPath = Miscellaneous.GetNurseXMLFullPath();
            int rowCount = nurseGrid.RowCount;
            List<Nurser> updatedNurseList = new List<Nurser>();
            for (int index = 0; index < rowCount - 1; index++)
            {
                string nurseName = nurseGrid.Rows[index].Cells[0].Value.ToString();
                string nurseLevel = nurseGrid.Rows[index].Cells[1].Value.ToString();
                string nurseRating = nurseGrid.Rows[index].Cells[2].Value.ToString();
                string id = nurseGrid.Rows[index].Cells[3].Value.ToString();

                updatedNurseList.Add(new Nurser() { 
                     Id = id, NurserLevel= nurseLevel,NurserName=nurseName,NurserLevelRating =nurseRating
                });

                
                //if (!string.IsNullOrEmpty(nurseName))
                //{
                //    Nurser nurser = new Nurser();
                //    nurser.NurserName = nurseName;
                //    nurser.NurserLevel = nurseLevel;
                //    nurser.NurserLevelRating = nurseRating;
                //    //it's a new row if empty
                //    if (string.IsNullOrEmpty(id))
                //    {
                //        DataInit.AddNurseNode(xmlfileFullPath, nurser);
                //    }
                //    else
                //    {
                //        nurser.Id = id;
                //        DataInit.UpdateNurserNode(xmlfileFullPath, nurser);
                //    }
                //}

            }
            DataInit.UpdateNurses(updatedNurseList);
            InitScheduleGridComponet("");
            MessageBox.Show("保存成功。");

        }

        void btnJobRollback_Click(object sender, EventArgs e)
        {
            //岗位管理
            jobGridView.DataSource = DataBindingJobsSource();
        }

        void btnNusersRollback_Click(object sender, EventArgs e)
        {
            nurseGrid.DataSource = NursesDataBindingSource();
        }

        void btn_NursersClear_Click(object sender, EventArgs e)
        {
            DialogResult messageBox = MessageBox.Show("是否清空所有护士人员数据，注意：清空后需要重新录入，并且影响报表生成", "请确认，谨慎操作!", MessageBoxButtons.YesNo);
            if (messageBox == DialogResult.Yes)
            {

            }
        }

        void btn_JobClear_Click(object sender, EventArgs e)
        {
            DialogResult messageBox = MessageBox.Show("是否清空所有岗位管理数据，注意：清空后需要重新录入，并且影响报表生成", "请确认，谨慎操作!", MessageBoxButtons.YesNo);
            if (messageBox == DialogResult.Yes)
            {

            }


        }


        void btnViewScheduleHistory_Click(object sender, EventArgs e)
        {
            SchedulesHistory history = new SchedulesHistory();
            history.Text = "排班历史记录";
            history.StartPosition = FormStartPosition.CenterScreen;
            history.Show();
            
        }

    }
}
