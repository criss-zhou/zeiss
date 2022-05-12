using System;

namespace Zeiss.Models
{
    public class ReponseMessage
    {
        public string Topic { get; set; }
        public string Ref { get; set; }
        public Payload Payload { get; set; }
        public string Event { get; set; }
    }

    public class Payload
    {
        public Guid MachineId { get; set; }
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        Idle,
        Running,
        Finished,
        Errored
    }
}
