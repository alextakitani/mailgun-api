using System;
using System.Collections.Generic;
using System.Linq;

namespace Mailgun {
    public class RestException {
        public string Status { get; set; }
        public string MoreInfo { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
