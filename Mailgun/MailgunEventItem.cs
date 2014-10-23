using System;
using System.Collections.Generic;
using System.Linq;

namespace Mailgun {
    public class MailgunEventItem {

        public string Content { get; set; }
        public double Timestamp { get; set; }
        public MailgunEvent Event { get; set; }

        public string Recipient { get; set; }
        public string Domain { get; set; }
        public string UserVariables { get; set; }
        public MailgunMessage Message { get; set; }
        public string RecipientDomain { get; set; }
        public string Method { get; set; }
        public MailgunDeliveryStatus DeliveryStatus { get; set; }
        public MailgunEnvelope Envelope { get; set; }

        public List<string> Tags { get; set; }
        public string IP { get; set; }

        public MailgunGeolocation GeoLocation { get; set; }
        public MailgunClientInfo ClientInfo { get; set; }
        public MailgunEventFlags Flags { get; set; }
    }
}
