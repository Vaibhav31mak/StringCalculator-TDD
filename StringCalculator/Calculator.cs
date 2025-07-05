namespace StringCalculator;

public class Calculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
            return 0;

        string delimiter = ",";
        int startIndex = 0;

        if (numbers.StartsWith("//"))
        {
            int newlineIndex = numbers.IndexOf('\n');
            delimiter = numbers.Substring(2, newlineIndex - 2);
            startIndex = newlineIndex + 1;
        }

        string cleanedNumbers = numbers.Substring(startIndex);
        cleanedNumbers = cleanedNumbers.Replace("\n", delimiter);
        List<string> tokens = new List<string>();
        int lastPos = 0;

        for (int i = 0; i <= cleanedNumbers.Length; i++)
        {
            if (i == cleanedNumbers.Length || cleanedNumbers[i].ToString() == delimiter)
            {
                string part = cleanedNumbers.Substring(lastPos, i - lastPos);
                if (!string.IsNullOrWhiteSpace(part))
                {
                    tokens.Add(part.Trim());
                }
                lastPos = i + 1;
            }
        }

        int sum = 0;

        foreach (var token in tokens)
        {
            sum += int.Parse(token);
        }

        return sum;
    }
}
