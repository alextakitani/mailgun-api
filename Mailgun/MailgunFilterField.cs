using System;
using System.Collections.Generic;
using System.Linq;

namespace Mailgun {
    public class MailgunFilterField {
        public MailgunFilterFieldType FieldType { get; set; }
        public string Value { get; set; }
    }
}
