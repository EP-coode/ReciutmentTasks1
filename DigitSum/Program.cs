static int SumDigits(string str)
{
    return str.ToCharArray()
        .Where(c => char.IsDigit(c))
        .Select(c => int.Parse(c.ToString()))
        .Sum();
}

// skip first line
Console.ReadLine();

string[]? rawNumbers = Console.ReadLine()?.Split(' ');

if (rawNumbers is null)
{
    throw new Exception("Illegal input");
}

int indexOfMax = 0;
int valueOfMax = SumDigits(rawNumbers[0]);

for (int i = 1; i < rawNumbers.Length; i++)
{
    int currentDigitSum = SumDigits(rawNumbers[i]);

    if (currentDigitSum > valueOfMax
        || currentDigitSum == valueOfMax
        && int.Parse(rawNumbers[i]) > int.Parse(rawNumbers[indexOfMax]))
    {
        indexOfMax = i;
        valueOfMax = currentDigitSum;
    }
}

Console.WriteLine(indexOfMax);