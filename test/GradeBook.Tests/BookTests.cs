using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GradeBook.Tests;

public class BookTests
{
    [Fact]                  // attribute
    public void CheckInvalidEntryNotAddedToGrades()
    {
        // arrange
        var book = new InMemoryBook("Test Book");
        book.AddGrade(112.7); // invalid entry

        // act
        List<double> bookGrades = book.GetGrades();

        // assert (api)
        Assert.Empty(bookGrades);
    }

    [Fact]                  // attribute
    public void BookCalculatesStatistics()
    {
        // arrange
        var book = new InMemoryBook("Test Book");
        book.AddGrade(89.1);
        book.AddGrade(90.5);
        book.AddGrade(77.3);

        // act
        // var result = book.GetStatisticsWithForeach();
        // var result = book.GetStatisticsWithDoWhile();
        // var result = book.GetStatisticsWithWhile();
        var result = book.GetStatisticsWithFor();

        // assert (api)
        Assert.Equal(85.6, result.Average, 1);
        Assert.Equal(90.5, result.High, 1);
        Assert.Equal(77.3, result.Low, 1);
        Assert.Equal('B', result.Letter);
    }
}