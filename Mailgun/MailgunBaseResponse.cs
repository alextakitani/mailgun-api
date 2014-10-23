using System;
using System.Collections.Generic;
using System.Linq;

namespace Mailgun {
    public abstract class MailgunBaseResponse {
        public RestException RestException { get; set; }
        public Uri Uri { get; set; }
    }
}
