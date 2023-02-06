// might be replaced by build in function
static T[] ReverseArray<T>(T[] arr)
{
    T[] reversedArr = new T[arr.Length];

    for (int i = 0; i < arr.Length; i++)
    {
        reversedArr[i] = arr[arr.Length - i - 1];
    }

    return reversedArr;
}


static int[] LoadArrayFromConsole()
{
    // load declared array size
    string? rawDeclaredArrSize = Console.ReadLine();
    int declaredArrSize;
    bool parseSuccesDeclaredArrSzie = int.TryParse(rawDeclaredArrSize, out declaredArrSize);

    if (!parseSuccesDeclaredArrSzie)
    {

        throw new Exception($"Falided to parse array size declaration");

    }

    // load array as a string
    // may be inefficiend in case of loading big arrays
    string[]? rawArrayInput = Console.ReadLine()?.Trim().Split(' ');

    if (rawArrayInput is null || rawArrayInput.Length == 0) return Array.Empty<int>();

    if (rawArrayInput.Length != declaredArrSize)
    {
        throw new Exception($"Declared size of array is {declaredArrSize} but {rawArrayInput.Length} elements were given. ");
    }

    int[] parsedArr = new int[declaredArrSize];

    for (int i = 0; i < rawArrayInput.Length; i++)
    {
        int parsedInput;
        bool parseSucces = int.TryParse(rawArrayInput[i], out parsedInput);

        if (!parseSucces)
        {
            throw new Exception($"Falided to parse input array at {i} position");
        }

        parsedArr[i] = parsedInput;
    }

    return parsedArr;
}

int[] arr = LoadArrayFromConsole();
int[] arrRev = ReverseArray(arr);

Console.WriteLine(string.Join(' ', arrRev));
