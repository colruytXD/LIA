using UnityEngine;
using System.Collections;

public class GameManager_DisplayDeathScreen : MonoBehaviour {

    private GameManager_Master gameManagerMaster;
    [SerializeField]
    private GameObject DeathScreenUI;

    void OnEnable() 
	{
		SetInitialReferences();
        gameManagerMaster.EventPlayerDie += DisplayDeathScreen;
	}

	void OnDisable() 
	{
        gameManagerMaster.EventPlayerDie -= DisplayDeathScreen;
    }

	void SetInitialReferences() 
	{
        gameManagerMaster = GetComponent<GameManager_Master>();
	}

    void DisplayDeathScreen()
    {
        DeathScreenUI.SetActive(true);
    }
}
