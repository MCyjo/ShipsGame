using ShipsGame.Models;

namespace ShipsGame.Domain;

public class CpuMapGenerator : MapGenerator
{
    public CpuMapGenerator(List<ShipField> mapFields, List<Ship> ships)
    {
        _mapFields = mapFields;
        _ships = ships;
    }
    
    public override void BuildMap()
    {
        GenerateFields();

        _ships.Add(new BattleShip(_ships.SelectMany(x => x._fields))); 
        _ships.Add(new Destroyer(_ships.SelectMany(x=>x._fields))); 
        _ships.Add(new Destroyer(_ships.SelectMany(x=>x._fields)));

        UpdateWithShips();
    }
}