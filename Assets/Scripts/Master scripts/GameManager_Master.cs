using UnityEngine;
using System.Collections;

public class GameManager_Master : MonoBehaviour {

    public delegate void GeneralEventHandler();

    public event GeneralEventHandler EventGoToMainMenu;
    public event GeneralEventHandler EventGoToSettingsMenu;
    public event GeneralEventHandler EventGoToVideoSettings;
    public event GeneralEventHandler EventGoToControls;

    public void CallEventGoToMainMenu()
    {
        if(EventGoToMainMenu != null)
        {
            EventGoToMainMenu();
        }
    }

    public void CallEventGoToSettingsMenu()
    {
        if (EventGoToSettingsMenu != null)
        {
            EventGoToSettingsMenu();
        }
    }

    public void CallEventGoToVideoSettings()
    {
        if (EventGoToVideoSettings != null)
        {
            EventGoToVideoSettings();
        }
    }

    public void CallEventGoToSettings() 
    {
        if (EventGoToControls != null)
        {
            EventGoToControls();
        }
    }
}
