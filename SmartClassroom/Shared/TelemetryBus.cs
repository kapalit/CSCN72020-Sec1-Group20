using System;
using System.Collections.Generic;

namespace SmartClassroom.Shared
{
    public class TelemetryBus
    {
        private readonly List<Action<TelemetryPoint>> subscribers = new();

        public void Publish(TelemetryPoint t)
        {
            foreach (var s in subscribers)
                s(t);
        }

        public void Subscribe(Action<TelemetryPoint> subscriber)
        {
            subscribers.Add(subscriber);
        }
    }
}
