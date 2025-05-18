using System;

namespace DospackFull.Models
{
    public class DosEvent
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public DateTime Timestamp { get; set; }
        public string MedicationName { get; set; } = string.Empty;
        public string EventType { get; set; } = string.Empty; // Given, Missed, etc.
        public string? Notes { get; set; }
    }
}
