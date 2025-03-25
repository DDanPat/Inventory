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
    [SerializeField] private int slotCount;

    [SerializeField] private Button inventoryButton;


    private void Start()
    {
        gameObject.SetActive(false);
        inventoryButton.onClick.AddListener(onClickInventoryButton);
        InitInventoryUI();
    }

    private void InitInventoryUI()
    {
        // 기존 슬롯들 제거
        foreach (var slot in slots)
        {
            if (slot != null)
                Destroy(slot.gameObject);
        }
        slots.Clear();

        // 새로운 슬롯 생성
        for (int i = 0; i < slotCount; i++)
        {
            UISlot slot = Instantiate(slotPrefab, slotParent);
            slots.Add(slot);
        }

        // 아이템 개수 업데이트
        //itemNum = itemList.Count;
        inventorySlotNum.text = $"Inventory\n[ {itemNum} / {slotCount} ]";
    }

    private void onClickInventoryButton()
    {
        UIManager.Instance.uiMainMenu.OpenInventory();
    }

    
}
