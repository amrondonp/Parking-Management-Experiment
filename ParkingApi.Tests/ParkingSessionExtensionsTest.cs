using ParkingApi.Models;
using ParkingApi.UseCases;

namespace ParkingApi.Tests
{
    public class ParkingSessionExtensionsTest
    {
        [Fact]
        public void FinishParking_UpdatesChargesAndTime()
        {
            var parking = new ParkingSession
            {
                Plate = "UCP277",
                EntryTime = new DateTimeOffset(2025, 5, 3, 8, 15, 22, TimeSpan.Zero),
                RatePerMinute = 80
            };

            var currentTime = new DateTimeOffset(2025, 5, 3, 9, 8, 49, TimeSpan.Zero);
            parking.FinishParking(currentTime);

            Assert.Equal(currentTime, parking.ExitTime);
            Assert.Equal(53, parking.MinutesCharged);
            Assert.Equal(53 * 80, parking.Subtotal);
            Assert.Equal((53 * 80)*0.19m, parking.Taxes);
            Assert.Equal((53 * 80)*1.19m, parking.Total);
        }

    }
}