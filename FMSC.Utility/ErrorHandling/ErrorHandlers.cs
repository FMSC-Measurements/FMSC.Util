using System;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;

namespace FMSC.Utility.ErrorHandling
{
    public static partial class ErrorHandlers
    {

        public static void InitializeReport(Exception e, Assembly allembly)
        {


            ErrorReport report = new ErrorReport(e, allembly);
            report.MakeErrorReport();
#if Mobile
            try
            {
                MessageBox.Show(@"The application has unexpectantly crashed and will be closed.
                A Report has been generated and saved to:"
                    + report.ReportDirectory);
            }
            catch { }

            //System.Diagnostics.Process.Start("\\Windows\\explorer.exe", report.ReportDirectory);
#endif
#if !Mobile

            ErrorDisplayWindow view = new ErrorDisplayWindow(report);
            //ErrorWindowLogic logic = new ErrorWindowLogic(view, e.Exception);
            view.ShowDialog();
#endif
            Application.Exit();
            

        }

        

        public static UnhandledExceptionEventHandler UnhandledException
        {
            get
            {
                return UnhandledExceptionHandler;
            }
        }


        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            InitializeReport(e.ExceptionObject as Exception, Assembly.GetCallingAssembly());
        }
    }
}
