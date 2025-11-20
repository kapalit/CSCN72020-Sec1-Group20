using System.IO;
using SmartClassroom.Shared;

namespace SmartClassroom.Modules
{
    public class EnvironmentModule
    {
        private readonly TelemetryBus bus;
        private readonly AlarmEngine alarms;
        private readonly string[] lines;
        private int index = 0;

        public EnvironmentModule(TelemetryBus bus, AlarmEngine alarms)
        {
            this.bus = bus;
            this.alarms = alarms;

            lines = File.ReadAllLines("Data/environment.csv");
        }

        public void Tick()
        {
            var parts = lines[index].Split(',');

            double temp = double.Parse(parts[0]);
            double humidity = double.Parse(parts[1]);
            double co2 = double.Parse(parts[2]);

            bus.Publish(new TelemetryPoint("ENV", "Temperature", temp));
            bus.Publish(new TelemetryPoint("ENV", "Humidity", humidity));
            bus.Publish(new TelemetryPoint("ENV", "CO2", co2));

            if (temp > 27)
                alarms.Raise(new AlarmEvent("ENV-HIGH-TEMP", "Temperature is too high"));

            if (co2 > 1300)
                alarms.Raise(new AlarmEvent("ENV-HIGH-CO2", "CO₂ level unsafe"));

            index = (index + 1) % lines.Length;
        }
    }
}
