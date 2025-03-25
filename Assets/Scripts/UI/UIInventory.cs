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

    private List<Item> itemList = new List<Item>(); // 아이템 리스트 추가

    public List<Item> ItemList => itemList; // 아이템 리스트 프로퍼티

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
        itemNum = itemList.Count;
        inventorySlotNum.text = $"Inventory\n[ {itemNum} / {slotCount} ]";
    }

    private void onClickInventoryButton()
    {
        UIManager.Instance.uiMainMenu.OpenInventory();
    }

    // 아이템 추가 메서드
    public bool AddItem(Item item)
    {
        if (itemList.Count >= slotCount)
            return false;

        itemList.Add(item);
        UpdateInventoryUI();
        return true;
    }

    // 아이템 제거 메서드
    public bool RemoveItem(Item item)
    {
        bool result = itemList.Remove(item);
        if (result)
            UpdateInventoryUI();
        return result;
    }

    // 인벤토리 UI 업데이트 메서드
    public void UpdateInventoryUI()
    {
        // 모든 슬롯 초기화
        for (int i = 0; i < slots.Count; i++)
        {
            if (i < itemList.Count)
                slots[i].UpdateSlot(itemList[i]);
            else
                slots[i].ClearSlot();
        }

        itemNum = itemList.Count;
        inventorySlotNum.text = $"Inventory\n[ {itemNum} / {slotCount} ]";
    }
}
