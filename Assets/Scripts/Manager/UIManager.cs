using System.Collections.Generic;
using UnityEngine;

public enum UIState
{
    MainMenu,
    Status,
    Inventory,
    None,
}

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField]
    private UIMainMenu uiMainMenu;

    [SerializeField]
    private UIStatus uiStatus;

    [SerializeField]
    private UIInventory uiInventory;

    [SerializeField]
    private UIPlayerInfo uiPlayerInfo;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        ChangeState(UIState.MainMenu);
    }

    public void ChangeState(UIState state)
    {
        uiMainMenu.gameObject.SetActive(state == UIState.MainMenu);
        uiStatus.gameObject.SetActive(state == UIState.Status);
        uiInventory.gameObject.SetActive(state == UIState.Inventory);
    }

    public void UpdateUI(Character player)
    {
        SetPlayerInfo(player);
        SetPlayerGold(player.Gold);
        SetExpBar(player.Exp, player.MaxExp);
        SetPlayerStatInfo(player);
        SetInventoryItems(player.Inventory, player.EquippedItems);
    }

    public void SetPlayerInfo(Character player)
    {
        uiPlayerInfo.SetPlayerInfo(player);
    }

    public void SetPlayerGold(int gold)
    {
        uiPlayerInfo.SetPlayerGold(gold);
    }

    public void SetExpBar(int current, int max)
    {
        uiPlayerInfo.SetExpBar(current, max);
    }

    public void SetPlayerStatInfo(Character player)
    {
        uiStatus.SetPlayerStatInfo(player);
    }

    public void SetInventoryItems(List<Item> items, Dictionary<ItemType, Item> equipped)
    {
        uiInventory.SetInventoryItems(items, equipped);
    }
}
