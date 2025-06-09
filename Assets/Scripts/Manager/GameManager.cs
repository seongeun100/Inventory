using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private ItemData[] itemDatas;
    private CharacterData characterData;

    public Character Player { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        itemDatas = Resources.LoadAll<ItemData>("ItemData");
        characterData = Resources.Load<CharacterData>("CharacterData/Chad");
    }

    private void Start()
    {
        SetData();
    }

    private void AddInventoryItems()
    {
        foreach (var data in itemDatas)
        {
            Item item = new Item(data);
            Player.AddItem(item);
        }
    }

    public void SetData()
    {
        Player = new Character(characterData);

        AddInventoryItems();

        UIManager.Instance.UIPlayerInfo.SetPlayerInfo(Player);
        UIManager.Instance.UIPlayerInfo.SetPlayerGold(Player.Gold);
        UIManager.Instance.UIPlayerInfo.SetExpBar(Player.Exp, Player.MaxExp);
        UIManager.Instance.UIStatus.SetPlayerStatInfo(Player);
        UIManager.Instance.UIInventory.SetInventoryItems(Player.Inventory, Player.EquippedItems);
    }

    public void EquipItem(Item item)
    {
        Player.Equip(item, item.Type);
        UIManager.Instance.UIStatus.SetPlayerStatInfo(Player);
    }

    public void UnEquipItem(ItemType type)
    {
        Player.UnEquip(type);
        UIManager.Instance.UIStatus.SetPlayerStatInfo(Player);
    }

    public void SetPlayerGold(int gold)
    {
        UIManager.Instance.UIPlayerInfo.SetPlayerGold(Player.Gold);
    }
}
