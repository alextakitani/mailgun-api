using System;
using System.Collections.Generic;
using System.Linq;

namespace Mailgun {
    public class MailgunEventParams {

        public DateTime? Begin { get; set; }
        public DateTime? End { get; set; }
        public bool? Ascending { get; set; }
        public bool? Pretty { get; set; }
        public int? Limit { get; set; }
        public MailgunFilterFieldType? FilterFieldType { get; set; }
        public string FilterFieldValue { get; set; }
    }
}