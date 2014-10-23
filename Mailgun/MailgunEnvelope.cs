using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailgun {
    public class MailgunEnvelope {
        public string Sender { get; set; }
        public string SenderIp { get; set; }
        public string Targets { get; set; }
        public string Transport { get; set; }
    }
}
