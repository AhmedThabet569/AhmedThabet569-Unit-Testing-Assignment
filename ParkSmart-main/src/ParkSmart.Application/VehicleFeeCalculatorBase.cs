using ParkSmart.Domain;

namespace ParkSmart.Application.Calculators;

public abstract class VehicleFeeCalculatorBase
{
    protected abstract decimal HourlyRate { get; }
    protected abstract decimal DailyCap { get; }

    public decimal Calculate(ParkingSession session)
    {
        ValidateTime(session);

        var duration = session.ExitTime - session.EntryTime;
        if (duration.TotalMinutes <= 15)
        {
            return 0m;
        }

        return CalculateDailyBlocks(duration);
    }

    private void ValidateTime(ParkingSession session)
    {
        if (session.ExitTime < session.EntryTime)
        {
            throw new ArgumentException("Exit time must be after entry time.");
        }
    }

    private decimal CalculateDailyBlocks(TimeSpan duration)
    {
        int fullDays = (int)(duration.TotalHours / 24);
        double remainingHours = duration.TotalHours - (fullDays * 24);

        decimal remainingFee = (decimal)Math.Ceiling(remainingHours) * HourlyRate;
        decimal cappedRemainingFee = Math.Min(remainingFee, DailyCap);

        return (fullDays * DailyCap) + cappedRemainingFee;
    }
}