using Foraging_Kentucky.Pages;
using Microsoft.AspNetCore.Components;
using System.Text;

namespace Foraging_Kentucky.Common;

public static class Extensions
{
    public static string CapitalizeEachWord(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return input;
        }

        string[] words = input.ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < words.Length; i++)
        {
            if (!string.IsNullOrEmpty(words[i]))
            {
                char[] letters = words[i].ToCharArray();
                if (letters.Length > 0)
                {
                    letters[0] = char.ToUpper(letters[0]);
                    words[i] = new string(letters);
                }
            }
        }
        return string.Join(" ", words);
    }

    public static string[] MakeParagraphs(this string input) { return input.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None); }
    public static MarkupString MakeParagraphsFromString(this string input)
    {
        return new MarkupString($@"{input.Replace("\n", "<br>")}");
    }
}
