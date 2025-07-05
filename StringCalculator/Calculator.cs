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
            delimiter = numbers.Substring(2, newlineIndex - 2);
            numberPart = numbers.Substring(newlineIndex + 1);
        }

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
