// skip first line
Console.ReadLine();

char[]? digits = Console.ReadLine()?.ToCharArray().Where(c => char.IsDigit(c)).ToArray();

if (digits is null)
{
    throw new Exception("Failed to load digits.");
}

Dictionary<char, int> digitsOccurances = new();

for (int i = 0; i < digits.Length; i++)
{
    if (digitsOccurances.ContainsKey(digits[i]))
    {
        digitsOccurances[digits[i]]++;
    }
    else
    {
        digitsOccurances[digits[i]] = 1;
    }
}

char topDigit = digits[0];

for (int i = 1; i < digits.Length; i++)
{
    if (digitsOccurances[digits[i]] > digitsOccurances[topDigit]
        || digitsOccurances[digits[i]] == digitsOccurances[topDigit]
        && int.Parse(topDigit.ToString()) < int.Parse(digits[i].ToString())
       )
    {
        topDigit = digits[i];
    }
}

Console.WriteLine(topDigit);