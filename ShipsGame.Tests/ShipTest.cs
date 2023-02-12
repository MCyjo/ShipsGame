using ShipsGame.Models;

namespace ShipsGame.Tests;

public class ShipTest
{
    [Fact]
    public void TryHitShip_WhenShipHasOneFieldLeft_ShipShouldBeDestroyed()
    {
        var ship = CreateShipToTest();

        ship.TryHitShip(1, 4);
        
        Assert.Equal(eShipStatus.Destroyed, ship._shipStatus);
    }

    private static Destroyer CreateShipToTest()
    {
        var shipFields = new List<ShipField>()
        {
            new ShipField(1, 1),
            new ShipField(1, 2),
            new ShipField(1, 3),
            new ShipField(1, 4)
        };

        foreach (var s in shipFields.Take(3))
        {
            s.FieldStatus = eFieldStatus.D;
        }

        return new Destroyer(shipFields);;
    }
}