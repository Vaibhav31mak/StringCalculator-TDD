namespace StringCalculator;

public class Calculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
            return 0;

        if (numbers.Contains(","))
        {
            var parts = numbers.Split(',');
            int sum = 0;
            foreach (var part in parts)
            {
                sum += int.Parse(part);
            }
            return sum;
        }

        return int.Parse(numbers);
    }

}
