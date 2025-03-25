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
        slotCount = GameManager.Instance.PlayerCharacter.MaxInventorySize;
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
            slots[i].indexNum = i;
            slots[i].slotType = SlotType.Inventory;
        }

        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        // 모든 슬롯 초기화
        foreach (var slot in slots)
        {
            slot.Item = null;
        }

        // 플레이어의 인벤토리 아이템 표시
        var playerItems = GameManager.Instance.PlayerCharacter.Inventory;
        itemNum = playerItems.Count;

        for (int i = 0; i < playerItems.Count && i < slots.Count; i++)
        {
            slots[i].Item = playerItems[i];
            slots[i].UpdateSlotUI();
        }

        // 인벤토리 슬롯 개수 텍스트 업데이트
        inventorySlotNum.text = $"Inventory\n[ {itemNum} / {slotCount} ]";

    }

    private void onClickInventoryButton()
    {
        UIManager.Instance.uiMainMenu.OpenInventory();
    }
}
