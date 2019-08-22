using UnityEngine;
using System.Collections;

public class AcceleratorTest : MonoBehaviour
{

    // Sample test to run the accelerator.
    private void Start()
    {
        //As said before, when the function onShake activates, the action triggers
        Accelerometer.Instance.OnShake += ActionToRunWhenShakingDevice;
    }

    private void OnDestroy()
    {
        //When it fades, the action stops
        Accelerometer.Instance.OnShake -= ActionToRunWhenShakingDevice;
    }

    private void ActionToRunWhenShakingDevice()
    {
        //This should make you go back to the main menu. Not a big test, but it's the one I came up.
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
