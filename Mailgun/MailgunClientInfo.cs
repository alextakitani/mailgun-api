using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailgun {
    public class MailgunClientInfo {
        public string ClientType { get; set; }
        public string ClientOS { get; set; }
        public string DeviceType { get; set; }
        public string ClientName { get; set; }
        public string UserAgent { get; set; }
    }
}
