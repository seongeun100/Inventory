using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerInfo : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameText;

    [SerializeField]
    private TextMeshProUGUI levelText;

    [SerializeField]
    private TextMeshProUGUI goldText;

    [SerializeField]
    private Slider expSlider;

    [SerializeField]
    private TextMeshProUGUI expText;

    public void SetPlayerInfo(Character character)
    {
        nameText.text = $"{character.Name}";
        levelText.text = $"Lv {character.Level}";
    }

    public void SetPlayerGold(int gold)
    {
        goldText.text = gold.ToString("N0");
    }

    public void SetExpBar(float current, float max)
    {
        expSlider.value = current / max;
        expText.text = $"{current} / {max}";
    }
}
