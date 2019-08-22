using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour {
    
    private soundManager2 soundManager2;


    void Start()
    {
        soundManager2 = GameObject.FindObjectOfType<soundManager2>();
    }


    public void backMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void PauseMusic()
    {
        soundManager2.ToggleSound();
    }

    public void setVolume()
    {
        soundManager2.SetVolume();
    }
}
