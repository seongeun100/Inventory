using System.Collections.Generic;

public class Character
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int Exp { get; private set; }
    public int MaxExp { get; private set; }
    public int Gold { get; private set; }
    public List<Item> Inventory { get; private set; }

    // 장착된 아이템 목록
    private Dictionary<ItemType, Item> equippedItems = new Dictionary<ItemType, Item>();
    public Dictionary<ItemType, Item> EquippedItems => equippedItems;

    // 캐릭터 기본 능력치
    private Dictionary<StatType, int> baseStats;

    // CharacterData를 바탕으로 초기화
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

    // 인벤토리에 아이템 추가
    public void AddItem(Item item)
    {
        Inventory.Add(item);
    }

    // 아이템 장착
    public void Equip(Item item, ItemType type)
    {
        if (!Inventory.Contains(item))
            return;
        equippedItems[type] = item;
    }

    // 아이템해제
    public void UnEquip(ItemType type)
    {
        if (!equippedItems.ContainsKey(type))
            return;
        equippedItems.Remove(type);
    }

    // 특정 타입의 장착 아이템 반환
    public Item GetEquippedItem(ItemType type)
    {
        equippedItems.TryGetValue(type, out var item);
        return item;
    }

    // 특정 능력치 계산
    public int GetTotalStat(StatType statType)
    {
        baseStats.TryGetValue(statType, out int total);

        foreach (var item in equippedItems.Values)
            total += item?.GetBonusStat(statType) ?? 0;

        return total;
    }
}
