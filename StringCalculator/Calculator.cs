namespace StringCalculator;

public class Calculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
            return 0;

        string delimiter = ",";
        string numberPart = numbers;

        // Custom delimiter format
        if (numbers.StartsWith("//"))
        {
            int newlineIndex = numbers.IndexOf('\n');
            delimiter = numbers.Substring(2, newlineIndex - 2);
            numberPart = numbers.Substring(newlineIndex + 1);
        }

        // Normalize input by replacing newlines
        numberPart = numberPart.Replace("\n", delimiter);

        string[] tokens = numberPart.Split(delimiter);
        int sum = 0;

        foreach (var token in tokens)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                sum += int.Parse(token.Trim());
            }
        }

        return sum;
    }

}
