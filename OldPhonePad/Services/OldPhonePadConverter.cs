using System.Text;

namespace OldPhonePad.Services;

public static class OldPhonePadConverter
{
    private static readonly Dictionary<char, string> KeyMap = new()
    {
        { '1', "&'(" },
        { '2', "ABC" },
        { '3', "DEF" },
        { '4', "GHI" },
        { '5', "JKL" },
        { '6', "MNO" },
        { '7', "PQRS" },
        { '8', "TUV" },
        { '9', "WXYZ" },
        { '0', " " }
    };

    public static string Convert(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return "";

        var output = new List<char>();
        var current = new StringBuilder();

        foreach (char c in input)
        {
            if (c == '#') break;

            if (c == '*')
            {
                AddCurrentToOutput(current, output);
                current.Clear();

                if (output.Count > 0)
                    output.RemoveAt(output.Count - 1);

                continue;
            }

            if (c == ' ')
            {
                AddCurrentToOutput(current, output);
                current.Clear();
                continue;
            }

            if (current.Length > 0 && current[0] != c)
            {
                AddCurrentToOutput(current, output);
                current.Clear();
            }

            current.Append(c);
        }

        AddCurrentToOutput(current, output);
        return new string(output.ToArray());
    }

    private static void AddCurrentToOutput(StringBuilder current, List<char> output)
    {
        if (current.Length == 0) return;

        char digit = current[0];
        if (!KeyMap.TryGetValue(digit, out var letters))
            return;

        int index = (current.Length - 1) % letters.Length;
        output.Add(letters[index]);
    }
}
