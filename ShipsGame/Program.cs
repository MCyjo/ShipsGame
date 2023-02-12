using ShipsGame.Domain;
using ShipsGame.Models;

List<ShipField> _mapFields = new();
List<Ship> _ships = new();

var cpuGenerator = new CpuMapGenerator(_mapFields, _ships);
cpuGenerator.BuildMap();

var gameService = new GameService(_mapFields, _ships, cpuGenerator);
gameService.RunGame();

