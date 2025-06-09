using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum UIState
{
    MainMenu,
    Status,
    Inventory,
    None,
}

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField]
    private UIMainMenu uiMainMenu;

    [SerializeField]
    private UIStatus uiStatus;

    [SerializeField]
    private UIInventory uiInventory;

    public UIMainMenu UIMainMenu => uiMainMenu;
    public UIStatus UIStatus => uiStatus;
    public UIInventory UIInventory => uiInventory;
    private UIState currentState;

    // public UIState CurrentState => currentState;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        ChangeState(UIState.MainMenu);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;

        uiMainMenu.gameObject.SetActive(state == UIState.MainMenu);
        uiStatus.gameObject.SetActive(state == UIState.Status);
        uiInventory.gameObject.SetActive(state == UIState.Inventory);
    }
}
