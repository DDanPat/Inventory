using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectMedal : MonoBehaviour
{
    [SerializeField] private Button medalButton;
    [SerializeField] private TextMeshProUGUI medalText;
    [SerializeField] private Image icon;


    private void Start()
    {
        medalButton.onClick.AddListener(ChangedMedal);
    }

    private void ChangedMedal()
    {
        GameManager.Instance.PlayerCharacter.medal = medalText.text;
        UIManager.Instance.uiMainMenu.MedalUpdate();
        UIManager.Instance.uiMedal.CloseMedalSelectPanel();
        UIManager.Instance.uiMedal.medalIcon.sprite = icon.sprite;
    }
}
