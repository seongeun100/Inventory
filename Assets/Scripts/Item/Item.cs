using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string Name { get; private set; }
    public ItemType Type { get; private set; }
    public Sprite Icon { get; private set; }
    private Dictionary<StatType, int> bonusStats;

    public Item(ItemData data)
    {
        Name = data.itemName;
        Type = data.itemType;
        Icon = data.icon;
        bonusStats = new Dictionary<StatType, int>();
        foreach (var statBonus in data.statBonuses)
        {
            bonusStats[statBonus.statType] = statBonus.value;
        }
    }

    public int GetBonusStat(StatType statType)
    {
        return bonusStats.TryGetValue(statType, out var val) ? val : 0;
    }
}
