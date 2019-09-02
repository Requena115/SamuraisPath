using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames.BasicApi;
using GooglePlayGames;

public class Rankings : MonoBehaviour {
    private GameObject ldrButton;
    private Login login;
    // Use this for initialization
    void Start () {
        ldrButton = GameObject.Find("ldrButton");

        PlayGamesPlatform.Instance.Authenticate(login.SignInCallback, true);
	}
	
	// Update is called once per frame
	void Update () {
        ldrButton.SetActive(Social.localUser.authenticated);
	}

    public void ShowLeaderBoards() {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
        else {
            Debug.Log("User not authenticated");
        }
    }
}
