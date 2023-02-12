namespace ShipsGame.Models;

public class BattleShip : Ship
{
    public BattleShip(IEnumerable<ShipField> lockedFields) : base(lockedFields)
    {
    }

    protected override int _length => 5;
}