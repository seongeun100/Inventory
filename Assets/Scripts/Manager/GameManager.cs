using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // 아이템 데이터와 캐릭터 데이터
    private ItemData[] itemDatas;
    private CharacterData characterData;

    public Character Player { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        itemDatas = Resources.LoadAll<ItemData>("ItemData");
        characterData = Resources.Load<CharacterData>("CharacterData/Chad");
    }

    private void Start()
    {
        SetData(); // 게임 시작 시 데이터 설정
    }

    // 아이템 데이터에 있는 아이템을 인벤토리에 추가
    private void AddInventoryItems()
    {
        foreach (var data in itemDatas)
        {
            Item item = new Item(data);
            Player.AddItem(item);
        }
    }

    // 플레이어 데이터 생성 및 UI 초기화
    public void SetData()
    {
        Player = new Character(characterData);

        AddInventoryItems();
        UIManager.Instance.UpdateUI(Player);
    }

    // 아이템 장착
    public void EquipItem(Item item)
    {
        Player.Equip(item, item.Type);
        UIManager.Instance.SetPlayerStatInfo(Player);
    }

    // 아이템 해제
    public void UnEquipItem(ItemType type)
    {
        Player.UnEquip(type);
        UIManager.Instance.SetPlayerStatInfo(Player);
    }

    // 골드 UI 설정
    public void SetPlayerGold(int gold)
    {
        UIManager.Instance.SetPlayerGold(Player.Gold);
    }
}
