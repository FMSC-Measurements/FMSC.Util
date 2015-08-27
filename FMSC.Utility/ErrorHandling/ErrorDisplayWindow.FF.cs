using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace FMSC.Utility.ErrorHandling
{
    

    public partial class ErrorDisplayWindow : Form , IErrorWindowView 
    {
        public ErrorDisplayWindow(ErrorReport report)
        {
            Report = report;
            InitializeComponent();
            this.linkLabel1.Text = Report.ReportDirectory;
        }

        public ErrorWindowLogic Presenter { get; set; }
        public ErrorReport Report { get; set; }

        #region IErrorWindowView Members

        //public bool IsScreenShotOptionEnabled
        //{
        //    get
        //    {
        //        return this.ScreenShotOptionCheckBox.Enabled;
        //    }
        //    set
        //    {
        //        this.ScreenShotOptionCheckBox.Enabled = value;
        //    }
        //}

        //public bool IsScreenShotOptionSelected
        //{
        //    get
        //    {
        //        if (SendReportCheckBox.Checked == false) { return false; }
        //        return ScreenShotOptionCheckBox.Checked;
        //    }
        //    set
        //    {
        //        if (value == true && SendReportCheckBox.Checked == false) { return; }
        //        ScreenShotOptionCheckBox.Checked = value;
        //    }
        //}

        //public bool IsSendReportOptionSelected
        //{
        //    get
        //    {
        //        return SendReportCheckBox.Checked;
        //    }
        //    set
        //    {
        //        this.SendReportCheckBox.Checked = value;
        //    }
        //}

        //public string RecipiantEmail
        //{
        //    get
        //    {
        //        return recipientLinkLabel.Text;
        //    }
        //    set
        //    {
        //        this.recipientLinkLabel.Text = value;
        //    }
        //}

 

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(Report.ReportDirectory);
            }
            catch
            {
            }
        }
    }
}
