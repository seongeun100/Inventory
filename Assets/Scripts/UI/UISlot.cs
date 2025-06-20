using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField]
    private Image iconImage;

    [SerializeField]
    private GameObject equippedIcon;

    [SerializeField]
    private Button slotButton;

    private Item item;

    void Start()
    {
        slotButton.onClick.AddListener(OnClickSlot); // 슬롯 클릭시 처리
    }

    public void SetItem(Item item, bool isEquipped = false)
    {
        this.item = item;

        if (item != null)
        {
            iconImage.sprite = item.Icon;
            iconImage.enabled = true;
        }
        else
        {
            iconImage.sprite = null;
            iconImage.enabled = false;
        }
        equippedIcon.SetActive(isEquipped);
    }

    // 슬롯 클릭 시 장착,해제
    public void OnClickSlot()
    {
        if (item == null)
            return;

        Item equippedItem = GameManager.Instance.Player.GetEquippedItem(item.Type);

        if (equippedItem == item)
            GameManager.Instance.UnEquipItem(item.Type);
        else
            GameManager.Instance.EquipItem(item);

        UIManager.Instance.SetInventoryItems(
            GameManager.Instance.Player.Inventory,
            GameManager.Instance.Player.EquippedItems
        );
    }
}
