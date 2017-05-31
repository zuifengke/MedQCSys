using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.Common.Libraries;
using Heren.MedQC.Core;
using Heren.MedQC.Utilities.IDCardRead;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Pabo.Calendar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Heren.MedQC.MedRecord.Dialogs
{
    public partial class HolidaySettingForm : MetroForm
    {
        private int Year = DateTime.Now.Year;
        public HolidaySettingForm()
        {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ChargeCalendarYear();
        }
        private void xPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnNextYear_Click(object sender, EventArgs e)
        {
            Year++;
            ChargeCalendarYear();
        }

        private void ChargeCalendarYear()
        {
            this.metroLabel1.Text = this.Year.ToString() + "年";
            this.monthCalendar1.ActiveMonth.Year = Year;
            this.monthCalendar2.ActiveMonth.Year = Year;
            this.monthCalendar3.ActiveMonth.Year = Year;
            this.monthCalendar4.ActiveMonth.Year = Year;
            this.monthCalendar5.ActiveMonth.Year = Year;
            this.monthCalendar6.ActiveMonth.Year = Year;
            this.monthCalendar7.ActiveMonth.Year = Year;
            this.monthCalendar8.ActiveMonth.Year = Year;
            this.monthCalendar9.ActiveMonth.Year = Year;
            this.monthCalendar10.ActiveMonth.Year = Year;
            this.monthCalendar11.ActiveMonth.Year = Year;
            this.monthCalendar12.ActiveMonth.Year = Year;
            this.monthCalendar1.Dates.Clear();
            this.monthCalendar2.Dates.Clear();
            this.monthCalendar3.Dates.Clear();
            this.monthCalendar4.Dates.Clear();
            this.monthCalendar5.Dates.Clear();
            this.monthCalendar6.Dates.Clear();
            this.monthCalendar7.Dates.Clear();
            this.monthCalendar8.Dates.Clear();
            this.monthCalendar9.Dates.Clear();
            this.monthCalendar10.Dates.Clear();
            this.monthCalendar11.Dates.Clear();
            this.monthCalendar12.Dates.Clear();

            List<KeyValueData> lstKeyValueDatas = null;
            short shRet = KeyValueDataAccess.Instance.GetHolidays(this.Year.ToString(), ref lstKeyValueDatas);
            if (lstKeyValueDatas == null)
                return;
            foreach (KeyValueData item in lstKeyValueDatas)
            {
                DateTime time;
                if (!DateTime.TryParse(item.DATA_VALUE, out time))
                    continue;
                DateItem dateItem = new DateItem();
                dateItem.Date = time;
                dateItem.Tag = item;
                dateItem.DateColor = Color.Black;
                dateItem.ImageListIndex = 0;
                AddDateItem(dateItem);
            }
            this.Update();
        }

        private void AddDateItem(DateItem dateItem)
        {
            switch (dateItem.Date.Month.ToString())
            {
                case "1":
                    this.monthCalendar1.Dates.Add(dateItem);
                    break;
                case "2":
                    this.monthCalendar2.Dates.Add(dateItem);
                    break;
                case "3":
                    this.monthCalendar3.Dates.Add(dateItem);
                    break;
                case "4":
                    this.monthCalendar4.Dates.Add(dateItem);
                    break;
                case "5":
                    this.monthCalendar5.Dates.Add(dateItem);
                    break;
                case "6":
                    this.monthCalendar6.Dates.Add(dateItem);
                    break;
                case "7":
                    this.monthCalendar7.Dates.Add(dateItem);
                    break;
                case "8":
                    this.monthCalendar8.Dates.Add(dateItem);
                    break;
                case "9":
                    this.monthCalendar9.Dates.Add(dateItem);
                    break;
                case "10":
                    this.monthCalendar10.Dates.Add(dateItem);
                    break;
                case "11":
                    this.monthCalendar11.Dates.Add(dateItem);
                    break;
                case "12":
                    this.monthCalendar12.Dates.Add(dateItem);
                    break;
                default:
                    break;
            }
        }

        private void btnPreYear_Click(object sender, EventArgs e)
        {
            Year--;
            ChargeCalendarYear();
        }

        private void monthCalendar_DayClick(object sender, Pabo.Calendar.DayClickEventArgs e)
        {
            DateItem dateItem = new DateItem();
            dateItem.Date = DateTime.Parse(e.Date);
            dateItem.DateColor = Color.Black;
            dateItem.ImageListIndex = 0;


            short shRet = SystemData.ReturnValue.OK;
            foreach (DateItem item in (sender as Pabo.Calendar.MonthCalendar).Dates)
            {
                if (item.Date == dateItem.Date)
                {
                    KeyValueData keyValueDate = item.Tag as KeyValueData;
                    if (keyValueDate != null)
                        shRet = KeyValueDataAccess.Instance.Delete(keyValueDate.ID);
                    (sender as Pabo.Calendar.MonthCalendar).Dates.Remove(item);
                    return;
                }
            }

            KeyValueData key = new KeyValueData();
            key.DATA_GROUP = "holiday";
            key.DATA_KEY = "日期";
            key.DATA_VALUE = dateItem.Date.ToString("yyyy-MM-dd");
            key.VALUE1 = this.Year.ToString();
            key.ID = key.MakeID();
            shRet = KeyValueDataAccess.Instance.Insert(key);
            dateItem.Tag = key;
            (sender as Pabo.Calendar.MonthCalendar).Dates.Add(dateItem);
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
