namespace StringCalculator;

public class Calculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
            return 0;

        string[] parts = numbers.Split(',');
        return parts.Select(int.Parse).Sum();
    }

}
