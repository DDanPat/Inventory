using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor,
    Shield,
    Potion
}

public enum StatusType
{
    Attack,
    Defense,
    Health,
}

[System.Serializable]
public class ItemDataConsumable
{
    public float value;
}
[System.Serializable]
public class ItemDataWeapon
{
    public StatusType statusType;
    public int value;
}

[CreateAssetMenu(fileName ="Item", menuName = "New Item")]
public class Item : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;

    public bool isEquip;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;

    [Header("Weapons")]
    public ItemDataWeapon[] weaponValue;
}
