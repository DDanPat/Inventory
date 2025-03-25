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

    public void Equip(Item item)
    {
        item.isEquip = true;
        AddStatus(item);
        UIManager.Instance.uiInventory.UpdateInventoryUI();
    }

    public void UnEuip(Item item)
    {
        item.isEquip = false;
        RemoveStatus(item);
        UIManager.Instance.uiInventory.UpdateInventoryUI();
    }

    public void AddStatus(Item item)
    {
        if (item.type != ItemType.Potion)
        {
            for(int i = 0; i < item.weaponValue.Length; i++)
            {
                switch(item.weaponValue[i].statusType)
                {
                    case StatusType.Attack:
                        Attack += item.weaponValue[i].value;
                        break;
                    case StatusType.Defense:
                        Defense += item.weaponValue[i].value;
                        break;
                    case StatusType.Health:
                        Health += item.weaponValue[i].value;
                        break;
                }
            }
        }
        UIManager.Instance.uiStatus.UpdateStatusUI();
    }

    public void RemoveStatus(Item item)
    {
        if (item.type != ItemType.Potion)
        {
            for(int i = 0; i < item.weaponValue.Length; i++)
            {
                switch(item.weaponValue[i].statusType)
                {
                    case StatusType.Attack:
                        Attack -= item.weaponValue[i].value;
                        break;
                    case StatusType.Defense:
                        Defense -= item.weaponValue[i].value;
                        break;
                    case StatusType.Health:
                        Health -= item.weaponValue[i].value;
                        break;
                }
            }
        }
        UIManager.Instance.uiStatus.UpdateStatusUI();
    }
}
