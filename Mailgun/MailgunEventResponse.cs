using System;
using System.Collections.Generic;
using System.Linq;

namespace Mailgun  {
    public class MailgunEventResponse : MailgunBaseResponse {
        public List<MailgunEventItem> Items { get; set; }
        public MailgunPaging Paging { get; set; }
    }
}
