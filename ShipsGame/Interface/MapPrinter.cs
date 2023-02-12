using System.Text;
using ShipsGame.Models;

namespace ShipsGame.Interface;

public static class MapPrinter
{
    public static void PrintMap(List<ShipField> mapFields)
    {
        Console.Clear();
        Console.WriteLine("   A  B  C  D  E  F  G  H  I  J");
        
        for (var i = 1; i <= 10; i++)
        {
            PrintMapRow(i, mapFields);
        }
    }

    private static void PrintMapRow(int i, List<ShipField> mapFields)
    {
        var rowNumberStr = $"{i} ";
        rowNumberStr = rowNumberStr.PadRight(3, ' ');
        StringBuilder _stringBuilder = new(rowNumberStr);

        var shipsForRow = mapFields.Where(x => x.Row == i).OrderBy(x => x.Line);
        
        foreach (var shipField in shipsForRow)
        {
            _stringBuilder.Append(shipField.FieldStatus.ToString());
            _stringBuilder.Append("  ");
        }
        
        Console.WriteLine(_stringBuilder);
    }
}