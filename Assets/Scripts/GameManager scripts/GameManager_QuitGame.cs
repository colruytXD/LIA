using UnityEngine;
using System.Collections;

public class GameManager_QuitGame : MonoBehaviour {

    private GameManager_Master gameManagerMasterScript;

    void OnEnable() 
	{
		SetInitialReferences();
        gameManagerMasterScript.EventQuit += Quit;
	}

	void OnDisable() 
	{
        gameManagerMasterScript.EventQuit -= Quit;
    }

	void SetInitialReferences() 
	{
        gameManagerMasterScript = GetComponent<GameManager_Master>();
	}

    void Quit()
    {
        Application.Quit();
    }
}
