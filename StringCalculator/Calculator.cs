namespace StringCalculator;

public class Calculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
            return 0;

        string[] delimiters = { ",", "\n" };
        string[] parts = numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        int sum = 0;
        foreach (string part in parts)
        {
            int number = int.Parse(part.Trim());
            sum += number;
        }

        return sum;
    }

}
