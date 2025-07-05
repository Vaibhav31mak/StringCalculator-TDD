namespace StringCalculator;

public class Calculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
            return 0;

        var parts = numbers.Split(',');

        if (parts.Length == 1)
            return int.Parse(parts[0]);

        if (parts.Length == 2)
            return int.Parse(parts[0]) + int.Parse(parts[1]);

        throw new ArgumentException("Too many numbers. Only two comma-separated numbers are allowed.");
    }


}
