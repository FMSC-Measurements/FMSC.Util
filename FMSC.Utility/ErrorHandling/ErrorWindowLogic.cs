using System;
using System.Text;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

namespace FMSC.Utility.ErrorHandling
{
    public class ErrorWindowLogic
    {

        public ErrorReport Report;

        public ErrorWindowLogic(IErrorWindowView view, ErrorReport report)
        {
            _view = view;
            _view.Presenter = this;
            Report = report;
        }

        private IErrorWindowView _view;

        //public bool CanEmailReport { get { return _view.IsSendReportOptionSelected; } }
        //public bool UseScreenShot { get { return _view.IsScreenShotOptionSelected; }}

        //public void SendReport()
        //{
        //    if (CanEmailReport == false) { return; }
        //    ReportMailer mailer = new ReportMailer();
        //    mailer.To = _view.RecipiantEmail;
        //    mailer.From  = "benjaminjcampbell@js.fed.us";
        //    mailer.Subject = String.Format("{0} | {1}", Report.HostApplication, Report.Exception.Message);
            
        //    if(UseScreenShot)
        //    {
        //        mailer.UseAttachment = GetScreenShotPath();
        //    }

        //    mailer.Send(Report);
        //}

        //public string GetScreenShotPath()
        //{
        //    return string.Format("{0}\\ScreenShot.jpg", ReportFolderPath);
        //}

        //public String ReportFolderPath
        //{
        //    get
        //    {
        //        return String.Format("{0}\\ErrorReport_{1}_{2}_{3}_{4}_{5}",
        //            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        //            Report.Time.Month,
        //            Report.Time.Day,
        //            Report.Time.Year,
        //            Report.Time.Hour,
        //            Report.Time.Minute);
        //    }
        //}

        //public void GenerateReport()
        //{


        //    DirectoryInfo di = new DirectoryInfo(ReportFolderPath);
        //    if (di.Exists == false)
        //    {
        //        di.Create();
        //    }

        //    FileInfo reportFile = new FileInfo(di.FullName + "\\ErrorReport.txt");
        //    StreamWriter writer = reportFile.AppendText();
        //    writer.Write(Report.ToString());
        //    writer.Flush();
        //    writer.Close();

        //    if (UseScreenShot == true)
        //    {
        //        Report.GenerateScreenShot(GetScreenShotPath());
        //    }

        //}
                                        
    }
}
