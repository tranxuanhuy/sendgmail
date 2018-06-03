using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EASendMail; //add EASendMail namespace

namespace mysendemail
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = File.ReadLines("email.txt");

            foreach (var item in collection)
            {
                SmtpMail oMail = new SmtpMail("TryIt");
                SmtpClient oSmtp = new SmtpClient();

                // Set sender email address, please change it to yours
                oMail.From = "tranxuanhuy227@gmail.com";
                // Set recipient email address, please change it to yours
                oMail.To = item+"@gmail.com";

                // Set email subject
                oMail.Subject = "test email from c# project";

                // Set email body
                oMail.TextBody = "this is a test email sent from c# project, do not reply";

                // Your SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.gmail.com");
                // User and password for ESMTP authentication, if your server doesn't require
                // User authentication, please remove the following codes.
                oServer.User = "tranxuanhuy227@gmail.com";
                oServer.Password = "tranxuanhuy";

                // If your smtp server requires TLS connection, please add this line
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
                // If your smtp server requires implicit SSL connection on 465 port, please add this line
                oServer.Port = 465;
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                try
                {
                    Console.WriteLine("start to send email ...");
                    oSmtp.SendMail(oServer, oMail);
                    Console.WriteLine("email was sent successfully!");
                }
                catch (Exception ep)
                {
                    Console.WriteLine("failed to send email with the following error:");
                    Console.WriteLine(ep.Message);
                } 
            }
            
        }
    }
}