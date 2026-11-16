using ParkSmart.Application.Calculators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkSmart.Application
{
    public class ParkingTruckCalculator:VehicleFeeCalculatorBase
    {
        protected override decimal HourlyRate => 25m;
        protected override decimal DailyCap => 200m;

    }
}
