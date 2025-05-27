# Old Phone Pad Converter

This is a C# console application that simulates typing text using an old mobile phone keypad.

All logic is encapsulated in `OldPhonePadConverter.cs`
Input is processed sequentially, with buffer handling for repeated digits
Backspace (`*`) finalizes and removes last valid character
The end character (`#`) stops input processing
Invalid characters are caught and result in user-friendly exceptions
Unit tests in `OldPhonePad.Tests` validate correctness across common and edge cases
See `README.md` and test file for usage examples and test coverage

## Problem Description

Each number key (2–9) on a classic mobile phone maps to a set of letters. Pressing a key multiple times cycles through those letters:

`2` → A B C  
`3` → D E F  
`4` → G H I  
`5` → J K L  
`6` → M N O  
`7` → P Q R S  
`8` → T U V  
`9` → W X Y Z  
`0` → Space

### Controls:

`*` → Backspace (removes last confirmed character)  
`#` → End of input  
`' '` (space) → Pause (confirms current character even if same key is reused)

## How to Run

Open terminal in the project directory and run:

dotnet run --project OldPhonePad

This project includes unit tests written using xUnit.

To run the tests:

dotnet test


