using ParkSmart.Application.Calculators;
using ParkSmart.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkSmart.Application
{
    public class ParkingMotoCalculator : VehicleFeeCalculatorBase
    {
        protected override decimal HourlyRate => 5m;
        protected override decimal DailyCap => 40m;
    }
}
