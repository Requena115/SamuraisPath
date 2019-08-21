using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour {

    public Slider Volume;
    public AudioSource music;


    public void backMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
     public void ChangeVolume()
    {
        music.volume = Volume.value;
    }
}
