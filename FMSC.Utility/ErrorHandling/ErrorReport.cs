using System;

using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Drawing;
using System.IO;

namespace FMSC.Utility.ErrorHandling
{
    [Serializable]
    public partial class ErrorReport
    {
        private string _reportContent; 
        private static object _errorFileSyncLock = new object();
        public String HostApplication {get; set; }



        public DateTime Time { get; set; }
        public String AssemblyName { get; set; }
        public String CLRVersion { get; set; }
        public String OSVersion { get; set; }
        public String ExceptionInfo { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public Exception Exception { get; set; }

        private string _reportDirectory;
        public string ReportDirectory
        {
            get
            {
                if (_reportDirectory == null)
                {
                    _reportDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"/CruiseFiles/ErrorReports";
                    Directory.CreateDirectory(_reportDirectory);
                }
                return _reportDirectory;
            }
        }

#if !NET_CF
        public string LoadedAssemblies
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (Assembly ass in assemblies)
                {
                    builder.AppendFormat(" {0}\r\n CodeBase: {1}\r\n---------\r\n", ass.FullName, ass.CodeBase);
                }
                return builder.ToString();
            }
            set
            {
            }
        }
#endif


        public ErrorReport()
        {
        }
        
        public ErrorReport(Exception e, Assembly callingAssembly)
        {
            this.HostApplication = GetHostApplication();
            this.Time = DateTime.Now;
            this.AssemblyName = callingAssembly.FullName;
            this.CLRVersion = Environment.Version.ToString();
            this.OSVersion = Environment.OSVersion.ToString();
            this.ExceptionInfo = e.ToString();
            this.Exception = e;

        }




        private static string GetHostApplication()
        {
            return AppDomain.CurrentDomain.FriendlyName;
            //return GetEntryAssemply().GetLoadedModules()[0].Name;
        }



        //public void GenerateScreenShot(String path)
        //{
        //    Rectangle bounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
        //    using (Bitmap img = new Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format16bppRgb565))
        //    using (Graphics g = Graphics.FromImage(img))
        //    {
        //        g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
        //        img.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    }

        //}

        public void MakeErrorReport()
        {
            string fileName = string.Format("ErrorReport_{0:MM_dd_yy_mm_hh}.xml", this.Time);
            string absPath = this.ReportDirectory + "\\" + fileName;
            lock (_errorFileSyncLock)
            {
                using (FileStream stream = File.OpenWrite(absPath))
                using (StreamWriter writer = new StreamWriter(stream, Encoding.Unicode))
                {
                    writer.Write(this.ToString());
                    writer.Close();
                }
            }

        }

        //private static Assembly GetEntryAssemply()
        //{
        //    return Assembly.GetExecutingAssembly() ?? Assembly.GetCallingAssembly();
        //}

        public override string ToString()
        {
            if (_reportContent == null)
            {
                System.Text.StringBuilder builder = new StringBuilder();
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(ErrorReport));
                using (System.IO.TextWriter writer = new System.IO.StringWriter(builder))
                {
                    serializer.Serialize(writer, this);
                    writer.Flush();
                    writer.Close();
                }
                _reportContent = builder.ToString();
            }
            return _reportContent;
        }

    }
}
