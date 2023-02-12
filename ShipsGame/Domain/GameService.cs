using ShipsGame.Interface;
using ShipsGame.Models;

namespace ShipsGame.Domain;

public class GameService
{
    private readonly MapGenerator _mapGenerator;
    protected List<ShipField> _mapFields;
    protected List<Ship> _ships;

    public GameService(List<ShipField> mapFields, List<Ship> ships, MapGenerator mapGenerator)
    {
        _mapGenerator = mapGenerator;
        _mapFields = mapFields;
        _ships = ships;
    }

    public void RunGame()
    {
        Console.WriteLine("Welcome to the warfare! To select a field to attack please type its coordinates like 'B4'.");
        
        do
        {
            MapPrinter.PrintMap(_mapFields);
            Console.WriteLine("Select the field to hit: ");
            var selectedField = Console.ReadLine();

            var validateionRes =CoordinatesParser.ValidateInput(selectedField);
            if (!validateionRes)
            {
                Console.WriteLine("Incorrect field coordinates! Try again with A-J and 1-10 coordinates. Press enter to continue.");
                Console.ReadLine();
                continue;
            }
            
            CoordinatesParser.GetFieldCoordinatesFromString(selectedField, out int row, out int line);

            bool hitted = false;
            foreach (var ship in _ships)
            { 
                hitted = ship.TryHitShip(row, line);
                if(hitted)
                {
                    _mapGenerator.UpdateWithShips();
                }
            }
            
            if(!hitted)
                _mapGenerator.SetFieldMissed(row, line);

            
        } while(_ships.Any(x=>x.ShipStatus == eShipStatus.Cool));
        
        Console.WriteLine("Big victory!");
        Console.ReadLine();
    }
}