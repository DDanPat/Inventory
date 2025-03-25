using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private GameObject uiStatus;
    [SerializeField] private Button statusButton;
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

        gameObject.SetActive(false);

        statusButton.onClick.AddListener(onClickStatusButton);
    }

    private void onClickStatusButton()
    {
        UIManager.Instance.uiMainMenu.OpenStatus();
    }

    public void UpdateStatusUI()
    {
        if (GameManager.Instance.PlayerCharacter == null) return;

        healthText.text = GameManager.Instance.PlayerCharacter.Health.ToString();
        attackText.text = GameManager.Instance.PlayerCharacter.Attack.ToString();
        defenseText.text = GameManager.Instance.PlayerCharacter.Defense.ToString();
        criticalText.text = GameManager.Instance.PlayerCharacter.Critical.ToString() + "%";
    }
}
