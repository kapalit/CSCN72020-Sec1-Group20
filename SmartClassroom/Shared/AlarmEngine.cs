using System.Collections.ObjectModel;

namespace SmartClassroom.Shared
{
    public class AlarmEngine
    {
        public ObservableCollection<AlarmEvent> ActiveAlarms { get; } = new();

        public void Raise(AlarmEvent alarm)
        {
            ActiveAlarms.Add(alarm);
        }
    }
}
