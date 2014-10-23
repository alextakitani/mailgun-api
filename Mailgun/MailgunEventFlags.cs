using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailgun {
    public class MailgunEventFlags {
        public bool IsAuthenticated { get; set; }
        public bool IsTestMode { get; set; }
    };
}
