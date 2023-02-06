static HashSet<UInt32> LoadUniqueNumbers()
{
    HashSet<UInt32> numbers = new HashSet<UInt32>();
    string? currentInput = Console.ReadLine();

    while (currentInput is not null && currentInput != "")
    {
        UInt32 parsedNumber;
        bool parseSucces = UInt32.TryParse(currentInput, out parsedNumber);

        if (!parseSucces)
        {
            throw new Exception($"Invalid input at line {numbers.Count()}");
        }

        numbers.Add(parsedNumber);
        currentInput = Console.ReadLine();
    }

    return numbers;
}

// TODO: find better complexity or heuristic
static HashSet<UInt32> GetPowersOfTwoFromArray(HashSet<UInt32> numbers)
{
    HashSet<UInt32> powersOfTwo = new();

    foreach (UInt32 number in numbers)
    {
        for (int i = 0; i < 32 && (1u << i) <= number; i++)
        {
            if (number % (1u << i) == 0)
            {
                powersOfTwo.Add(1u << i);
            }
        }
    }

    return powersOfTwo;
}


var uniqueNumbersFromInput = LoadUniqueNumbers();
var powersOfTwo = GetPowersOfTwoFromArray(uniqueNumbersFromInput);

if (powersOfTwo.Count == 0)
{
    Console.WriteLine("NA");
}
else
{
    List<UInt32> sortedPowersOfTwo = new(powersOfTwo);
    sortedPowersOfTwo.Sort();
    Console.WriteLine(string.Join(", ", sortedPowersOfTwo));
}