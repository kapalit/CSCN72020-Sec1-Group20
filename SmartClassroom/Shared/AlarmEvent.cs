namespace SmartClassroom.Shared
{
    public class AlarmEvent
    {
        public string Id { get; }
        public string Message { get; }

        public AlarmEvent(string id, string message)
        {
            Id = id;
            Message = message;
        }
    }
}
