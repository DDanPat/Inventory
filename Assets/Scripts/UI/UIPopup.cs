using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIPopup : MonoBehaviour
{
    [SerializeField] private Button applyButton;
    [SerializeField] private Button cancelButton;
    [SerializeField] private TextMeshProUGUI popupText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;

    private Item currentItem;
    private SlotType selectSlotType;

    private void Start()
    {
        UIManager.Instance.popupObjcet.SetActive(false);
        cancelButton.onClick.AddListener(CancelButtonSet);
        applyButton.onClick.AddListener(applyButtonSet);
    }

    private void applyButtonSet()
    {
        bool apply = false;
        switch (selectSlotType)
        {
            case SlotType.Inventory:
                apply = InventorySet();
                break;
            case SlotType.Shop:
                apply = ShopSet();
                break;
        }
        if (apply) UIManager.Instance.popupObjcet.SetActive(false);
        else return;
    }

    private bool InventorySet()
    {
        if (currentItem != null)
        {
            switch (currentItem.type)
            {
                case ItemType.Potion:
                    PotionSet();
                    break;
                case ItemType.Weapon:
                case ItemType.Armor:
                case ItemType.Shield:
                    EquipmentSet();
                    break;
            }
            return true;
        }
        else return false;
    }
    private bool ShopSet()
    {
        if (currentItem.gold <= GameManager.Instance.PlayerCharacter.Gold)
        {
            Item newItem = Instantiate(currentItem);
            GameManager.Instance.PlayerCharacter.AddItem(newItem);
            UIManager.Instance.uiInventory.UpdateInventoryUI();
            GameManager.Instance.PlayerCharacter.Gold -= currentItem.gold;
            UIManager.Instance.uiMainMenu.GoldUpdate();
            return true;
        }
        else
        {
            popupText.text = "골드가 부족합니다.";
            return false;
        }
    }

    private void PotionSet()
    {
        GameManager.Instance.PlayerCharacter.UseConsumables(currentItem);
    }

    private void EquipmentSet()
    {
        if (currentItem != null && currentItem.isEquip == false)
        {
            // 같은 타입의 장착된 아이템 찾기
            Item equippedItem = GameManager.Instance.PlayerCharacter.Inventory.Find(item => 
                item.isEquip && item.type == currentItem.type);

            // 같은 타입의 아이템이 이미 장착되어 있다면 해제
            if (equippedItem != null)
            {
                GameManager.Instance.PlayerCharacter.UnEuip(equippedItem);
                Debug.Log($"{equippedItem.displayName} 아이템 해제");
            }

            // 새로운 아이템 장착
            GameManager.Instance.PlayerCharacter.Equip(currentItem);
            Debug.Log($"{currentItem.displayName} 아이템 적용");
        }
        else if(currentItem != null && currentItem.isEquip == true)
        {
            // 아이템 장착 해제 로직
            GameManager.Instance.PlayerCharacter.UnEuip(currentItem);
            Debug.Log($"{currentItem.displayName} 아이템 해제");
        }
        UIManager.Instance.uiInventory.UpdateInventoryUI();
    }


    private void CancelButtonSet()
    {
        UIManager.Instance.popupObjcet.SetActive(false);
    }

    public void SetItemInfo(Item item, SlotType slotType)
    {
        selectSlotType = slotType;
        currentItem = item;
        string itemStat = item.isEquip? "해제" : "장착";
        popupText.text = $"{item.displayName}을[를] {itemStat}하시겠습니까?";
        itemDescriptionText.text = item.description; 
    }
    public void SetShopInfo(Item item, SlotType slotType)
    {
        selectSlotType = slotType;
        currentItem = item;
        popupText.text = $"{item.displayName}을[를] 구매하시겠습니까?";
        itemDescriptionText.text = $"{item.description}\n{item.gold}G"; 
    }
}
