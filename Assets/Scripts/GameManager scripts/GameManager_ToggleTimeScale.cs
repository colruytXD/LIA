using UnityEngine;
using System.Collections;

public class GameManager_ToggleTimeScale : MonoBehaviour {

    private GameManager_Master gameManagerMaster;

	void OnEnable() 
	{
		SetInitialReferences();
        gameManagerMaster.EventTogglePause += ToggleTimeScale;
        Time.timeScale = 1;
	}

	void OnDisable() 
	{
        gameManagerMaster.EventTogglePause -= ToggleTimeScale;
    }

	void SetInitialReferences() 
	{
        gameManagerMaster = GetComponent<GameManager_Master>();
	}

    void ToggleTimeScale()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            print("1");
        }
        else
        {
            Time.timeScale = 0;
            print("0");
        }
    }
}
