using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace Utilities
{
    public class Logging
    {
    }

    public class ErrorHandling
    {

        public static DateTime lastemail = DateTime.Now;
        public static DateTime lastBigSister = DateTime.Now;
        public static string smtpserver = "";
        /// <summary>
        /// This is the value in Ticks that is the minimum time in between emails and Big sister Notifications
        /// </summary>
        public static long acceptableInterval = TimeSpan.TicksPerMinute / 2;
        /// <summary>
        /// takes an exception as input and logs it to file and potentially to the System EventLog
        /// </summary>
        /// <param name="oException">the exception</param>
        /// <param name="errPath">the path you would like to log it to</param>
        /// <param name="bSysEventLog">log it to the system event log?</param>
        public static void WriteExceptionLog(Exception oException, string errPath, bool bSysEventLog)
        {
            try
            {
                FileTools.SForceFileCreation(errPath);
                StreamWriter sw = new StreamWriter(errPath, true);
                sw.WriteLine("====================================================================");
                sw.WriteLine("Source        : " +
                        oException.Source.ToString().Trim());
                sw.WriteLine("Method        : " +
                        oException.TargetSite.Name.ToString());
                sw.WriteLine("Date        : " +
                        DateTime.Now.ToLongTimeString());
                sw.WriteLine("Time        : " +
                        DateTime.Now.ToShortDateString());
                sw.WriteLine("Computer    : " +
                        Dns.GetHostName().ToString());
                sw.WriteLine("Error        : " +
                        oException.Message.ToString().Trim());
                sw.WriteLine("Stack Trace    : " +
                        oException.StackTrace.ToString().Trim());
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex) { }

            if (bSysEventLog)
            {
                try
                {
                    string message = oException.GetBaseException().Message;
                    System.Diagnostics.EventLog log = new System.Diagnostics.EventLog();
                    log.Source = oException.Source.ToString().Trim();
                    log.WriteEntry(message);
                }
                catch (Exception) { }
            }
        }
        /// <summary>
        /// This logs the message to the path provided
        /// </summary>
        /// <param name="mess">the message</param>
        /// <param name="errPath">the path</param>
        /// 

        public static void WriteMessageLog(string mess, string errPath)
        {

            mess = DateTime.Now + " - " + mess;

            try
            {
                FileTools.SForceFileCreation(errPath);
                StreamWriter sw = new StreamWriter(errPath, true);
                sw.WriteLine(mess);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                var log = new System.Diagnostics.EventLog { Source = ex.Source.Trim() };
                log.WriteEntry(ex.Message);
            }

        }
        public static void LogMultiple(string mess, string path, string email, string shortinfo)
        {
            WriteMessageLog(mess, path);
            SendEmail(shortinfo, mess, Dns.GetHostName() + "@errorhandler.com", email);
        }
        public static void SendEmail(string subject, string msg, string sender, string to)
        {
            SendEmail(subject, msg, sender, to, false);
        }
        public static void SendEmail(string subject, string msg, string sender, string to, bool overrideInterval)
        {
            try
            {
                if ((DateTime.Now.Subtract(lastemail).Ticks > acceptableInterval || overrideInterval))
                {
                    var kfdEmail = new Email(smtpserver);
                    kfdEmail.SetEmail(subject.ToString(), msg.ToString());
                    kfdEmail.AddToAddress(to);
                    kfdEmail.SetSender(sender);
                    kfdEmail.SetBodyIsHTML(false);
                    kfdEmail.SetTimeoutInSeconds(30);
                    kfdEmail.SendEmail();
                    lastemail = DateTime.Now;
                }
            }
            catch (Exception e)
            {

                var log = new System.Diagnostics.EventLog { Source = e.Source.Trim() };
                log.WriteEntry(e.Message);
            }
        }

    }

    public class Email
    {
        private readonly List<string> to_addresses = new List<string>();
        private readonly List<string> to_addresses_name = new List<string>();
        private readonly List<string> cc_addresses = new List<string>();
        private readonly List<string> cc_addresses_name = new List<string>();
        private readonly List<string> bcc_addresses = new List<string>();
        private readonly List<string> attachments = new List<string>();
        private string sender_address = "";
        private string sender_name = "";
        private string subject = "";
        private string body = "";
        private string smtp = "";
        private string last_error = "";
        private bool is_body_html = false;
        private int time_out = 30000;	// milliseconds, default is 30 seconds

        /*
        public KFDEmail(string cMel1)
        {
			KFDPaths path = new KFDPaths( cMel1 );
			smtp = path.GetServer( "smtp" );
			if (smtp.Length == 0)
				smtp = "smtp.factualdata.com";
        }
        */

        public Email(string smtpIn)
        {

            smtp = smtpIn;
            if (StringTools.Empty(smtp))
                smtp = "smtp.krollfactualdata.com";
        }

        public void OverideSMTP(string cSMTP)
        {
            if (!StringTools.Empty(cSMTP))
                smtp = cSMTP;
        }

        public void ClearEmail()
        {
            to_addresses.Clear();
            cc_addresses.Clear();
            bcc_addresses.Clear();
            attachments.Clear();
            sender_address = "";
            sender_name = "";
            subject = "";
            body = "";
            last_error = "";
            is_body_html = false;
            time_out = 30000;
        }

        public void AddToAddress(string cAddress, string cDispaly)
        {
            to_addresses.Add(cAddress);
            to_addresses_name.Add(cDispaly);
        }

        public void AddToAddress(string cAddress)
        {
            to_addresses.Add(cAddress);
            to_addresses_name.Add("");
        }

        public void AddCCAddress(string cAddress, string cDisplay)
        {
            cc_addresses.Add(cAddress);
            cc_addresses_name.Add(cDisplay);
        }

        public void AddCCAddress(string cAddress)
        {
            cc_addresses.Add(cAddress);
            cc_addresses_name.Add("");
        }

        public void AddBCCAddress(string cAddress)
        {
            bcc_addresses.Add(cAddress);
        }

        public void SetSender(string cAddress, string cDisplay)
        {
            sender_address = cAddress;
            sender_name = cDisplay;
        }

        public void SetSender(string cAddress)
        {
            sender_address = cAddress;
            sender_name = "";
        }

        public void AddAttachment(string cFileName)
        {
            attachments.Add(cFileName);
        }

        public void SetEmail(string cSubject, string cBody)
        {
            subject = cSubject;
            body = cBody;
        }

        public void SetTimeoutInSeconds(int seconds)
        {
            if (seconds > 0)
                time_out = (seconds * 1000);
        }

        public void SetBodyIsHTML(bool message)
        {
            is_body_html = message;
        }

        public string GetLastError()
        {
            return last_error;
        }

        public bool SendEmail()
        {
            if (to_addresses.Count <= 0)
                last_error = "Email Error: no to addresses.";
            else if (sender_address.Length <= 0)
                last_error = "Email error: no sender addrees.";
            else if (body.Length <= 0)
                last_error = "Email Error: no body found.";
            else
            {
                FileTools fu = new FileTools();
                try
                {
                    MailAddress from = new MailAddress(sender_address, sender_name);
                    MailAddress to = new MailAddress(to_addresses[0], to_addresses_name[0]);
                    MailMessage message = new MailMessage(from, to);

                    for (int x = 1; x < to_addresses.Count; ++x)
                    {
                        MailAddress mmessage = new MailAddress(to_addresses[x], to_addresses_name[x]);
                        message.To.Add(mmessage);
                    }

                    for (int x = 0; x < cc_addresses.Count; ++x)
                    {
                        MailAddress mmessage = new MailAddress(cc_addresses[x], cc_addresses_name[x]);
                        message.CC.Add(mmessage);
                    }

                    for (int x = 0; x < bcc_addresses.Count; ++x)
                    {
                        MailAddress mmessage = new MailAddress(bcc_addresses[x]);
                        message.Bcc.Add(mmessage);
                    }

                    for (int x = 0; x < attachments.Count; ++x)
                    {
                        if (FileTools.SFileExists(attachments[x]))
                        {
                            Attachment data = new Attachment(attachments[x]);
                            ContentDisposition disposition = data.ContentDisposition;
                            disposition.CreationDate = File.GetCreationTime(attachments[x]);
                            disposition.ModificationDate = File.GetLastWriteTime(attachments[x]);
                            disposition.ReadDate = File.GetLastAccessTime(attachments[x]);
                            message.Attachments.Add(data);
                        }

                        else
                            last_error = "Email Error: " + attachments[x] + " does not exist";
                    }

                    message.Body = body;
                    message.Subject = subject;
                    message.IsBodyHtml = is_body_html;
                    SmtpClient client = new SmtpClient(smtp);
                    client.Timeout = time_out;
                    client.Send(message);
                    message.Dispose();
                }

                catch (ObjectDisposedException e)
                {
                    last_error = e.Message;
                }

                catch (SmtpFailedRecipientsException)
                {
                    // no biggie, the address was wrong but it was sent
                }

                catch (ArgumentNullException e)
                {
                    last_error = e.Message;
                }

                catch (ArgumentOutOfRangeException e)
                {
                    last_error = e.Message;
                }

                catch (InvalidOperationException e)
                {
                    last_error = e.Message;
                }


                catch (SmtpException e)
                {
                    last_error = e.Message;
                }
            }

            return (last_error.Length <= 0);
        }
    }
}


