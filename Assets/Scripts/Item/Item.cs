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

public class Item
{
    public string Name { get; private set; }
    public ItemType type { get; private set; }
    public Sprite Icon { get; private set; }
    private Dictionary<StatType, int> bonusStats = new Dictionary<StatType, int>();

    public Item(string name, ItemType type, Sprite icon, Dictionary<StatType, int> bonusStats)
    {
        Name = name;
        this.type = type;
        Icon = icon;
        this.bonusStats = bonusStats;
    }

    public int GetBonusStat(StatType statType)
    {
        if (bonusStats.TryGetValue(statType, out int value))
            return value;
        return 0;
    }
}
