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
    public void OptionGame()
    {
        //soundManager2.Instance.PlaySound(0);
        SceneManager.LoadScene("Options");
    }
}
