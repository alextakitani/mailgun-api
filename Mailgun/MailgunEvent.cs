using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Mailgun {
    public enum MailgunEvent {
        [Description("accepted")]
        Accepted,
        [Description("rejected")]
        Rejected,
        [Description("delivered")]
        Delivered,
        [Description("failed")]
        Failed,
        [Description("opened")]
        Opened,
        [Description("clicked")]
        Clicked,
        [Description("unsubscribed")]
        Unsubscribed,
        [Description("complained")]
        Complained,
        [Description("stored")]
        Stored,

    }
}
