using System;

namespace SmartClassroom.Shared
{
    public class TelemetryPoint
    {
        public string DeviceId { get; }
        public string Metric { get; }
        public double Value { get; }
        public DateTime Timestamp { get; }

        public TelemetryPoint(string deviceId, string metric, double value)
        {
            DeviceId = deviceId;
            Metric = metric;
            Value = value;
            Timestamp = DateTime.Now;
        }
    }
}

