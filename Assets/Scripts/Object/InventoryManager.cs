using System;
using System.Collections.Generic;
using Assets.Scripts;

public static class InventoryManager
{
    /*
	 * InventoryManager administra contiene todos los metodos y clases necesarias para administrar el inventario del jugador.
	 * */

    public static InventoryItem getInventoryItem(int itemID) //Devuelve una referencia al inventoryItem con dicho ID
    {
        Dictionary<int, InventoryItem> inventoryItems = Configuration.getInventoryItems();
        if (inventoryItems.ContainsKey(itemID))
        {
            InventoryItem item;
            if (inventoryItems.TryGetValue(itemID, out item))
                return item;
            else
                throw new NullReferenceException("The InventoryItem with ID " + itemID + " coudldn´t be recovered");
        }
        else
            throw new NullReferenceException("The InventoryItem with ID " + itemID + " doesn´t exist");
    }

}