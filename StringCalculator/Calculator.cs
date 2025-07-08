namespace StringCalculator;

public class Calculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
            return 0;

        var delimiters = new List<string> { ",", "\n" };
        string numberPart = numbers;
        int ConsistsStar = 0;
        // Check for custom delimiter(s)
        if (numbers.StartsWith("//"))
        {
            int newlineIndex = numbers.IndexOf('\n');
            string delimiterSection = numbers.Substring(2, newlineIndex - 2);
            delimiters.Clear(); // Use only custom delimiters
            if (numbers[2] == '*' && numbers[3]=='\n')
            {
                ConsistsStar = 1;
            }
            // Handle multiple/multi-char delimiters like //[***][%%]
            if (delimiterSection.StartsWith("["))
            {
                int i = 0;
                while (i < delimiterSection.Length)
                {
                    if (delimiterSection[i] == '[')
                    {
                        int j = delimiterSection.IndexOf(']', i);
                        string delimiter = delimiterSection.Substring(i + 1, j - i - 1);
                        delimiters.Add(delimiter);
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
                // Single-character custom delimiter
                delimiters.Add(delimiterSection);
            }

            numberPart = numbers.Substring(newlineIndex + 1);
        }

        // Replace all delimiters with comma for uniform processing
        foreach (var delimiter in delimiters)
        {
            numberPart = numberPart.Replace(delimiter, ",");
        }
        
        // Parse and sum numbers
        string[] tokens = numberPart.Split(',', StringSplitOptions.RemoveEmptyEntries);
        var negatives = new List<int>();
        int sum = 0;
        if (ConsistsStar == 1)
        {
            sum = 1;
            foreach (var token in tokens)
            {
                int number = int.Parse(token.Trim());

                if (number < 0)
                    negatives.Add(number);
                else if (number <= 1000)
                    sum *= number;
            }
        }
        else
        {
            foreach (var token in tokens)
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
