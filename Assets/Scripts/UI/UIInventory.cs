using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inventorySlotNum;
    private int itemNum = 0;
    [SerializeField] private UISlot slotPrefab;
    [SerializeField] private Transform slotParent;
    [SerializeField] private List<UISlot> slots = new List<UISlot>();
    [SerializeField] private int slotCount = 21;

    [SerializeField] private Button inventoryButton;
    private void Start()
    {
        gameObject.SetActive(false);
        inventoryButton.onClick.AddListener(onClickInventoryButton);
        InitializeSlots();
    }

    private void InitializeSlots()
    {
        inventorySlotNum.text = $"Inventory\n[ {itemNum} / {slotCount} ]";
        for (int i = 0; i < slotCount; i++)
        {
            UISlot slot = Instantiate(slotPrefab, slotParent);
            slots.Add(slot);
        }
    }

    private void onClickInventoryButton()
    {
        UIManager.Instance.uiMainMenu.OpenInventory();
    }
}
