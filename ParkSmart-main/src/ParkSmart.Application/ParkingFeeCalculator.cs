using ParkSmart.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkSmart.Application
{
    public class ParkingFeeCalculator
    {
        public decimal CalculateParkingFee(ParkingSession session)
        {
            if (session.ExitTime < session.EntryTime)
            {
                throw new ArgumentException("Exit time must be after entry time.");
            }
            else if(session.ExitTime == session.EntryTime)
            {
                return 0m; // No fee for zero duration
            }
            var duration = session.ExitTime - session.EntryTime;
            if(duration.TotalMinutes <= 15)
            {
                return 0m; // Flat fee for the first hour
            }
            
            var hours = (decimal)Math.Ceiling(duration.TotalHours);
            return hours * 10m; // $10 per hour
        }
    }
}
