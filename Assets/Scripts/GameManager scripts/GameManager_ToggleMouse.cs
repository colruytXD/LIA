using UnityEngine;
using System.Collections;

public class GameManager_ToggleMouse : MonoBehaviour {

    private GameManager_Master gameManagerMaster;

	void OnEnable() 
	{
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
		SetInitialReferences();
        gameManagerMaster.EventTogglePause += ToggleMouse;
	}

	void OnDisable() 
	{
        gameManagerMaster.EventTogglePause -= ToggleMouse;
    }

	void SetInitialReferences() 
	{
        gameManagerMaster = GetComponent<GameManager_Master>();
	}

    void ToggleMouse()
    {
        if(!gameManagerMaster.isPaused)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
