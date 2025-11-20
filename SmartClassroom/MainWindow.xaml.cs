using SmartClassroom.GUI.ViewModels;
using SmartClassroom.GUI.Views;
using SmartClassroom.Modules;
using SmartClassroom.Shared;
using System.Threading.Tasks;
using System.Windows;

namespace SmartClassroom
{
    public partial class MainWindow : Window
    {
        private readonly TelemetryBus bus = new();
        private readonly AlarmEngine alarms = new();

        private readonly EnvironmentViewModel envVM = new();

        public MainWindow()
        {
            InitializeComponent();

            // ---- DISPLAY THE ENVIRONMENT VIEW IN THE WINDOW ----
            Content = new EnvironmentView
            {
                DataContext = envVM
            };

            // ---- CONNECT TELEMETRY UPDATES ----
            bus.Subscribe(tp =>
            {
                if (tp.DeviceId == "ENV")
                    envVM.HandleTelemetry(tp);
            });

            // ---- START ENVIRONMENT MODULE ----
            var envModule = new EnvironmentModule(bus, alarms);

            Task.Run(async () =>
            {
                while (true)
                {
                    envModule.Tick();
                    await Task.Delay(1000);
                }
            });
        }
    }
}
