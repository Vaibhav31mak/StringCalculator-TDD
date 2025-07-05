namespace StringCalculator;

public class Calculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
            return 0;

        List<string> delimiters = new List<string>() { ",", "\n" };
        string numberPart = numbers;

        // Handle custom delimiters
        if (numbers.StartsWith("//"))
        {
            int newlineIndex = numbers.IndexOf('\n');
            string delimiterSection = numbers.Substring(2, newlineIndex - 2);

            if (delimiterSection.StartsWith("["))
            {
                // Multiple or multi-character delimiters
                int i = 0;
                while (i < delimiterSection.Length)
                {
                    if (delimiterSection[i] == '[')
                    {
                        int j = delimiterSection.IndexOf(']', i);
                        string d = delimiterSection.Substring(i + 1, j - i - 1);
                        delimiters.Add(d);
                        i = j + 1;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            else
            {
                // Single character delimiter
                delimiters.Add(delimiterSection);
            }

            numberPart = numbers.Substring(newlineIndex + 1);
        }

        // Normalize all delimiters to comma
        foreach (var d in delimiters)
        {
            numberPart = numberPart.Replace(d, ",");
        }

        string[] tokens = numberPart.Split(',');
        List<int> negatives = new List<int>();
        int sum = 0;

        foreach (var token in tokens)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                int number = int.Parse(token.Trim());

                if (number < 0)
                    negatives.Add(number);
                else if (number <= 1000)
                    sum += number;
            }
        }

        if (negatives.Count > 0)
            throw new Exception("negative numbers not allowed " + string.Join(",", negatives));

        return sum;
    }
}
