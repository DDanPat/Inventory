using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI level;

    private void Start()
    {
        backButton.onClick.AddListener(OpenMainMenu);
        backButton.gameObject.SetActive(false);

        name.text = GameManager.Instance.PlayerCharacter.name;
        GoldUpdate();
        LevelUpdate();
    }
    public void OpenMainMenu()
    {
        UIManager.Instance.statusPanel.SetActive(false);
        UIManager.Instance.inventoryPanel.SetActive(false);
        UIManager.Instance.popupObjcet.SetActive(false);
        UIManager.Instance.shopPanel.SetActive(false);
        backButton.gameObject.SetActive(false);
    }

    public void OpenStatus()
    {
        UIManager.Instance.statusPanel.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

    public void OpenInventory()
    {
        UIManager.Instance.inventoryPanel.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

    public void OpenShop()
    {
        UIManager.Instance.shopPanel.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

    public void GoldUpdate()
    {
        int gold = GameManager.Instance.PlayerCharacter.Gold;
        goldText.text = gold.ToString("N0");
    }
    public void LevelUpdate()
    {
        level.text = "Lv. " + GameManager.Instance.PlayerCharacter.level.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameManager.Instance.PlayerCharacter.Gold += 1101001000;
            GoldUpdate();
        }
    }
}
