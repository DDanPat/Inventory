using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    instance = go.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    private Player playerCharacter;
    public Player PlayerCharacter => playerCharacter;

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

        SetData();
    }

    public void SetData()
    {
        // 플레이어가 없다면 생성
        if (playerCharacter == null)
        {
            GameObject playerObj = new GameObject("Player");
            playerCharacter = playerObj.AddComponent<Player>();
        }

        // 기본 스탯 설정
        playerCharacter.name = "티라노";
        playerCharacter.level = 0;
        playerCharacter.Health = 100;
        playerCharacter.Attack = 10;
        playerCharacter.Defense = 5;
        playerCharacter.Critical = 5;
        playerCharacter.Gold = 1000;
        playerCharacter.medal = "코딩뉴비";

        // 인벤토리 초기화
        playerCharacter.Inventory.Clear();

        // 기본 아이템 설정
        BaseItemSet();

        // UI 업데이트
        UIManager.Instance.uiStatus.UpdateStatusUI();
    }

    private void BaseItemSet()
    {
        // 기본 무기 로드 및 추가
        Item sword = Resources.Load<Item>("ItemData/Sword");
        if (sword != null)
        {
            Item swordInstance = Instantiate(sword);
            playerCharacter.AddItem(swordInstance);
        }
        else
        {
            Debug.LogError("기본 검을 찾을 수 없습니다: ItemData/Sword");
        }

        // 기본 방어구 로드 및 추가
        Item armor = Resources.Load<Item>("ItemData/Helmet");
        if (armor != null)
        {
            Item armorInstance = Instantiate(armor);
            playerCharacter.AddItem(armorInstance);
        }
        else
        {
            Debug.LogError("기본 방어구를 찾을 수 없습니다: ItemData/Helmet");
        }

        // 기본 방패패 로드 및 추가
        Item shield = Resources.Load<Item>("ItemData/Shield");
        if (armor != null)
        {
            Item shieldInstance = Instantiate(shield);
            playerCharacter.AddItem(shieldInstance);
        }
        else
        {
            Debug.LogError("기본 방어구를 찾을 수 없습니다: ItemData/Helmet");
        }

        // 기본 포션 로드 및 추가
        Item potion = Resources.Load<Item>("ItemData/Potion");
        if (potion != null)
        {
            Item potionInstance = Instantiate(potion);
            playerCharacter.AddItem(potionInstance);
        }
        else
        {
            Debug.LogError("체력 포션을 찾을 수 없습니다: ItemData/Potion");
        }
    }

    private void Update()
    {
        // A키를 누르면 골드 10 감소
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerCharacter.Health -= 10;
            UIManager.Instance.uiStatus.UpdateStatusUI();
        }

        // S키를 누르면 골드 10000 증가
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerCharacter.Gold += 10000;
            UIManager.Instance.uiMainMenu.GoldUpdate();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            playerCharacter.LevelUP();
        }
    }
}
