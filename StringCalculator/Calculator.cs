namespace StringCalculator;

public class Calculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
            return 0;

        string delimiter = ",";
        string numberPart = numbers;

        // Check for custom delimiter
        if (numbers.StartsWith("//"))
        {
            int newlineIndex = numbers.IndexOf('\n');

            if (numbers[2] == '[')
            {
                // Delimiter in format //[***]
                int start = numbers.IndexOf('[') + 1;
                int end = numbers.IndexOf(']');
                delimiter = numbers.Substring(start, end - start);
            }
            else
            {
                // Single character delimiter
                delimiter = numbers.Substring(2, newlineIndex - 2);
            }

            numberPart = numbers.Substring(newlineIndex + 1);
        }

        // Replace newlines with delimiter and split
        numberPart = numberPart.Replace("\n", delimiter);
        string[] tokens = numberPart.Split(delimiter);

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
        {
            throw new Exception("negative numbers not allowed " + string.Join(",", negatives));
        }

        return sum;
    }


}
