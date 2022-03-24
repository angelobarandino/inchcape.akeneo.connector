using System;

namespace Inchcape.Akeneo.Connector.Models
{
    public class LoggingInfo
    {
        public string Request { get; set; }

        public string Response { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime StartTime { get; set; }

        public Exception Exception { get; set; }

        public string Url { get; set; }
    }
}