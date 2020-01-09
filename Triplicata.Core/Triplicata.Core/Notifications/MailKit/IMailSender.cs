using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Triplicata.Core.Notifications.MailKit
{
    public interface IMailSender
    {        
        Task SendTest(String body);
        Task Send(List<String> to, String body, List<string> bcc=null);
        Task Send(List<String> to, String subject, String body,List<string> bcc = null);
        Task Send(String from, List<String> to, String subject, String body, List<string> bcc = null);
        Task Send(List<String> to, String subject, String body, bool IsBodyHtml, List<string> bcc = null);
        Task Send(String from, List<String> to, String subject, String body, bool IsBodyHtml, List<string> bcc = null);
        Task Send(string from, List<string> tos, string subject, string body, bool IsBodyHtml, int port, string host, bool enableSsl, bool useDefaultCredentials, String password, SmtpDeliveryMethod smtpDeliveryMethod, List<string> bcc = null);
    }
}
