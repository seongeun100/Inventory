using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor,
}

public enum StatType
{
    Attack,
    Defense,
    MaxHP,
    CriticalRate,
}

[Serializable]
public class StatBonus
{
    public StatType statType;
    public int value;
}

[CreateAssetMenu(fileName = "Item", menuName = "Data/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public Sprite icon;
    public StatBonus[] statBonuses;
}
