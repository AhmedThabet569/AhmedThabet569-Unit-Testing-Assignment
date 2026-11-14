using ParkSmart.Application;
using ParkSmart.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkSmart.UnitTests
{
    public class ParkingFeeCalculatorTests
    {
        private readonly ParkingFeeCalculator _calculator = new();
        [Fact]
        public void CalculateParking_Should_Be_After_Zero()
        {
            var barking = new ParkingSession
            {
                EntryTime = new DateTime(2026, 11, 14, 10, 0, 0),
                ExitTime = new DateTime(2026, 11, 14, 10, 15, 0),
                Vehicle = VehicleType.Car
            };
            var result = _calculator.CalcaulteParking(barking);
            result.Should().Be(0.00m);
        }
        [Fact]
        public void Calculate_When_ExitTime_Is_lessThan_EntryTime_Should_Throw_Exception()
        {
            var barking = new ParkingSession
            {
                EntryTime = new DateTime(2026, 11, 14, 10, 0, 0),
                ExitTime = new DateTime(2026, 11, 14, 9, 59, 0),
                Vehicle = VehicleType.Car

            };
            Action act = ()=> _calculator.CalcaulteParking(barking);
            act.Should().Throw<ArgumentException>().WithMessage("Exit time must be after entry time.");
        }
        [Fact]
        public void Calcault_When_ExitTime_Is_Equal_EntryTime_Should_Return_Zero()
        {
            var barking = new ParkingSession
            {
                EntryTime = new DateTime(2026, 11, 14, 10, 0, 0),
                ExitTime = new DateTime(2026, 11, 14, 10, 0, 0),
                Vehicle = VehicleType.Car

            };
            var result = _calculator.CalcaulteParking(barking);
            result.Should().Be(0.00m);
        }
        [Fact]
        public void Calculate_When_ParkingTime10H_Should_Return_80()
        {
            var barking = new ParkingSession
            {
                EntryTime = new DateTime(2026, 11, 14, 10, 0, 0),
                ExitTime = new DateTime(2026, 11, 14, 20, 0, 0),
                Vehicle = VehicleType.Car
            };
            var result = _calculator.CalcaulteParking(barking);
            result.Should().Be(80.00m);
        }
        [Fact]
        public void Calculate_When_ParkingTime30H_Should_Return_140()
        {
            var barking = new ParkingSession
            {
                EntryTime = new DateTime(2026, 11, 14, 10, 0, 0),
                ExitTime = new DateTime(2026, 11, 15, 16, 0, 0),
                Vehicle = VehicleType.Car

            };
            var result = _calculator.CalcaulteParking(barking);
            result.Should().Be(140.00m);
        }
        [Fact]
        public void Calculte_When_ParkingTime48H_Should_Return_160()
        {
            var barking = new ParkingSession
            {
                EntryTime = new DateTime(2026, 11, 14, 10, 0, 0),
                ExitTime = new DateTime(2026, 11, 16, 10, 0, 0),
                Vehicle = VehicleType.Car
            };
            var result = _calculator.CalcaulteParking(barking);
            result.Should().Be(160.00m);
        }
        [Fact]
        public void Calculate_When_ParkingTime48H_And_10Min_Should_Return_170()
        {
            var barking = new ParkingSession
            {
                EntryTime = new DateTime(2026, 11, 14, 10, 0, 0),
                ExitTime = new DateTime(2026, 11, 16, 10, 10, 0),
                Vehicle = VehicleType.Car
            };
            var result = _calculator.CalcaulteParking(barking);
            result.Should().Be(170.00m);
        }
        [Fact]
        public void Calculate_When_MotorcycleParking10H_Should_Return_40()
        {
            var session = new ParkingSession
            {
                EntryTime = new DateTime(2026, 11, 14, 10, 0, 0),
                ExitTime = new DateTime(2026, 11, 14, 20, 0, 0),
                Vehicle = VehicleType.Motorcycle
            };

            var result = _calculator.CalcaulteParking(session);

            result.Should().Be(40.00m); // 10 hours * 5 EGP = 50, but daily cap is 40 EGP[cite: 13]
        }

        [Fact]
        public void Calculate_When_TruckParking30H_Should_Return_350()
        {
            var session = new ParkingSession
            {
                EntryTime = new DateTime(2026, 11, 14, 10, 0, 0),
                ExitTime = new DateTime(2026, 11, 15, 16, 0, 0),
                Vehicle = VehicleType.Truck
            };

            var result = _calculator.CalcaulteParking(session);

            result.Should().Be(350.00m); // Day 1 cap (200) + 6 remaining hours * 25 (150) = 350[cite: 13]
        }
        [Fact]
        public void Calculate_When_CarParkingAtNight_Should_Return_NightFlatRate()
        {
            var session = new ParkingSession
            {
                EntryTime = new DateTime(2026, 11, 14, 23, 0, 0),
                ExitTime = new DateTime(2026, 11, 16, 07, 0, 0),
                Vehicle = VehicleType.Car
            };
            var result = _calculator.CalcaulteParking(session);

            result.Should().Be(30.00m);
        }
        [Fact]
        public void Calculate_When_MotoParkingAtNight_Should_Return_NightFlatRate()
        {
            var session = new ParkingSession
            {
                EntryTime = new DateTime(2026, 11, 14, 23, 0, 0),
                ExitTime = new DateTime(2026, 11, 16, 07, 0, 0),
                Vehicle = VehicleType.Motorcycle
            };
            var result = _calculator.CalcaulteParking(session);

            result.Should().Be(15.00m);
        }
        [Fact]
        public void Calculate_When_TruckParkingAtNight_Should_Return_NightFlatRate()
        {
            var session = new ParkingSession
            {
                EntryTime = new DateTime(2026, 11, 14, 23, 0, 0),
                ExitTime = new DateTime(2026, 11, 16, 07, 0, 0),
                Vehicle = VehicleType.Truck
            };
            var result = _calculator.CalcaulteParking(session);

            result.Should().Be(75.00m);
        }
    }
}
