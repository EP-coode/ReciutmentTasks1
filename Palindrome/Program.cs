using System.Text.RegularExpressions;

static bool IsPalindrome(string str)
{
    for (int i = 0; i < str.Length / 2; i++)
    {
        // Specification does't describe whether "true palindrome" is sonsitive to
        // lower and upper case
        if (char.ToLowerInvariant(str[i]) != char.ToLowerInvariant(str[^(i + 1)]))
        {
            return false;
        }
    }

    return true;
}

static bool IsTruePalindrome(string str)
{
    string strWithoutNonAlphabeticValues = onalyAlphabetChars.Replace(str, "");
    return IsPalindrome(strWithoutNonAlphabeticValues);
}

string? inputString = Console.ReadLine();
bool isTruePalindrome = IsTruePalindrome(inputString ?? "");

if (isTruePalindrome)
{
    Console.WriteLine("YES");
}
else
{
    Console.WriteLine("NO");
}


public partial class Program
{
    static Regex onalyAlphabetChars = new Regex("[^a-zA-Z]");
}