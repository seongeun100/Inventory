using TMPro;
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
        statusButton.onClick.AddListener(OpenStatus);
        inventoryButton.onClick.AddListener(OpenInventory);
    }

    public void OpenStatus()
    {
        UIManager.Instance.ChangeState(UIState.Status);
    }

    public void OpenInventory()
    {
        UIManager.Instance.ChangeState(UIState.Inventory);
    }
}
