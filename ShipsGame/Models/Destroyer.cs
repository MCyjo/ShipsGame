namespace ShipsGame.Models;

public class Destroyer : Ship
{
    public Destroyer(IEnumerable<ShipField> lockedFields) : base(lockedFields)
    {
    }
    
    protected override int _length => 4;
}