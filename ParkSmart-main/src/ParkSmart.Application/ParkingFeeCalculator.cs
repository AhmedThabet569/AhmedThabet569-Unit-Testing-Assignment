using ParkSmart.Application.Calculators;
using ParkSmart.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkSmart.Application
{
    public class ParkingFeeCalculator 
    {
      public decimal CalcaulteParking(ParkingSession session)
        {
            VehicleFeeCalculatorBase calculator = session.Vehicle switch
            {
                VehicleType.Car => new ParkingCarCalculator(),
                VehicleType.Motorcycle => new ParkingMotoCalculator(),
                _ => throw new ArgumentOutOfRangeException(nameof(session.Vehicle), "Unsupported vehicle type.")
            };
            return calculator.Calculate(session);
        }
    }
}
