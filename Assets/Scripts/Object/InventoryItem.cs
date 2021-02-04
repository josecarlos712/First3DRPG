using System;
using UnityEngine;
public class InventoryItem : MonoBehaviour
{
    public static int NextID = 0;
    public int IDObject = -1;
    private int ID = -1;

    public InventoryItem() {
        ID = NextID++;
    }
    private int getIDItem()
    {
        if (ID >= 0)
        return ID;
        else
        throw new NullReferenceException();
    }
}