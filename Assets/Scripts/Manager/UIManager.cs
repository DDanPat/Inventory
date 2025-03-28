using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("UIManager");
                    instance = go.AddComponent<UIManager>();
                }
            }
            return instance;
        }
    }

    [SerializeField] public GameObject mainMenuPanel;
    [SerializeField] public GameObject statusPanel;
    [SerializeField] public GameObject inventoryPanel;
    [SerializeField] public GameObject popupObjcet;
    [SerializeField] public GameObject shopPanel;

    public UIInventory uiInventory;
    public UIMainMenu uiMainMenu;
    public UIStatus uiStatus;
    public UIPopup uiPopup;
    public UIShop uiShop;
    public UIMedal uiMedal;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        uiMainMenu = mainMenuPanel.GetComponent<UIMainMenu>();
        uiPopup = popupObjcet.GetComponent<UIPopup>();
        uiInventory = inventoryPanel.GetComponent<UIInventory>();
        uiStatus = statusPanel.GetComponent<UIStatus>();
        uiShop = shopPanel.GetComponent<UIShop>();
        uiMedal = mainMenuPanel.GetComponent<UIMedal>();
    }

    private void Start()
    {
        if (mainMenuPanel == null || statusPanel == null || inventoryPanel == null)
        {
            Debug.LogError("UI 패널들이 UIManager에 연결되지 않았습니다.");
        }
    }
}
