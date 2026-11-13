using System;

public class RentalMathTests
{
    //public static int CalculateAge(DateTime dateOfBirth, DateTime onDate) =>
    //    FullYears(dateOfBirth, onDate);
    [Fact]
	[Theory]
    [InlineData("2005-11-08", "2026-11-07", 20)]
    [InlineData("2005-11-06", "2026-11-07", 21)]
    public void CalculateAge_WhenBirthdayIsToday_ReturnsCorrectAge(string dateOfBirthStr, string onDateStr, int expectedAge)
	{
        var dateOfBirth = DateTime.Parse(dateOfBirthStr);
        var onDate = DateTime.Parse(onDateStr);

    }
}
