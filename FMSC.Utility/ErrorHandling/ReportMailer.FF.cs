using System;

using System.Collections.Generic;
using System.Text;
//using FMSC.Controls;
using System.Net.Mail;

namespace FMSC.Utility.ErrorHandling
{
    class ReportMailer
    {
        public string From { get; set; }

        public string FromName { get; set; }

        public string To { get; set; }

        public string Cc { get; set; }

        public string Bcc { get; set; }

        public string ReplyTo { get; set; }

        public string UseAttachment { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string SmtpServer { get; set; }

        private bool _useSsl; 
        public bool UseSsl 
        { 
            get { return _useSsl; }
            set
            {
                if(value == true)
                {
                    this.Port = 465;
                }
                else
                {
                    this.Port = 25;
                }
                _useSsl = value;

            }
        }

        public int Port { get; set; }

        public MailPriority Priority { get; set; }

        public string UseAuthentication { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        internal void Send(ErrorReport report)
        {
            //StringBuilder builder = new StringBuilder();
            //string reportMessage = string.Format("{0}%20{1}", report.ExceptionInfo, report.Exception.ToString());
            //builder.AppendFormat("mailto:{0}?subject={1}&body={2}", this.To, this.Subject, reportMessage);

            ////if(!string.IsNullOrEmpty(UseAttachment))
            ////{
            ////    builder.AppendFormat("&attachment={0}", UseAttachment);
            ////}
            //builder.Replace(System.Environment.NewLine.ToString(), "%0A");
            //builder.Replace(" ", "%20");
            //builder.Replace("&", "");
            //System.Diagnostics.Process.Start(builder.ToString());

            SmtpClient client = new System.Net.Mail.SmtpClient();
            using(MailMessage message = new MailMessage())
            {
                client.Host = this.SmtpServer;
                client.Port = this.Port;

                client.EnableSsl = this.UseSsl;

                message.CC.Add(this.Cc);
                message.Bcc.Add(this.Bcc);

                message.Priority = this.Priority;

                message.To.Add(this.To);
                message.ReplyTo = new MailAddress(this.ReplyTo);
                message.From = new MailAddress(this.From, this.FromName);
                message.Subject = this.Subject;
                ////add report file?
                //if(!string.IsNullOrEmpty(this.UseAttachment))
                //{
                //    message.Attachments.Add(new Attachment(this.UseAttachment))
                //}

                message.Body = report.ToString();

                client.Send(message);
                System.Diagnostics.Trace.TraceInformation("Submitted error report via email to: " + this.To);
            }

        }

    }
}
