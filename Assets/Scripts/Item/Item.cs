using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string Name { get; private set; }
    public ItemType Type { get; private set; }
    public Sprite Icon { get; private set; }

    // 아이템 추가 스텟
    private Dictionary<StatType, int> bonusStats;

    // IteamData를 바탕으로 초기화
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

    // 특정 추가 스텟 반환
    public int GetBonusStat(StatType statType)
    {
        return bonusStats.TryGetValue(statType, out var val) ? val : 0;
    }
}
