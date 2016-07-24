using UnityEngine;
using System.Collections;

public class GameManager_TogglePause : MonoBehaviour {

    private GameManager_Master gameManagerMaster;

	void OnEnable() 
	{
		SetInitialReferences();
	}

	void OnDisable() 
	{

	}
	
	void Update () 
	{
        CheckForPauseRequest();
	}

	void SetInitialReferences() 
	{
        gameManagerMaster = GetComponent<GameManager_Master>();
	}

    void CheckForPauseRequest()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameManagerMaster.CallEventTogglePause();
        }
    }
}
