using System.Collections.Generic;
using UnityEngine;

// UI 상태 정의 열거형
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

    // 각 UI들 참조
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

    // UI 상태 전환 함수
    public void ChangeState(UIState state)
    {
        uiMainMenu.gameObject.SetActive(state == UIState.MainMenu);
        uiStatus.gameObject.SetActive(state == UIState.Status);
        uiInventory.gameObject.SetActive(state == UIState.Inventory);
    }

    // 플레이어 정보 받아서 UI 업데이트
    public void UpdateUI(Character player)
    {
        SetPlayerInfo(player);
        SetPlayerGold(player.Gold);
        SetExpBar(player.Exp, player.MaxExp);
        SetPlayerStatInfo(player);
        SetInventoryItems(player.Inventory, player.EquippedItems);
    }

    // 플레이어 기본 정보 설정(이름, 레벨 등)
    public void SetPlayerInfo(Character player)
    {
        uiPlayerInfo.SetPlayerInfo(player);
    }

    // 플레이어 골드 설정
    public void SetPlayerGold(int gold)
    {
        uiPlayerInfo.SetPlayerGold(gold);
    }

    // 경험치 바 설정
    public void SetExpBar(int current, int max)
    {
        uiPlayerInfo.SetExpBar(current, max);
    }

    // 능력치 정보 설정
    public void SetPlayerStatInfo(Character player)
    {
        uiStatus.SetPlayerStatInfo(player);
    }

    // 인벤토리, 장비 아이템 설정
    public void SetInventoryItems(List<Item> items, Dictionary<ItemType, Item> equipped)
    {
        uiInventory.SetInventoryItems(items, equipped);
    }
}
