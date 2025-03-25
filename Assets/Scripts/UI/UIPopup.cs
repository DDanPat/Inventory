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
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    [SerializeField] private Image itemIconImage;

    private Item currentItem;

    private void Start()
    {
        UIManager.Instance.popupObjcet.SetActive(false);
        cancelButton.onClick.AddListener(CancelButtonSet);
        applyButton.onClick.AddListener(applyButtonSet);
    }

    private void applyButtonSet()
    {
        if (currentItem != null && currentItem.isEquip == false)
        {
            // 아이템 장착 로직 구현
            GameManager.Instance.PlayerCharacter.Equip(currentItem);
            Debug.Log($"{currentItem.displayName} 아이템 적용");
        }
        else if(currentItem != null && currentItem.isEquip == true)
        {
            // 아이템 장착 로직 구현
            GameManager.Instance.PlayerCharacter.UnEuip(currentItem);
            Debug.Log($"{currentItem.displayName} 아이템 해제");
        }
        UIManager.Instance.popupObjcet.SetActive(false);
    }

    private void CancelButtonSet()
    {
        UIManager.Instance.popupObjcet.SetActive(false);
    }

    public void SetItemInfo(Item item)
    {
        currentItem = item;
        
        if (item != null)
        {
            // 아이템 정보 팝업에 표시
            if (itemNameText != null)
                itemNameText.text = item.displayName;
                
            if (itemDescriptionText != null)
                itemDescriptionText.text = item.description;
                
            if (itemIconImage != null)
            {
                itemIconImage.sprite = item.icon;
                itemIconImage.enabled = true;
            }
            
            // 아이템 타입에 따른 팝업 내용 설정
            string actionText = item.isEquip ? "장착 해제" : "장착";
            if (item.type == ItemType.Potion)
                actionText = "사용";
                
            // 팝업 텍스트 설정
            if (popupText != null)
                popupText.text = $"{item.displayName}을(를) {actionText}하시겠습니까?";
                
            // 적용 버튼 활성화
            if (applyButton != null)
                applyButton.gameObject.SetActive(true);
        }
        else
        {
            // 아이템이 없는 경우 기본 상태로 초기화
            if (itemNameText != null)
                itemNameText.text = "";
                
            if (itemDescriptionText != null)
                itemDescriptionText.text = "";
                
            if (itemIconImage != null)
                itemIconImage.enabled = false;
                
            if (popupText != null)
                popupText.text = "선택된 아이템이 없습니다.";
                
            // 적용 버튼 비활성화
            if (applyButton != null)
                applyButton.gameObject.SetActive(false);
        }
    }
}
