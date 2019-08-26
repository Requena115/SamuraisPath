using UnityEngine;
using UnityEngine.UI;

public class BloqueadorNiveles : MonoBehaviour {

    public int level;
    private Button button;
    
	void Start () {
        button = transform.GetComponent<Button>();
        int maxLvl = PlayerPrefs.GetInt("MAX_LEVEL");
        button.interactable = maxLvl >= level;
	}

}
