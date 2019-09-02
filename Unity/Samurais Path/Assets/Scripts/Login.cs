using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using GooglePlayGames.BasicApi;
using GooglePlayGames;
using System.Collections;

// Mainmenu events.
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {
    private Text signInButtonText;
    private Text authStatus;

    void Start()
    {

        GameObject startButton = GameObject.Find("Start");
        EventSystem.current.firstSelectedGameObject = startButton;

        // ADD Play Game Services init code here.
        PlayGamesClientConfiguration config = new
            PlayGamesClientConfiguration.Builder()
            .Build();

        // Enable debugging output (recommended)
        PlayGamesPlatform.DebugLogEnabled = true;

        // Initialize and activate the platform
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        // Get object instances
        signInButtonText = GameObject.Find("SignIn").GetComponentInChildren<Text>();
        authStatus = GameObject.Find("authStatus").GetComponent<Text>();

        PlayGamesPlatform.Instance.Authenticate(SignInCallback, true);
    }

    public void Play()
    {
        Debug.Log("Playing!!");
        SceneManager.LoadScene("Menu");

    }

    public void SignIn()
    {
        if (!PlayGamesPlatform.Instance.IsAuthenticated())
        {
            // Sign in with Play Game Services, showing the consent dialog
            // by setting the second parameter to isSilent=false.
            PlayGamesPlatform.Instance.Authenticate(SignInCallback, false);
        }
        else
        {
            // Sign out of play games
            PlayGamesPlatform.Instance.SignOut();

            // Reset UI
            signInButtonText.text = "Sign In";
            authStatus.text = "";
        }
    }

    public void SignInCallback(bool success)
    {
        if (success)
        {
            Debug.Log("Signed in!");

            // Change sign-in button text
            signInButtonText.text = "Sign out";

            // Show the user's name
            authStatus.text = "Signed in as: " + Social.localUser.userName;
        }
        else
        {
            Debug.Log("Sign-in failed...");

            // Show failure message
            signInButtonText.text = "Sign in";
            authStatus.text = "Sign-in failed";
        }
    }
}
