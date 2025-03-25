using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISlot : MonoBehaviour
{
    public Button uiSlotButton;
    public TextMeshProUGUI equipText;
    public Image icon;
    
    private Item _item;
    public Item Item
    {
        get => _item;
        set
        {
            _item = value;
            UpdateSlotUI();
        }
    }

    private void UpdateSlotUI()
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
