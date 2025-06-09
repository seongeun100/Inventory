using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField]
    private Button mainMenuButton;

    [SerializeField]
    private Button statusButton;

    [SerializeField]
    private Button inventoryButton;

    void Start()
    {
        statusButton.onClick.AddListener(OnClickStatusButton);
        inventoryButton.onClick.AddListener(OnClickInventoryButton);
    }

    public void OnClickStatusButton()
    {
        UIManager.Instance.ChangeState(UIState.Status);
    }

    public void OnClickInventoryButton()
    {
        UIManager.Instance.ChangeState(UIState.Inventory);
    }
}
