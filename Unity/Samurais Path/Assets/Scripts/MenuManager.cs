using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void PlayGame()
    {
        //soundManager2.Instance.PlaySound(0);
        SceneManager.LoadScene("Game");

    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
    public void SelectOption()
    {
        //soundManager2.Instance.PlaySound(0);
        SceneManager.LoadScene("Options");
    }

    public void SelectMode()
    {
        SceneManager.LoadScene("SelectMode");
    }

    public void SelectHistoria()
    {
        SceneManager.LoadScene("Historia");
    }

    public void SelectApariencia()
    {
        SceneManager.LoadScene("Apariencia");
    }
    public void SelectMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void SelectLeaderboard()
    {
        SceneManager.LoadScene("Ranking");
    }
}
