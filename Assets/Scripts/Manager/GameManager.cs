using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private Sprite swordIcon;

    [SerializeField]
    private Sprite shieldIcon;

    [SerializeField]
    private Sprite arrowIcon;

    public Character Player { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SetData();
    }

    public void SetData()
    {
        Player = new Character("Chad", 10, 9, 100, 35, 20, 15, 1234567);

        var swordStats = new Dictionary<StatType, int>
        {
            { StatType.Attack, 10 },
            { StatType.CriticalRate, 5 },
        };
        var shieldStats = new Dictionary<StatType, int>
        {
            { StatType.Defense, 15 },
            { StatType.MaxHP, 50 },
        };
        var arrowStats = new Dictionary<StatType, int> { { StatType.Attack, 7 } };

        Item sword = new Item("Sword", ItemType.Weapon, swordIcon, swordStats);
        Item shield = new Item("Shield", ItemType.Armor, shieldIcon, shieldStats);
        Item arrow = new Item("Arrow", ItemType.Weapon, arrowIcon, arrowStats);

        Player.AddItem(sword);
        Player.AddItem(shield);
        Player.AddItem(arrow);

        UIManager.Instance.UIMainMenu.SetPlayerInfo(Player);
        UIManager.Instance.UIStatus.SetPlayerStatInfo(Player);
        UIManager.Instance.UIInventory.SetInventoryItems(Player.Inventory, Player.EquippedItems);
        UIManager.Instance.UIMainMenu.SetPlayerGold(Player.Gold);
    }

    public void EquipItem(Item item)
    {
        Player.Equip(item, item.type);
        UIManager.Instance.UIStatus.SetPlayerStatInfo(Player);
    }

    public void UnEquipItem(ItemType type)
    {
        Player.UnEquip(type);
        UIManager.Instance.UIStatus.SetPlayerStatInfo(Player);
    }

    public void SetPlayerGold(int gold)
    {
        UIManager.Instance.UIMainMenu.SetPlayerGold(Player.Gold);
    }
}
