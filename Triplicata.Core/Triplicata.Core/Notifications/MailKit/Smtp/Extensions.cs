using Autofac;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using Triplicata.Core.Extensions;

namespace Triplicata.Core.Notifications.MailKit
{
    public static class Extensions
    {
        public static void AddMailKit(this ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                var configuration = context.Resolve<IConfiguration>();
                var options = configuration.GetOptions<SmtpMailKitOptions>("smtpmailkit");

                return options;
            }).SingleInstance();
        }
    }
}
