using UnityEngine;
using System.Collections;

public class GameManager_GoToSettingsMenu : MonoBehaviour {

    private GameManager_Master gameManagerMasterScript;

    public GameObject pnlSettingsMenu;
    public GameObject pnlMainMenu;
    public GameObject pnlVideoSettingsMenu;
    public GameObject pnlControlsMenu;

    void OnEnable() 
	{
		SetInitialReferences();
        gameManagerMasterScript.EventGoToSettingsMenu += GoToSettingsMenu;
	}

	void OnDisable() 
	{
        gameManagerMasterScript.EventGoToSettingsMenu -= GoToSettingsMenu;
    }

	void SetInitialReferences() 
	{
        gameManagerMasterScript = GetComponent<GameManager_Master>();
    }

    void GoToSettingsMenu()
    {
        pnlMainMenu.SetActive(false);
        pnlControlsMenu.SetActive(false);
        pnlVideoSettingsMenu.SetActive(false);
        pnlSettingsMenu.SetActive(true);
    }
}
