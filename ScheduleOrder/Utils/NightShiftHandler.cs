using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScheduleOrder.Utils
{
    /// <summary>
    /// 夜班排版处理类
    /// </summary>
    class NightShiftHandler
    {
        public static void GenerateNightShiftCell(string shiftNum, DataGridView dataGridView_home,DataGridViewCell currentCell)
        {
            try
            {
                var shiftObj = AppConfiguration.GetNightShiftObj(shiftNum);
                int rowIndex = currentCell.RowIndex;
                int columnIndex = currentCell.ColumnIndex;
                string cellVal = currentCell.Value.ToString();
                if (string.IsNullOrEmpty(cellVal))
                {
                    dataGridView_home.Rows[rowIndex].Cells[columnIndex].Value = shiftObj.NightShiftName;
                    dataGridView_home.Rows[rowIndex].Cells[columnIndex].Tag = shiftObj.NightShiftIndex;
                }
                else {
                    dataGridView_home.Rows[rowIndex].Cells[columnIndex].Value =string.Format("{0}/{1}",cellVal, shiftObj.NightShiftName);
                    dataGridView_home.Rows[rowIndex].Cells[columnIndex].Tag = string.Format("{0}/{1}", currentCell.Tag.ToString(), shiftObj.NightShiftIndex);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
