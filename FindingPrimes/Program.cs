static int GetPrimesCountInRange(int lowerBound, int upperBound)
{
    bool[] mayBePrime = new bool[upperBound];
    mayBePrime[0] = false;

    Array.Fill(mayBePrime, true);

    for (int i = 2; i * i < upperBound; i++)
    {
        if (mayBePrime[i])
        {
            for (int j = i * i; j < upperBound; j += i)
            {
                mayBePrime[j] = false;
            }
        }
    }

    int totalPrimesCount = 0;

    // Althought notation [m, n] suggest that we shloud include
    // lower and upper bound in output test cases suggest otherwise 
    for (int i = lowerBound + 1; i < upperBound; i++)
    {
        if (mayBePrime[i])
            totalPrimesCount++;
    }


    return totalPrimesCount;
}

// TODO: input validation

string? rawNumberOfTest = Console.ReadLine();

if (rawNumberOfTest is null)
{
    throw new Exception("Illegal input");
}

int numberOfTests = int.Parse(rawNumberOfTest);


List<(int, int)> testParams = new();

for (int i = 0; i < numberOfTests; i++)
{
    string[]? rawInput = Console.ReadLine()?.Split(' ');

    if (rawInput is null)
    {
        throw new Exception("Illegal input");
    }

    int lowerBound = int.Parse(rawInput[0]);
    int upperBound = int.Parse(rawInput[1]);

    testParams.Add((lowerBound, upperBound));
}

testParams.Select(i => GetPrimesCountInRange(i.Item1, i.Item2))
    .ToList().ForEach(Console.WriteLine);