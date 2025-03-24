using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private GameObject uiStatus;
    
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI defenseText;
    [SerializeField] private TextMeshProUGUI criticalText;

    private void Start()
    {
        if (GameManager.Instance.PlayerCharacter == null)
        {
            Debug.LogError("Character가 GameManager에서 찾을 수 없습니다.");
        }
        UpdateStatusUI();
    }

    public void UpdateStatusUI()
    {
        if (GameManager.Instance.PlayerCharacter == null) return;

        healthText.text = GameManager.Instance.PlayerCharacter.Health.ToString();
        attackText.text = GameManager.Instance.PlayerCharacter.Attack.ToString();
        defenseText.text = GameManager.Instance.PlayerCharacter.Defense.ToString();
        criticalText.text = GameManager.Instance.PlayerCharacter.Critical.ToString() + "%";
    }

    public void SetStatus(int health, int attack, int defense, int critical)
    {
        healthText.text = "체력: " + health.ToString();
        attackText.text = "공격력: " + attack.ToString();
        defenseText.text = "방어력: " + defense.ToString();
        criticalText.text = "치명타: " + critical.ToString() + "%";
    }
}
