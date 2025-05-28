namespace ParkingApi.Models
{
    public class ParkingSession
    {
        public int Id { get; set; }
        public required string Plate { get; set; }
        public required DateTimeOffset EntryTime { get; set; }
        public required decimal RatePerMinute { get; set; }
        public DateTimeOffset? ExitTime { get; set; }
        public int MinutesCharged {  get; set; }
        public decimal Subtotal { get; set; }
        public decimal Taxes { get; set; }
        public decimal Total { get; set; }
    }
}
