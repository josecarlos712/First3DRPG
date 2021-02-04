using System;
using UnityEngine;
using Assets.Scripts;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    private static int NextIDInventory = -1;
    private int IDInventory = -1;
    private Dictionary<int, int> inventory;

    public Inventory()
    {
        this.IDInventory = Inventory.NextIDInventory++;
    }
    private void Start()
    {
        this.inventory = new Dictionary<int, int>();
    }

    public void putItem(int IDItem, int sum) //A la funcion se le pasa el ID del InventoryItem y la cantidad a añadir
    {
    /// <sumary>The function adds @sum of @IDItem into the inventory</sumary>
    /// <param name="IDItem">ID of the item it will be added</param>
    /// <param name="sum">Cuantity of the item it will be added</param>
        if (inventory.ContainsKey(IDItem))
            inventory[IDItem] += sum;
        else
            inventory.Add(IDItem, sum);
    }

    /// <sumary>
    /// A la funcion se le pasa el ID del InventoryItem y la cantidad a borrar
    /// </sumary>
    public void deleteItem(int IDItem, int sum) //A la funcion se le pasa el ID del InventoryItem y la cantidad a borrar
    {
        if (inventory.ContainsKey(IDItem))
            inventory[IDItem] -= sum < inventory[IDItem] ? sum : inventory[IDItem];
        else
            Debug.Log("Tried to delete item #"+ IDItem + " but doesn´t exist.");
    }
    public Dictionary<int, int> getInventory()
    {
        return new Dictionary<int, int>(inventory);
    }
    public int getSumInventoryItem(int itemID)
    {
        if (inventory.ContainsKey(itemID))
        {
            int sum;
            if (inventory.TryGetValue(itemID, out sum))
                return sum;
            else
                throw new NullReferenceException();
        }
        else
        {
            return 0;
        }
    }
    public static bool compareTo(Inventory in1, Inventory in2)
    {
        return in1.getHashCode() == in2.getHashCode();
    }
    private int getIDInventory()
    {
        return IDInventory;
    }
    public String getHashCode()
    {
        return "InventoryID-" + IDInventory.ToString();
    }
}