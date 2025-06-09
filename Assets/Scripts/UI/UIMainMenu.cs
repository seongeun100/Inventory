using System.Collections;
using System.Collections.Generic;
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

    [SerializeField]
    private TextMeshProUGUI nameText;

    [SerializeField]
    private TextMeshProUGUI levelText;
    [SerializeField]
    private TextMeshProUGUI goldText;

    void Start()
    {
        // mainMenuButton.onClick.AddListener(OpenMainMenu);
        statusButton.onClick.AddListener(OpenStatus);
        inventoryButton.onClick.AddListener(OpenInventory);
    }

    public void OpenMainMenu()
    {
        UIManager.Instance.ChangeState(UIState.MainMenu);
    }

    public void OpenStatus()
    {
        UIManager.Instance.ChangeState(UIState.Status);
    }

    public void OpenInventory()
    {
        UIManager.Instance.ChangeState(UIState.Inventory);
    }

    public void SetPlayerInfo(Character character)
    {
        nameText.text = $"{character.Name}";
        levelText.text = $"Lv {character.Level}";
    }

    public void SetPlayerGold(int gold)
    {
        goldText.text = gold.ToString("N0");
    }
}
