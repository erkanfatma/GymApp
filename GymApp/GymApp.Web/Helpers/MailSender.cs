using GymApp.Web.Models;
using System.Net;
using System.Net.Mail;

namespace GymApp.Web.Helpers;
public static class MailSender {
    private const string SenderMail = "fatmapiksel2@outlook.com";
    private const string SenderPassword = "M|[lJt71981u";
    public static void SendMail(string fullname, List<string> mailAddresses) {
        try {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(SenderMail);

            for (int i = 0; i < mailAddresses.Count; i++) {
                mailMessage.To.Add(mailAddresses[i]);
            }

            string body = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n   " +
                " <meta charset=\"utf-8\" />\r\n    <title></title>\r\n  " +
                "  <style>\r\n        body{\r\n       " +
                "     background-color:red;\r\n        " +
                "    color:white;\r\n        }\r\n " +
                "   </style>\r\n</head>\r\n<body>\r\n " +
                "   <h1>Merhaba, hoşgeldiniz</h1>\r\n  " +
                "  <p>sizi görmek güzel</p>\r\n</body>\r\n</html>";

            mailMessage.Subject = "Hoş geldiniz";
            mailMessage.Body = body; // $"<h1> Merhaba {fullname},</h1> \n Sitemize hoşgeldin.";
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp-mail.outlook.com";
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(SenderMail, SenderPassword);
            smtpClient.EnableSsl = true;


            smtpClient.Send(mailMessage);
            Console.WriteLine("Email Sent Successfully.");
        }
        catch (Exception ex) {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private static void ResetPassword(string fullname, string mailAddress) {

    }
    private static void ConfirmEmail(string fullname, string mailAddress) {

    }
    private static void Welcome(string fullname, string mailAddress) {

    }

    private static async Task HolidayMessage(List<User> users) {
        for (int i = 0; i < users.Count; i++) {
            try {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(SenderMail);

                mailMessage.To.Add(users[i].Email);

                string body = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n   " +
                    " <meta charset=\"utf-8\" />\r\n    <title></title>\r\n  " +
                    "  <style>\r\n        body{\r\n       " +
                    "     background-color:red;\r\n        " +
                    "    color:white;\r\n        }\r\n " +
                    "   </style>\r\n</head>\r\n<body>\r\n " +
                    "   <h1>Merhaba, hoşgeldiniz</h1>\r\n  " +
                    "  <p>sizi görmek güzel</p>\r\n</body>\r\n</html>";

                mailMessage.Subject = "Hoş geldiniz";
                mailMessage.Body = body; // $"<h1> Merhaba {fullname},</h1> \n Sitemize hoşgeldin.";
                mailMessage.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp-mail.outlook.com";
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(SenderMail, SenderPassword);
                smtpClient.EnableSsl = true;


                await smtpClient.SendMailAsync(mailMessage);
                Console.WriteLine("Email Sent Successfully.");
            }
            catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message);
            }

        }


    }
}
