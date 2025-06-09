using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int Exp { get; private set; }
    public int BaseAttack { get; private set; }
    public int BaseDefense { get; private set; }
    public int BaseMaxHP { get; private set; }
    public int BaseCriticalRate { get; private set; }
    public int Gold { get; private set; }
    public List<Item> Inventory { get; private set; }
    private Item equippedItem;

    private Dictionary<ItemType, Item> equippedItems = new Dictionary<ItemType, Item>();
    public Dictionary<ItemType, Item> EquippedItems => equippedItems;

    public Character(
        string name,
        int level,
        int exp,
        int maxHP,
        int attack,
        int defense,
        int critical,
        int gold
    )
    {
        Name = name;
        Level = level;
        Exp = exp;
        BaseAttack = attack;
        BaseDefense = defense;
        BaseMaxHP = maxHP;
        BaseCriticalRate = critical;
        Gold = gold;
        Inventory = new List<Item>();
    }

    public void AddItem(Item item)
    {
        Inventory.Add(item);
    }

    public void Equip(Item item, ItemType type)
    {
        if (Inventory.Contains(item))
            equippedItems[type] = item;
        Debug.Log($"장착: {item.Name} ({type})");
    }

    public void UnEquip(ItemType type)
    {
        if (equippedItems.ContainsKey(type))
            equippedItems.Remove(type);
    }

    public Item GetEquippedItem(ItemType type)
    {
        equippedItems.TryGetValue(type, out var item);
        return item;
    }

    public int GetTotalStat(StatType statType)
    {
        int total = 0;

        switch (statType)
        {
            case StatType.Attack:
                total = BaseAttack;
                break;
            case StatType.Defense:
                total = BaseDefense;
                break;
            case StatType.MaxHP:
                total = BaseMaxHP;
                break;
            case StatType.CriticalRate:
                total = BaseCriticalRate;
                break;
        }

        foreach (var item in equippedItems.Values)
        {
            if (item != null)
                total += item.GetBonusStat(statType);
        }

        return total;
    }
}
