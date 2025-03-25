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

        // UI 업데이트
        if (UIManager.Instance != null)
        {
            // Status UI 업데이트
            UIStatus statusUI = UIManager.Instance.statusPanel.GetComponent<UIStatus>();
            if (statusUI != null)
            {
                statusUI.UpdateStatusUI();
            }

            
        }
    }
}
