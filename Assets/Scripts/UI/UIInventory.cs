using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField]
    private UISlot slotPrefab;

    [SerializeField]
    private Transform slotsParent;

    private List<UISlot> slotList = new List<UISlot>(); // 슬롯 리스트

    private int slotCount = 20; // 인벤토리 최대 슬롯 수

    [SerializeField]
    private Button backButton; // 뒤로 가기 버튼

    [SerializeField]
    private TextMeshProUGUI itemCountText; // 아이템 개수 표시 텍스트

    void Start()
    {
        backButton.onClick.AddListener(OnClickBackButton); // 뒤로 가기 버튼 클릭 시 처리
    }

    // 인벤토리 슬롯 UI 초기화
    private void InitInventoryUI()
    {
        for (int i = 0; i < slotCount; i++)
        {
            UISlot newSlot = Instantiate(slotPrefab, slotsParent);
            newSlot.SetItem(null);
            slotList.Add(newSlot);
        }
    }

    // 인벤토리 및 장착 아이템 설정
    public void SetInventoryItems(List<Item> items, Dictionary<ItemType, Item> equippedItems)
    {
        if (slotList.Count == 0)
            InitInventoryUI();

        for (int i = 0; i < slotList.Count; i++)
        {
            if (i < items.Count)
            {
                var item = items[i];
                bool isEquipped =
                    equippedItems.TryGetValue(item.Type, out var equippedItem)
                    && equippedItem == item;
                slotList[i].SetItem(items[i], isEquipped);
            }
            else
                slotList[i].SetItem(null, false);
        }
        UpdateItemCount(items.Count, slotCount);
    }

    // 아이템 개수 표시
    public void UpdateItemCount(int currentCount, int maxCount)
    {
        if (itemCountText != null)
        {
            itemCountText.text =
                $"Inventory  <color=#FFA65F>{currentCount}</color>  <color=#00000080>/ {maxCount}</color> ";
        }
    }

    // 뒤로 가기 버튼 클릭 시 메인으로
    public void OnClickBackButton()
    {
        UIManager.Instance.ChangeState(UIState.MainMenu);
    }
}
