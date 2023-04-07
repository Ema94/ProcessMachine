using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.Core.Mailer.Configuration
{
    public class MailerConfig
    {
 
        public MailerSmtpCredentials Credentials { get; set; }
        public MailerAdresses Adresses { get; set; }
        public MailerMessage Message { get; set; }
        public MailerGeneralConfig GeneralsConfigs { get; set; }
    }
}
