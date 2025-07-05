using Xunit;
using StringCalculator;

namespace StringCalculator.Tests;

public class CalculatorTests
{
    [Fact]
    public void Add_EmptyString_ReturnsZero()
    {
        var calc = new Calculator();

        var result = calc.Add("");

        Assert.Equal(0, result);
    }
    [Fact]
    public void Add_SingleNumber_ReturnsThatNumber()
    {
        var calc = new Calculator();

        var result = calc.Add("1");

        Assert.Equal(1, result);
    }

}
