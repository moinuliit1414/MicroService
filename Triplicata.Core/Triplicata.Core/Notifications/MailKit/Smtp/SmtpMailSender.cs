using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Triplicata.Core.Notifications.MailKit.Smtp
{
    public class SmtpMailSender : IMailSender
    {
        SmtpMailKitOptions _option;
        SmtpMailSender(SmtpMailKitOptions option) {
            _option = option;
        }
        public async Task Send(List<string> to, string body, List<string> bcc = null)
        {
            await Send(to, _option.Subject, body);
        }

        public async Task Send(List<string> to, string subject, string body, List<string> bcc = null)
        {
            await Send(to, subject, body);
        }

        public async Task Send(string from, List<string> to, string subject, string body, List<string> bcc = null)
        {
            await Send(from, to, subject, body, true);
        }

        public async Task Send(List<string> to, string subject, string body, bool IsBodyHtml, List<string> bcc=null)
        {
            await Send(_option.From, to, subject, body, IsBodyHtml, bcc);
        }

        public async Task Send(string from, List<string> to, string subject, string body, bool IsBodyHtml, List<string> bcc=null)
        {
            await Send(from, to, subject, body, IsBodyHtml, _option.Port, _option.SmtpHost, _option.EnableSsl, _option.UseDefaultCredentials, _option.Password, SmtpDeliveryMethod.Network, bcc);
        }
        public Task SendTest(string body)
        {
            throw new NotImplementedException();
        }
        public async Task Send(string from, List<string> tos, string subject, string body, bool IsBodyHtml, int port, string host, bool enableSsl, bool useDefaultCredentials,String password, SmtpDeliveryMethod smtpDeliveryMethod, List<string> bccs)
        {
            using (MailMessage message = new MailMessage()) {
                message.From = new MailAddress(from);
                foreach (String to in tos) {
                    message.To.Add(new MailAddress(to));
                }
                if (bccs != null) {
                    foreach (String bcc in bccs)
                    {
                        message.Bcc.Add(new MailAddress(bcc));
                    }
                }                
                //message.To.Add( to.Select(s => new MailAddress(s)).ToList<MailAddress>());
                //message.To.Add(new MailAddress("ToMailAddress"));
                message.Subject = subject;
                message.IsBodyHtml = IsBodyHtml; //to make message body as html  
                message.Body = body;
                SmtpClient smtp = new SmtpClient();
                smtp.Port = port;
                smtp.Host = host;
                smtp.EnableSsl = enableSsl;
                if (!useDefaultCredentials) {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(from, password);
                }
                smtp.DeliveryMethod = smtpDeliveryMethod;
                await smtp.SendMailAsync(message);
            }
        }
    }
}
