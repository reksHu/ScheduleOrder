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
    public partial class SchedulesHistory : Form
    {
        public static string historySchedulePath = "";
        private static string APPPATH = System.Windows.Forms.Application.StartupPath;
        public SchedulesHistory()
        {
            InitializeComponent();
            InitFormCompoents();
        }

        private void InitFormCompoents(){
            pictureBox1.Visible = false;
            panelWeekDay.Visible = false;
            dataGridHistory.Visible = false;
            dataGridHistory.AllowUserToAddRows = false;
            //datePickerWeekSelect.ValueChanged += new EventHandler(datePickerWeekSelect_ValueChanged);

            txtWeekDay.ReadOnly = true;
            btnWeekPicker.Click += new EventHandler(btnWeekPicker_Click);

            monthCalendar.Visible = false;
            monthCalendar.MouseLeave += new EventHandler(monthCalendar_MouseLeave);
            monthCalendar.DateSelected += new DateRangeEventHandler(monthCalendar_DateSelected);
            monthCalendar.FirstDayOfWeek = Day.Monday;
            monthCalendar.ShowWeekNumbers = true;

            
            //monthCalendar1.FirstDayOfWeek = Day.Monday;
            btnSetScheduleTemp.Click += new EventHandler(btnSetScheduleTemp_Click);
        }

        /// <summary>
        /// 将此历史记录选择为模板放与主页面的排班表中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnSetScheduleTemp_Click(object sender, EventArgs e)
        {
            DateTime dt = monthCalendar.SelectionStart;
            DateTime startWeek = dt.AddDays(1 - Convert.ToInt16(dt.DayOfWeek.ToString("d")));
            historySchedulePath = Miscellaneous.GetSchedulerXMLFullPath(startWeek.ToString("yyyyMMdd"));
            MainForm main = (MainForm) Application.OpenForms["MainForm"];
            main.InitScheduleGridComponet(historySchedulePath);
            this.Close();

        }


        void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime dt = monthCalendar.SelectionStart;
            string dateStr = dt.ToString("yyyy年MM月dd日");
            txtWeekDay.Text = dateStr;
            monthCalendar.Visible = false;
            datePickerWeekSelect_ValueChanged(sender, e);

        }
       
        void monthCalendar_MouseLeave(object sender, EventArgs e)
        {
            monthCalendar.Visible = false;
        }

        void btnWeekPicker_Click(object sender, EventArgs e)
        {
            monthCalendar.Visible = true;
            //DateTime start = monthCalendar.SelectionStart;
            //string str = start.ToString("yyyy年MM月dd日");
            //txtWeekDay.Text = str;
        }

       

        void datePickerWeekSelect_ValueChanged(object sender, EventArgs e)
        {
            //DateTime dt = datePickerWeekSelect.Value;
            DateTime dt = monthCalendar.SelectionStart;
            int a = Convert.ToInt16(dt.DayOfWeek);
            DateTime startWeek = dt.AddDays(1 - Convert.ToInt16(dt.DayOfWeek.ToString("d")));
            string dayOfWeek = startWeek.DayOfWeek.ToString();

            panelWeekDay.Controls.Clear();

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


                panelWeekDay.Controls.Add(l);
                panelWeekDay.Controls.Add(l2);
                panelWeekDay.Controls.Add(l_morning);
                panelWeekDay.Controls.Add(l_afternoon);

            }
            pictureBox1.Visible = true;
            panelWeekDay.Visible = true;
           

            string weekFirstDay = Miscellaneous.GetWeekFirstDayStr(startWeek);
            InitGridData(weekFirstDay);   
        }


        private DataTable GetGridJHistoryData()
        {

            DataTable home_table = new DataTable();
            //DateTime dt = datePickerWeekSelect.Value;
            DateTime dt = new DateTime();
            DateTime startWeek = dt.AddDays(1 - Convert.ToInt16(dt.DayOfWeek.ToString("d")));
            string weekFirstDayStr = Miscellaneous.GetWeekFirstDayStr(startWeek);

            string xmlfileFullPath = Miscellaneous.GetSchedulerXMLFullPath(weekFirstDayStr);



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

        private void InitGridData(string weekFirstDay)
        {
           DataTable dataTable = LoadHomeSchedules(Miscellaneous.GetSchedulerXMLFullPath(weekFirstDay));
           if (dataTable != null)
           {
               dataGridHistory.DataSource = dataTable;
               dataGridHistory.Visible = true;


               for (int i = 0; i < dataGridHistory.Columns.Count - 1; i++)
               {
                   dataGridHistory.Columns[i].Frozen = true;
                   dataGridHistory.Columns[i].ReadOnly = true;
               }

               //set grid cells width
               for (int i = 1; i < 15; i++)
               {
                   dataGridHistory.Columns[i].Width = 60;
               }
           }
           else {
               dataGridHistory.DataSource = new DataTable();
               dataGridHistory.Visible = false;
           }
        }

        private DataTable LoadHomeSchedules(string fileXmlFullPath)
        {
            bool isExisted = DataInit.IsFileExited(fileXmlFullPath);
            if (isExisted)
            {
                List<Schedules> schedulesList = XMLHelper.GetSchedules(fileXmlFullPath);
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

    }
}
