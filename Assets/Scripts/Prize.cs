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
        SceneManager.LoadScene("Menu");
    }
}
