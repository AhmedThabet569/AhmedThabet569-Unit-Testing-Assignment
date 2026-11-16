using DriveNow.Domain.Services;
using System;

public class RentalMathTests
{
    //public static int CalculateAge(DateTime dateOfBirth, DateTime onDate) =>
    //    FullYears(dateOfBirth, onDate);
    [Theory]
    [InlineData("2005-11-08", "2026-11-07", 20)]
    [InlineData("2005-11-06", "2026-11-07", 21)]
     public void CalculateAge_ShouldReturnCorrectAge(string dateOfBirthStr, string onDateStr, int expectedAge)
    {
        // Arrange
        DateTime dateOfBirth = DateTime.Parse(dateOfBirthStr);
        DateTime onDate = DateTime.Parse(onDateStr);
        // Act
        int actualAge = RentalMath.CalculateAge(dateOfBirth, onDate);
        // Assert
        Assert.Equal(expectedAge, actualAge);
    }

    [Theory]
    [InlineData("2020-01-01", "2023-01-01", 3)]
    public void CalculateLicenseYears_ShouldReturnCorrectYears(string issueDateStr, string onDateStr, int expectedYears)
    {
        // Arrange
        DateTime issueDate = DateTime.Parse(issueDateStr);
        DateTime onDate = DateTime.Parse(onDateStr);
        // Act
        int actualYear = RentalMath.CalculateLicenseYears(issueDate, onDate);
        Assert.Equal(expectedYears, actualYear);
    }
}
