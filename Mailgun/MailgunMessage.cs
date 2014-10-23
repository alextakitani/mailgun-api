using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailgun {
    public class MailgunMessage {
        public MailgunHeaders Headers { get; set; }
        public List<MailgunAttachment> Attachments { get; set; }
        public List<string> Recipients { get; set; }
    }
}
