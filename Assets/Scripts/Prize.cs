using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prize : MonoBehaviour
{
    public void GetPrize()
    {
        Application.OpenURL("https://tinyurl.com/2fcpre6");
    }
    public void BackToMenu()
    {
        
        PlayerStats.money = 0;
        PlayerStats.Damage = 1;
        PlayerStats.health = 10;

        GameManager.enemyIdx = 0;

        Shop.damageIdx = 0;
        Shop.healthIdx = 0;
        Shop.damageAvailable = true;
        Shop.healthAvailable = true;

        SceneManager.LoadScene("Menu");
    }
}
