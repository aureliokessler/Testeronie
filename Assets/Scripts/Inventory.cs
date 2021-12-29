using System.Collections.Generic;

public enum InventoryType
{
    Key,
    BigKey,
}

public static class Inventory
{
    public static List<InventoryType> Element = new List<InventoryType>();
}