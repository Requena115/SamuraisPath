using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundManager2 : MonoBehaviour
{
    public static soundManager2 Instance { set; get; }

    public AudioSource music;

    static soundManager2 instance = null;
    //playSound soundManager
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    public void ToggleSound()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
            AudioListener.volume = 0;

            //Actualizar sprite en Unity.
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
            AudioListener.volume = 1;
        }
        
    }

    public void SetVolume()
    {
        music.volume = GameObject.Find("VolumeSlider").GetComponent<Slider>().value ;
    }

    
   
}
