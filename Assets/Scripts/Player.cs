using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public string name;
    public int level;
    
    [SerializeField] private List<Item> inventory = new List<Item>();
    public List<Item> Inventory => inventory;
    
    [SerializeField] private int maxInventorySize = 21;
    public int MaxInventorySize => maxInventorySize;
    public int CurItemCount => inventory.Count;
    public bool IsInventoryFull => CurItemCount >= maxInventorySize;

    public bool AddItem(Item item)
    {
        if (item != null && !IsInventoryFull)
        {
            inventory.Add(item);
            return true;
        }
        return false;
    }

    public bool RemoveItem(Item item)
    {
        if (item != null && inventory.Contains(item))
        {
            inventory.Remove(item);
            return true;
        }
        return false;
    }

    public void Equip(int slotNum)
    {
        inventory[slotNum].isEquip = true;
    }

    public void UnEuip(int slotNum)
    {
        inventory[slotNum].isEquip = false;
    }
}
