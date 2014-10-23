using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailgun {
    public class MailgunAttachment {
        public string Size { get; set; }
        public string ContentType { get; set; }
        public string Filename { get; set; }
    }
}
