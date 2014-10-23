using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailgun {
    public class MailgunDeliveryStatus {
        public string Message { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public double SessionSeconds { get; set; }
    }
}
