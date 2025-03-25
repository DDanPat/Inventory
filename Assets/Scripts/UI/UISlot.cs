using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum SlotType
{
    Inventory,
    Shop
}

public class UISlot : MonoBehaviour
{
    public Button uiSlotButton;
    public TextMeshProUGUI equipText;
    public Image icon;
    public int indexNum;
    public SlotType slotType;

    [SerializeField]private Item _item;
    public Item Item
    {
        get => _item;
        set
        {
            _item = value;
            UpdateSlotUI();
        }
    }

    private void Awake()
    {
        // 버튼에 클릭 이벤트 추가
        if (uiSlotButton != null)
        {
            uiSlotButton.onClick.AddListener(OnSlotButtonClick);
        }
    }

    private void OnSlotButtonClick()
    {
        // UIManager의 팝업 오브젝트 활성화
        if (UIManager.Instance.popupObjcet != null && _item != null)
        {
            UIManager.Instance.popupObjcet.SetActive(true);
            
            // 아이템 정보를 팝업에 전달 (아이템이 있는 경우)
            if (_item != null && UIManager.Instance.uiPopup != null)
            {
                // 필요한 경우 팝업에 아이템 정보 설정
                if (slotType == SlotType.Inventory)
                    UIManager.Instance.uiPopup.SetItemInfo(_item, slotType);
                else if (slotType == SlotType.Shop)
                    UIManager.Instance.uiPopup.SetShopInfo(_item, slotType);
            }
        }
    }

    public void UpdateSlotUI()
    {
        if (_item != null)
        {
            // 아이콘 업데이트
            icon.sprite = _item.icon;
            icon.enabled = true;

            // 장착 텍스트 업데이트
            equipText.enabled = _item.isEquip;
            equipText.text = "E";
        }
        else
        {
            // 아이템이 없을 경우 UI 초기화
            icon.sprite = null;
            icon.enabled = false;
            equipText.enabled = false;
        }
    }

    
}
