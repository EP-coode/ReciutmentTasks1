static int[] LoadArrayFromConsole()
{
    string[]? rawData = Console.ReadLine()?.Split(' ');

    if (rawData is null)
    {
        throw new Exception("Illegal input.");
    }

    if (rawData.Length != 11)
    {
        throw new Exception($"Illegal input. Input array must contain 11 elements but {rawData.Length} elements were given.");
    }

    int[] parsedArr = new int[rawData.Length];

    for (int i = 0; i < rawData.Length; i++)
    {
        bool parseSucces = int.TryParse(rawData[i], out parsedArr[i]);

        if (!parseSucces)
        {
            throw new Exception($"Parsing error at {i} element of array.");
        }
    }

    return parsedArr;
}

static bool IsPaermutation(int[] arr1, int[] arr2)
{
    if (arr1.Length != arr2.Length) return false;

    Dictionary<int, int> numberOfOccurences = new Dictionary<int, int>();

    for (int i = 0; i < arr1.Length; i++)
    {
        if (numberOfOccurences.ContainsKey(arr1[i]))
        {
            numberOfOccurences[arr1[i]]++;
        }
        else
        {
            numberOfOccurences[arr1[i]] = 1;
        }
    }

    for (int i = 0; i < arr2.Length; i++)
    {
        if (numberOfOccurences.ContainsKey(arr2[i]))
        {
            if (numberOfOccurences[arr2[i]] == 0) return false;

            numberOfOccurences[arr2[i]]--;
        }
        else
        {
            return false;
        }
    }

    return true;
}


int[] arr1 = LoadArrayFromConsole();
int[] arr2 = LoadArrayFromConsole();

bool isPermutation = IsPaermutation(arr1, arr2);

Console.WriteLine(isPermutation ? "YES" : "NO");