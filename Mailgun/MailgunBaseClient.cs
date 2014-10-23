using System;
using System.Collections.Generic;
using System.Linq;

namespace Mailgun {
    public abstract class MailgunBaseClient {

        public string MailgunApiBaseUrl {
            get {
                return "https://api.mailgun.net/v2/"; ;
            }
        }

    }
}
