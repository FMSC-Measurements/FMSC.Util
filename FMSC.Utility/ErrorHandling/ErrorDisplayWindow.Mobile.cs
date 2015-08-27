using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Report.ReportDirectory, null);
            }
            catch
            {
            }
        }
    }
}