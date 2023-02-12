using System.Text.RegularExpressions;

namespace ShipsGame.Interface;

public class CoordinatesParser
{
    public static void GetFieldCoordinatesFromString(string input, out int row, out int line)
    {
        var lineCh = input[0];
        line = lineCh % 32;

        var rowStr = input.Substring(1);
        row = int.Parse(rowStr);
    }

    public static bool ValidateInput(string input)
    {
        if(Regex.IsMatch(input, "^[A-Ja-j]([1-9]|1[10])$")) {
            var rowStr = input.Substring(1);
            int.TryParse(rowStr, out int row);
            
            if (row <= 10 && row > 0)
            {
                return true;
            }
        }

        return false;
    }
}