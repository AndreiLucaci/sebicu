using System;

namespace LambdaExpressions.Models
{
    public class MonitoredData
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ActivityLabel { get; set; }

        public TimeSpan Duration => (EndTime - StartTime);

        public override string ToString()
        {
            return $"{StartTime} - {EndTime}: {ActivityLabel} ({Duration})";
        }
    }
}
