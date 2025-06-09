using System.Collections.Generic;

public class Character
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int Exp { get; private set; }
    public int MaxExp { get; private set; }
    public int Gold { get; private set; }
    public List<Item> Inventory { get; private set; }

    private Dictionary<ItemType, Item> equippedItems = new Dictionary<ItemType, Item>();
    public Dictionary<ItemType, Item> EquippedItems => equippedItems;
    private Dictionary<StatType, int> baseStats;

    public Character(CharacterData data)
    {
        Name = data.characterName;
        Level = data.level;
        Exp = data.exp;
        MaxExp = data.MaxExp;
        Gold = data.gold;
        Inventory = new List<Item>();

        baseStats = new Dictionary<StatType, int>
        {
            { StatType.Attack, data.attack },
            { StatType.Defense, data.defense },
            { StatType.MaxHP, data.maxHP },
            { StatType.CriticalRate, data.criticalRate },
        };
    }

    public void AddItem(Item item)
    {
        Inventory.Add(item);
    }

    public void Equip(Item item, ItemType type)
    {
        if (!Inventory.Contains(item))
            return;
        equippedItems[type] = item;
    }

    public void UnEquip(ItemType type)
    {
        if (!equippedItems.ContainsKey(type))
            return;
        equippedItems.Remove(type);
    }

    public Item GetEquippedItem(ItemType type)
    {
        equippedItems.TryGetValue(type, out var item);
        return item;
    }

    public int GetTotalStat(StatType statType)
    {
        baseStats.TryGetValue(statType, out int total);

        foreach (var item in equippedItems.Values)
            total += item?.GetBonusStat(statType) ?? 0;

        return total;
    }
}
