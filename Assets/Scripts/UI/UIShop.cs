using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIShop : MonoBehaviour
{
    private int itemNum = 0;
    [SerializeField] private UISlot slotPrefab;
    [SerializeField] private Transform slotParent;
    [SerializeField] private List<UISlot> slots = new List<UISlot>();
    [SerializeField] private List<Item> shopList = new List<Item>();
    [SerializeField] private int slotCount;

    [SerializeField] private Button shopButton;

    private void Start()
    {
        slotCount = 21;
        gameObject.SetActive(false);
        shopButton.onClick.AddListener(onClickshopButton);
        InitShopUI();
    }

    private void InitShopUI()
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
            slots[i].slotType = SlotType.Shop;
        }

        UpdateShopUI();
    }

    public void UpdateShopUI()
    {
        // 모든 슬롯 초기화
        foreach (var slot in slots)
        {
            slot.Item = null;
        }

        // Resources 폴더에서 모든 ItemData 로드
        Item[] itemDatas = Resources.LoadAll<Item>("ItemData");
        
        // shopList 초기화
        shopList.Clear();
        
        // 각 ItemData로부터 아이템 생성 및 shopList에 추가
        foreach (var itemData in itemDatas)
        {
            Item newItem = Instantiate(itemData);
            shopList.Add(newItem);
        }

        // shopList의 아이템들을 슬롯에 표시
        for (int i = 0; i < shopList.Count && i < slots.Count; i++)
        {
            slots[i].Item = shopList[i];
        }
    }

    private void onClickshopButton()
    {
        UIManager.Instance.uiMainMenu.OpenShop();
    }
}
