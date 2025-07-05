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
    [Fact]
    public void Add_TwoNumbersSeparatedByComma_ReturnsTheirSum()
    {
        var calc = new Calculator();

        var result = calc.Add("1,5");

        Assert.Equal(6, result);
    }
    [Fact]
    public void Add_MultipleNumbers_ReturnsTheirSum()
    {
        var calc = new Calculator();
        var result = calc.Add("1,2,3,4");
        Assert.Equal(10, result);
    }


}
