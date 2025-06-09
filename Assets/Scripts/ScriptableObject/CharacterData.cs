using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Data/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public int level;
    public int exp;
    public int maxHP;
    public int attack;
    public int defense;
    public int criticalRate;
    public int gold;
}
