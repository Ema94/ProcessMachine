using JEA.Components.Core.Mailer.Configuration;

namespace JEA.Components.Core.Mailer
{
    public interface IMailer
    {
        Task<MailerResult> Send(MailerConfig config);
    }
}
