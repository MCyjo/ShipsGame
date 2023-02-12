namespace ShipsGame.Models;

public class ShipField
{
    public ShipField(int row, int line)
    {
        Row = row;
        Line = line;
    }
    
    public int Row { get; }
    public int Line{ get; }
    public eFieldStatus FieldStatus { get; set; } = eFieldStatus.o;
}