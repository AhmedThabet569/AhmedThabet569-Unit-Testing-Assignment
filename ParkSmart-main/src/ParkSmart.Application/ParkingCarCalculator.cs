using ParkSmart.Application.Calculators;
using ParkSmart.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkSmart.Application
{
    public class ParkingCarCalculator : VehicleFeeCalculatorBase
    {
        protected override decimal HourlyRate => 10m;
        protected override decimal DailyCap => 80m;
    }
}
