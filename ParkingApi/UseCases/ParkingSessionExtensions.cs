using ParkingApi.Models;

namespace ParkingApi.UseCases
{
    public static class ParkingSessionExtensions
    {
        public static void FinishParking(this ParkingSession parkingSession, DateTimeOffset currentTime)
        {
            var startTimeMinute = RoundToMinute(parkingSession.EntryTime);
            var endTimeMinute = RoundToMinute(currentTime);
            int minutes = (int)(endTimeMinute - startTimeMinute).TotalMinutes;

            parkingSession.ExitTime = currentTime;
            parkingSession.MinutesCharged = minutes;
            parkingSession.Subtotal = minutes * parkingSession.RatePerMinute;
            parkingSession.Taxes = parkingSession.Subtotal * 0.19m;
            parkingSession.Total = parkingSession.Subtotal + parkingSession.Taxes;
        }

        private static DateTimeOffset RoundToMinute(DateTimeOffset time)
        {
            return new DateTimeOffset(time.Year, time.Month, time.Day, time.Hour, time.Minute, 0, TimeSpan.Zero);
        }
    }
}
