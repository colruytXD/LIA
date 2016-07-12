﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager_GoToMainMenu : MonoBehaviour {

    public GameObject pnlSettingsMenu;
    public GameObject pnlMainMenu;
    public GameObject pnlVideoSettingsMenu;
    public GameObject pnlControlsMenu;

    private GameManager_Master gameManagerMasterScript;

    void OnEnable() 
	{
		SetInitialReferences();
        gameManagerMasterScript.EventGoToMainMenu += GoToMainMenu;
	}

	void OnDisable() 
	{
        gameManagerMasterScript.EventGoToMainMenu -= GoToMainMenu;
    }

	void SetInitialReferences() 
	{
        gameManagerMasterScript = GetComponent<GameManager_Master>();
	}

    void GoToMainMenu()
    {
        SceneManager.LoadScene(0); //Loads sceneIndex 0 (Main Menu)
    }
}
