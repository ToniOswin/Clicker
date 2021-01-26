using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    [SerializeField]
    int[,] damageShop = new int[,] { { 50, 2 }, { 200, 10 }, { 500, 20 } };
    [SerializeField]
    Button damageButton;
    [SerializeField]
    TextMeshProUGUI damageText;


    [SerializeField]
    int[,] healthShop = new int[,] { { 50, 5 }, { 200, 10 }, { 500, 20 } };
    [SerializeField]
    Button healthButton;
    [SerializeField]
    TextMeshProUGUI healthText;

    public static int damageIdx = 0;
    public static int healthIdx = 0;
    public static bool damageAvailable = true;
    public static bool healthAvailable = true;

    [SerializeField]
    TextMeshProUGUI moneyText;
    // Start is called before the first frame update
    void Start()
    {
        CheckDamageButton();
        CheckHealthButton();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = PlayerStats.money.ToString() + " Coins";
    }

   public void UpgradeDamage()
    {
        PlayerStats.Damage += damageShop[damageIdx, 1];
        PlayerStats.money -= damageShop[damageIdx, 0];
        if (damageIdx < (damageShop.Length/2) -1)
        {
            damageIdx++;
            damageText.text = damageShop[damageIdx, 0].ToString();
            CheckDamageButton();
            CheckDamageButton();
        }
        else if (damageIdx == (damageShop.Length / 2) - 1)
        {
            damageText.text = "Sold Out";
            damageButton.interactable = false;
            damageAvailable = false;
        }
        
    }
    public void upgradeLife()
    {
        PlayerStats.health += healthShop[healthIdx, 1];
        PlayerStats.money -= healthShop[healthIdx, 0];
        if (healthIdx < (damageShop.Length / 2) - 1)
        {
            healthIdx++;
            healthText.text = healthShop[healthIdx, 0].ToString();
            CheckHealthButton();
            CheckDamageButton();
        }
        else if (healthIdx == (damageShop.Length / 2) - 1)
        {
            healthText.text = "Sold Out";
            healthButton.interactable = false;
            healthAvailable = false;
        }
        
    }

    void CheckDamageButton()
    {
        if(damageAvailable)
        {
            damageText.text = damageShop[damageIdx, 0].ToString();
            if (damageShop[damageIdx, 0] <= PlayerStats.money)
            {
                damageButton.interactable = true;  
            }
            else
            {
                damageButton.interactable = false;
            }
        }
        else
        {
            damageText.text = "Sold Out";
            damageButton.interactable = false;
        }
    }
    void CheckHealthButton()
    {
        if(healthAvailable)
        {
            healthText.text = healthShop[healthIdx, 0].ToString();
            if (healthShop[healthIdx, 0] <= PlayerStats.money)
            {
                healthButton.interactable = true; 
            }
            else
            {
                healthButton.interactable = false;
            }
        }
        else
        {
            healthText.text = "Sold Out";
            healthButton.interactable = false;
        }
    }

    public void BackToBattle() { SceneManager.LoadScene("Battle"); GameManager.enemyIdx = 0; }
}
