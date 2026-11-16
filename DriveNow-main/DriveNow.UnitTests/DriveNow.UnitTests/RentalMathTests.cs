using DriveNow.Domain.Services;
using FluentAssertions;
using System;

public class RentalMathTests
{
    //public static int CalculateAge(DateTime dateOfBirth, DateTime onDate) =>
    //    FullYears(dateOfBirth, onDate);
    [Theory]
    [InlineData("2005-11-08", "2026-11-07", 20)]
    [InlineData("2005-11-06", "2026-11-07", 21)]
    [InlineData("2005-11-07", "2026-11-07", 21)]
    public void CalculateAge_ShouldReturnCorrectAge(string dateOfBirthStr, string onDateStr, int expectedAge)
    {
        // Arrange
        DateTime dateOfBirth = DateTime.Parse(dateOfBirthStr);
        DateTime onDate = DateTime.Parse(onDateStr);
        // Act
        int actualAge = RentalMath.CalculateAge(dateOfBirth, onDate);
        // Assert
        //Assert.Equal(expectedAge, actualAge);
        actualAge.Should().Be(expectedAge);
    }

    [Theory]
    [InlineData("2020-01-01", "2023-01-01", 3)]
    [InlineData("2020-01-01", "2023-01-01", 3)]
    [InlineData("2020-01-01", "2023-01-01", 3)]

    public void CalculateLicenseYears_ShouldReturnCorrectYears(string issueDateStr, string onDateStr, int expectedYears)
    {
        // Arrange
        DateTime issueDate = DateTime.Parse(issueDateStr);
        DateTime onDate = DateTime.Parse(onDateStr);
        // Act
        int actualYear = RentalMath.CalculateLicenseYears(issueDate, onDate);
        //Assert.Equal(expectedYears, actualYear);
        actualYear.Should().Be(expectedYears);
    }
    public static int CalculateRentalDays(DateTime pickup, DateTime returnAt)
    {
        if (returnAt <= pickup)
            throw new ArgumentException("Return must be after pickup");

        var span = returnAt - pickup;
        var days = (int)(span.Ticks / TimeSpan.TicksPerDay);
        var remainder = TimeSpan.FromTicks(span.Ticks % TimeSpan.TicksPerDay);
        if (remainder.TotalMinutes >= 60)
            days++;

        return Math.Max(days, 1);
    }
    [Theory]
    [InlineData("2026-01-01 10:00", "2026-01-02 10:59", 1)] 
    [InlineData("2026-01-01 10:00", "2026-01-02 11:00", 2)] 
    [InlineData("2026-01-01 10:00", "2026-01-02 11:01", 2)] 

    public void CalculateRentalDays_ShouldApplyCorrectHours(string pickup, string returnAt, int expectedDays)
    {
        // Arrange
        DateTime pickupDate = DateTime.Parse(pickup);
        DateTime returnDate = DateTime.Parse(returnAt);
        int actualDays = RentalMath.CalculateRentalDays(pickupDate, returnDate);

        actualDays.Should().Be(expectedDays);
    }

    [Fact]
    public void calculateRentalDays_Shouldreturn_MaximumOfOneDay_WhenPickupAndReturnAreOnSameDay()
    {
        // Arrange
        DateTime pickup = new DateTime(2026, 1, 1, 10, 0, 0);
        DateTime returnAt = new DateTime(2026, 1, 1, 15, 0, 0);
        // Act
        int actualDays = RentalMath.CalculateRentalDays(pickup, returnAt);
        // Assert
        actualDays.Should().Be(1);
    }
    [Theory]
    [InlineData("2026-01-01 10:00", "2026-01-01 10:00")]
    [InlineData("2026-01-01 10:00", "2026-01-01 09:59")]
    public void CalculateRentalDays_ShouldReturnOneDay_WhenRentalDurationIsLessThanOneDay(string pickupStr,string returnAtStr)
    {
        // Arrange
        var pickup = DateTime.Parse(pickupStr);
        var returnAt = DateTime.Parse(returnAtStr);

       Action at = () => RentalMath.CalculateRentalDays(pickup, returnAt);
        // Act & Assert
        at.Should().Throw<ArgumentException>().WithMessage("Return must be after pickup");
    }
    [Theory]
    [InlineData("2004-02-29", "2025-02-27", 20)]
    [InlineData("2004-02-29", "2025-02-28", 21)]
    [InlineData("2004-02-29", "2025-03-01", 21)]
    public void CalculateAge_ShouldHandleLeapYearBirthdays(string dateOfBirthStr, string onDateStr, int expectedAge)
    {
        // Arrange
        DateTime dateOfBirth = DateTime.Parse(dateOfBirthStr);
        DateTime onDate = DateTime.Parse(onDateStr);
        // Act
        int actualAge = RentalMath.CalculateAge(dateOfBirth, onDate);
        // Assert
        actualAge.Should().Be(expectedAge);
    }

}
