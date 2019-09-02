using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpController : MonoBehaviour {

    private Image powerUpIndicator;

	void Start () {
        powerUpIndicator = gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.Instance.isPowerUpActive) {
            powerUpIndicator.color = Color.white;
        } else
        {
            powerUpIndicator.color = Color.gray;
        }
	}

    internal void Activate()
    {
        if (GameManager.Instance.isPowerUpActive) {

            Enemy[] enemies = FindObjectsOfType<Enemy>();

            foreach (Enemy e in enemies) {
                e.Slice();
            }

            GameManager.Instance.isPowerUpActive = false;
        }
    }
}
