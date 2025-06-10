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
        backButton.onClick.AddListener(OnClickBackButton); // 뒤로 가기 버튼 클릭 시 처리
    }

    public void OnClickBackButton()
    {
        UIManager.Instance.ChangeState(UIState.MainMenu);
    }

    // 플레이어 스텟 표시
    public void SetPlayerStatInfo(Character character)
    {
        attackText.text = $"Attack\n{character.GetTotalStat(StatType.Attack)}";
        defenseText.text = $"Defense\n{character.GetTotalStat(StatType.Defense)}";
        healthText.text = $"HP\n{character.GetTotalStat(StatType.MaxHP)}";
        criticalText.text = $"Critical\n{character.GetTotalStat(StatType.CriticalRate)}%";
    }
}
