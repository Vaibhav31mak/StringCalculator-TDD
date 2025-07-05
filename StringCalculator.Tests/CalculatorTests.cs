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
    [Fact]
    public void Add_NumbersWithNewLinesAndCommas_ReturnsSum()
    {
        var calc = new Calculator();
        var result = calc.Add("1\n2,3");
        Assert.Equal(6, result);
    }
    [Fact]
    public void Add_CustomDelimiter_ReturnsSum()
    {
        var calc = new Calculator();
        var result = calc.Add("//;\n1;2");
        Assert.Equal(3, result);
    }
    [Fact]
    public void Add_MultipleNegativeNumbers_ThrowsExceptionWithAllNegatives()
    {
        var calc = new Calculator();
        var ex = Assert.Throws<Exception>(() => calc.Add("-1,2,-4"));
        Assert.Equal("negative numbers not allowed -1,-4", ex.Message);
    }

    [Fact]
    public void Add_NumbersGreaterThan1000_AreIgnored()
    {
        var calc = new Calculator();
        var result = calc.Add("2,1001");
        Assert.Equal(2, result);
    }

    [Fact]
    public void Add_DelimiterOfAnyLength_ReturnsSum()
    {
        var calc = new Calculator();
        var result = calc.Add("//[***]\n1***2***3");
        Assert.Equal(6, result);
    }
    [Fact]
    public void Add_MultipleDelimiters_ReturnsSum()
    {
        var calc = new Calculator();
        var result = calc.Add("//[*][%]\n1*2%3");
        Assert.Equal(6, result);
    }


}
