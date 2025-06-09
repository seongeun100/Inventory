using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI attackText;

    [SerializeField]
    private TextMeshProUGUI defenseText;

    [SerializeField]
    private TextMeshProUGUI healthText;

    [SerializeField]
    private TextMeshProUGUI criticalText;

    [SerializeField]
    private Button backButton;

    void Start()
    {
        backButton.onClick.AddListener(OnBackButtonClick);
    }

    public void OnBackButtonClick()
    {
        UIManager.Instance.ChangeState(UIState.MainMenu);
    }

    public void SetPlayerStatInfo(Character character)
    {
        attackText.text = $"Attack\n{character.GetTotalStat(StatType.Attack)}";
        defenseText.text = $"Defense\n{character.GetTotalStat(StatType.Defense)}";
        healthText.text = $"HP\n{character.GetTotalStat(StatType.MaxHP)}";
        criticalText.text = $"Critical\n{character.GetTotalStat(StatType.CriticalRate)}%";
    }
}
