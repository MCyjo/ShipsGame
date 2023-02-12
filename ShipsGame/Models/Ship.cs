namespace ShipsGame.Models;

public abstract class Ship
{
    public eShipStatus _shipStatus { get; private set; } = eShipStatus.Cool;
    
    public readonly List<ShipField> _fields;


    protected Ship(IEnumerable<ShipField> lockedFields)
    {
        _fields = CreateShip(lockedFields.ToList());
    }
    
    protected abstract int _length { get; }

    public bool TryHitShip(int row, int line)
    {
        var fieldToHit = _fields.FirstOrDefault(x => x.Row == row && x.Line == line);
        if (fieldToHit != null)
        {
            fieldToHit.FieldStatus = eFieldStatus.D;
            if (_fields.All(x => x.FieldStatus == eFieldStatus.D))
                _shipStatus = eShipStatus.Destroyed;

            return true;
        }

        return false;
    }
    
    private List<ShipField> CreateShip(List<ShipField> lockedFields)
    {
        var randomGen = new Random();
        eMapAlligment mapAligment = (eMapAlligment)randomGen.Next(0, 1);
        
        while (true)
        {
            GenerateRandomInitField(randomGen, mapAligment, out var row, out var line);

            List<ShipField> requiredFields = GetRequiredFields(mapAligment, row, line, lockedFields);
            
            if(requiredFields.Count == _length)
                return requiredFields;
        }
    }
    
    private void GenerateRandomInitField(Random randomGen, eMapAlligment mapAlligment, out int row, out int line)
    {
        switch (mapAlligment)
        {
            case eMapAlligment.Horizontal:
                row = randomGen.Next(1, 10);
                line = randomGen.Next(1, (10 - _length));
                break;
            case eMapAlligment.Vertical:
                row = randomGen.Next(1, (10 - _length));
                line = randomGen.Next(1, 10);
                break;
            default:
                throw new Exception($"Couldn't handle {nameof(eMapAlligment)} for type {mapAlligment.ToString()}");
        }
    }

    private List<ShipField> GetRequiredFields(eMapAlligment mapAlligment, int row, int line, List<ShipField> lockedFields)
    {
        List<ShipField> requiredFields = new List<ShipField>();
        switch (mapAlligment)
        {
            case eMapAlligment.Horizontal:
                for (int i = line; i < (line + _length); i++)
                {
                    if(lockedFields.Any(x=> x.Row == row && x.Line == i))
                        break;
                    
                    ShipField newField = new ShipField(row, i);
                    requiredFields.Add(newField);
                }
                
                break;
            case eMapAlligment.Vertical:
                for (int i = row; i < (row + _length); i++)
                {
                    if(lockedFields.Any(x=> x.Row == i && x.Line == line))
                        break;

                    ShipField newField = new ShipField(i, line);
                    requiredFields.Add(newField);
                }

                break;
            default:
                throw new Exception($"Couldn't handle {nameof(eMapAlligment)} for type {mapAlligment.ToString()}");
        }
        
        return requiredFields;
    }
}

public enum eMapAlligment
{
    Vertical,
    Horizontal
}

public enum eFieldStatus
{
    o,  //Cool
    M,  //Missed
    D,  //Damaged
}

public enum eShipStatus
{
    Cool,
    Destroyed
}