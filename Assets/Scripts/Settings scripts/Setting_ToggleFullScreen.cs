using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Setting_ToggleFullScreen : MonoBehaviour {

    public bool isFullscreen ;
    private Toggle myTgl;

    void OnEnable()
    {
        SetInitialReferences();
        isFullscreen = Screen.fullScreen;
        myTgl.isOn = isFullscreen;
    }

    void SetInitialReferences()
    {
        myTgl = gameObject.GetComponent<Toggle>();
    }

    public void ToggleFullScreen()
    {
        isFullscreen = !isFullscreen;

        if(isFullscreen) // if the application is fullscreen
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true); // gets resolution and sets app to fullscreen
        }
        else
        {
            Screen.SetResolution(1024, 720, false); // makes the game windowed on res( 1024, 720)
        }
    }
}
