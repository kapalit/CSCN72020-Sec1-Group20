using System.ComponentModel;
using System.Runtime.CompilerServices;
using SmartClassroom.Shared;

namespace SmartClassroom.GUI.ViewModels
{
    public class EnvironmentViewModel : INotifyPropertyChanged
    {
        private double temp;
        private double humidity;
        private double co2;

        public double Temperature
        {
            get => temp;
            set { temp = value; OnPropertyChanged(); }
        }

        public double Humidity
        {
            get => humidity;
            set { humidity = value; OnPropertyChanged(); }
        }

        public double CO2
        {
            get => co2;
            set { co2 = value; OnPropertyChanged(); }
        }

        public void HandleTelemetry(TelemetryPoint t)
        {
            if (t.Metric == "Temperature") Temperature = t.Value;
            if (t.Metric == "Humidity") Humidity = t.Value;
            if (t.Metric == "CO2") CO2 = t.Value;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
