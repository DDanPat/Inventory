using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMedal : MonoBehaviour
{
    [SerializeField] private Button openMedalButton;
    [SerializeField] private Button closeMedalButton;
    [SerializeField] private GameObject medalSelectPanel;
    public Image medalIcon;



    private void Start()
    {
        openMedalButton.onClick.AddListener(OpenMedalSelectPanel);
        closeMedalButton.onClick.AddListener(CloseMedalSelectPanel);
        medalSelectPanel.SetActive(false);
    }

    private void OpenMedalSelectPanel()
    {
        medalSelectPanel.SetActive(true);
        closeMedalButton.gameObject.SetActive(true);
    }

    public void CloseMedalSelectPanel()
    {
        medalSelectPanel.SetActive(false);
        closeMedalButton.gameObject.SetActive(false);
    }

}
