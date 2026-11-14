using ParkSmart.Application;
using ParkSmart.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkSmart.UnitTests
{
    public class ParkingFeeCalculatorTests
    {
        [Fact]
        public void CalculateParking_Should_Be_After_Zero()
        {
            var barking = new ParkingSession
            {
                EntryTime = new DateTime(2026, 11, 14, 10, 0, 0),
                ExitTime = new DateTime(2026, 11, 14, 10, 16, 0)
            };
            var calculator = new ParkingFeeCalculator();
            var result = calculator.CalculateParkingFee(barking);
            result.Should().Be(10.00m);
        }
        [Fact]
        public void Calculate_When_ExitTime_Is_lessThan_EntryTime_Should_Throw_Exception()
        {
            var barking = new ParkingSession
            {
                EntryTime = new DateTime(2026, 11, 14, 10, 0, 0),
                ExitTime = new DateTime(2026, 11, 14, 9, 59, 0)
            };
            var calculator = new ParkingFeeCalculator();
            Action act = ()=> calculator.CalculateParkingFee(barking);
            act.Should().Throw<ArgumentException>().WithMessage("Exit time must be after entry time.");
        }
        [Fact]
        public void Calcault_When_ExitTime_Is_Equal_EntryTime_Should_Return_Zero()
        {
            var barking = new ParkingSession
            {
                EntryTime = new DateTime(2026, 11, 14, 10, 0, 0),
                ExitTime = new DateTime(2026, 11, 14, 10, 0, 0)
            };
            var calculator = new ParkingFeeCalculator();
            var result = calculator.CalculateParkingFee(barking);
            result.Should().Be(0.00m);
        }
    }
}
