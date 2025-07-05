namespace StringCalculator;

public class Calculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
            return 0;

        string delimiter = ",";
        string numberPart = numbers;

        // Handle custom delimiter
        if (numbers.StartsWith("//"))
        {
            int newlineIndex = numbers.IndexOf('\n');
            delimiter = numbers.Substring(2, newlineIndex - 2);
            numberPart = numbers.Substring(newlineIndex + 1);
        }

        numberPart = numberPart.Replace("\n", delimiter);
        string[] tokens = numberPart.Split(delimiter);

        List<int> negativeNumbers = new List<int>();
        int sum = 0;

        for (int i = 0; i < tokens.Length; i++)
        {
            string t = tokens[i].Trim();
            if (t != "")
            {
                int value = int.Parse(t);
                if (value < 0)
                {
                    negativeNumbers.Add(value);
                }
                sum += value;
            }
        }

        if (negativeNumbers.Count > 0)
        {
            string message = "negative numbers not allowed " + string.Join(",", negativeNumbers);
            throw new Exception(message);
        }

        return sum;
    }


}
