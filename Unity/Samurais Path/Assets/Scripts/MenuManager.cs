using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void SelectGameHistoria()
    {
        SceneManager.LoadScene("HistoriaGame");
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
    public void SelectDefault()
    {
        SceneManager.LoadScene("Game");
    }
    public void SelectRojo()
    {
        SceneManager.LoadScene("GameRojo");
    }
    public void SelectVerde()
    {
        SceneManager.LoadScene("GameVerde");
    }
    public void resetScore()
    {
        PlayerPrefs.DeleteKey("Score");
        
    }
    public void resetHistoria()
    {
        PlayerPrefs.DeleteKey("MAX_LEVEL");
    }

    public void changeMusic(string song)
    {
        soundManager2.instance.ChangeMusic(song);
    }
}
