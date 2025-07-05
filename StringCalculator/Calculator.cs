namespace StringCalculator;

public class Calculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
            return 0;

        string[] delimiters = { ",", "\n" };
        string[] tokens = numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        int sum = 0;
        foreach (string token in tokens)
        {
            sum += int.Parse(token.Trim());
        }

        return sum;
    }


}
