using ShipsGame.Models;

namespace ShipsGame.Domain;

public abstract class MapGenerator
{
    protected List<ShipField> _mapFields;
    protected List<Ship> _ships;

    public abstract void BuildMap();
    
    protected void GenerateFields()
    {
        for (var i = 1; i <= 10; i++)
        {
            GenerateFieldsForRow(i);
        }
    }

    private void GenerateFieldsForRow(int i)
    {
        for (int j = 1; j <= 10; j++)
        {
            _mapFields.Add(new ShipField(i, j));
        }
    }

    public void SetFieldMissed(int row, int line)
    {
        _mapFields.First(x => x.Line == line && x.Row == row).FieldStatus = eFieldStatus.M;
    }
    
    public void UpdateWithShips()
    {
        foreach (var shipField in _ships.SelectMany(x=>x._fields))
        {
            _mapFields.First(x => x.Line == shipField.Line && x.Row == shipField.Row).FieldStatus =
                shipField.FieldStatus;
        }
    }
}