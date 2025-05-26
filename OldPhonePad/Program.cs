using OldPhonePad.Services;

Console.WriteLine("Enter input:");
string? input = Console.ReadLine();

if (!string.IsNullOrWhiteSpace(input))
{
    string result = OldPhonePadConverter.Convert(input);
    Console.WriteLine($"Output: {result}");
}
else
{
    Console.WriteLine("No input provided.");
}
