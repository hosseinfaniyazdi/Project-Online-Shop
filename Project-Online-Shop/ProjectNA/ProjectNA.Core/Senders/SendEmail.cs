﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ProjectNA.Core.Senders
{
    public class SendEmail
    {
        public static void Send(string to, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("businessplanforhossein@gmail.com", "فروشگاه لباس NA");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            //System.Net.Mail.Attachment attachment;
            // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            // mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("businessplanforhossein@gmail.com", "Plan_1209");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }
    }
}