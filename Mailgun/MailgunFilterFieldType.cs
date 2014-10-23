using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace Mailgun {
    public enum MailgunFilterFieldType {
             
        [Description("event")]
        Event,
        [Description("list")]
        List,
        [Description("attachment")]
        Attachment,
        [Description("from")]
        From,
        [Description("message-id")]
        MessageId,
        [Description("subject")]
        Subject,
        [Description("to")]
        To,
        [Description("size")]
        Size,
        [Description("recipient")]
        Recipient,
        [Description("tags")]
        Tags,
        [Description("severity")]
        Severity,
    }

}
