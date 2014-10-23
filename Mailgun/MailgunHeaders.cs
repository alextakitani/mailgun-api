using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailgun {
    public class MailgunHeaders {
        public string To { get; set; }
        public string From { get; set; }
        public string MessageId { get; set; }
        public string Subject { get; set; }
    }
}
