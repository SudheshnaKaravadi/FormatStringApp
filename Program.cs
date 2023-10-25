// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

/*
In the programming language of your choice, write a program that parses a sentence and replaces each word with the following:
    first letter, number of distinct characters between first and last character, and last letter. 
    For example, Smooth would become S3h. Words are separated by spaces or non-alphabetic characters 
    and these separators should be maintained in their original form and location in the answer. 
    A few of the things we will be looking at is accuracy, efficiency, solution completeness.

*/

Console.WriteLine("Enter a string for formatting");
string inputStr = Console.ReadLine();

if (string.IsNullOrWhiteSpace(inputStr))
{
    Console.WriteLine("Please enter a valid string to format");
}
else
{
    try
    {
        /*
        // if string has only white spaces then below code works
        var outputStr = inputStr.Split(' ').Select(s =>
        {
            return $"{s.Substring(0, 1)}" +
                                 $"{removeDuplicate(s.Substring(1, s.Length - 2))}" +
                                  $"{s.Substring(s.Length - 1)} ";
        }).ToList();
        return string.Join(" ", outputStr);
        */

        var charArray = inputStr.ToCharArray();

        StringBuilder sb = new StringBuilder();

        List<char> word = new List<char>();
        foreach (char c in charArray)
        {
            if (char.IsLetter(c))
            {
                word.Add(c);
            }
            else
            {
                //now format the word
                sb.Append(FormatWord(new string(word.ToArray())));
                sb.Append(c);
                word = new List<char>();
            }
        }
        sb.Append(FormatWord(new string(word.ToArray())));

        Console.WriteLine(sb.ToString());
        Console.WriteLine("Click any key to exit...");
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    Console.Read();
}
static string FormatWord(string word)
{
    if (word.Length < 3)
        return word;
    var charArray = word.ToArray();
    return $"{charArray[0]}{word.Substring(1, word.Length - 2).Distinct().Count()}{charArray[charArray.Length - 1]}";
}

static int removeDuplicate(string inputString)
{
    return inputString.ToLower().ToCharArray().Distinct().Count();
}


