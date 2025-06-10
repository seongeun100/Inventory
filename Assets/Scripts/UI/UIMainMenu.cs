using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField]
    private Button statusButton; // 상태창 버튼

    [SerializeField]
    private Button inventoryButton; // 인벤토리 버튼

    void Start()
    {
        // 버튼 클릭 시 해당 UI 상태로 전환
        statusButton.onClick.AddListener(OnClickStatusButton);
        inventoryButton.onClick.AddListener(OnClickInventoryButton);
    }

    // 상태창으로 전환
    public void OnClickStatusButton()
    {
        UIManager.Instance.ChangeState(UIState.Status);
    }

    // 인벤토리창으로 전환
    public void OnClickInventoryButton()
    {
        UIManager.Instance.ChangeState(UIState.Inventory);
    }
}
