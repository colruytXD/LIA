using UnityEngine;
using System.Collections;

public class GameManager_Master : MonoBehaviour {

    public delegate void GeneralEventHandler();

    public event GeneralEventHandler EventGoToMainMenu;
    public event GeneralEventHandler EventGoToSettingsMenu;
    public event GeneralEventHandler EventGoToVideoSettingsMenu;
    public event GeneralEventHandler EventGoToControlsMenu;
    public event GeneralEventHandler EventQuit;
    public event GeneralEventHandler EventGoToMainGameScene;
    public event GeneralEventHandler EventPlayerDie;

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

    public void CallEventGoToVideoSettingsMenu()
    {
        if (EventGoToVideoSettingsMenu != null)
        {
            EventGoToVideoSettingsMenu();
        }
    }

    public void CallEventGoToControlsMenu() 
    {
        if (EventGoToControlsMenu != null)
        {
            EventGoToControlsMenu();
        }
    }

    public void CallEventQuit()
    {
        if(EventQuit != null)
        {
            EventQuit();
        }
    }

    public void CallEventGoToMainGameScene()
    {
        if(EventGoToMainGameScene != null)
        {
            EventGoToMainGameScene();
        }
    }

    public void CallEventPlayerDie()
    {
        if(EventPlayerDie != null)
        {
            EventPlayerDie();
        }
    }
}
