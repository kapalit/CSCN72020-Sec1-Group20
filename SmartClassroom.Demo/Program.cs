using System;
using SmartClassroom.Modules;
using SmartClassroom.Core.Interfaces;
using SmartClassroom.Core.Models;
using SmartClassroom.Core.Enums;

// Demo implementations for interfaces
using SmartClassroom.Demo;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Smart Classroom Environment Module Demo ===");

        // Create our fake CSV reader (or real one if you have it)
        IDataReader reader = new CsvDataReader();
        reader.Initialize("sample_environment_data.csv");

        // Console implementations for telemetry and alarms
        ITelemetryBus telemetryBus = new ConsoleTelemetryBus();
        IAlarmEngine alarmEngine = new ConsoleAlarmEngine();

        // Create the environment module
        var module = new EnvironmentModule(
            "EnvModule01",
            "Room101",
            reader,
            telemetryBus,
            alarmEngine
        );

        // Start module
        module.Start();

        Console.WriteLine("Module running... Press ENTER to stop.");
        Console.ReadLine();

        module.Stop();
    }
}
