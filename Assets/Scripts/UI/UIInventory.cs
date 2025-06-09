using System.Collections;
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

    private List<UISlot> slotList = new List<UISlot>();

    private int slotCount = 20;

    [SerializeField]
    private Button backButton;

    [SerializeField]
    private TextMeshProUGUI itemCountText;

    void Start()
    {
        backButton.onClick.AddListener(OnBackButtonClick);
    }

    private void InitInventoryUI()
    {
        for (int i = 0; i < slotCount; i++)
        {
            UISlot newSlot = Instantiate(slotPrefab, slotsParent);
            newSlot.SetItem(null);
            slotList.Add(newSlot);
        }
    }

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

    public void UpdateItemCount(int currentCount, int maxCount)
    {
        if (itemCountText != null)
        {
            itemCountText.text = $"Inventory  <color=#FFA65F>{currentCount}</color>  <color=#00000080>/ {maxCount}</color> ";
        }
    }

    public void OnBackButtonClick()
    {
        UIManager.Instance.ChangeState(UIState.MainMenu);
    }
}
