using UnityEngine;
using System.Collections;

public class GameManager_TogglePauseMenu : MonoBehaviour {

    private GameManager_Master gameManagerMaster;
    [SerializeField]
    private GameObject pauseMenu;

	void OnEnable() 
	{
		SetInitialReferences();
        gameManagerMaster.EventTogglePause += TogglePauseMenu;
	}

	void OnDisable() 
	{
        gameManagerMaster.EventTogglePause -= TogglePauseMenu;
    }

	void SetInitialReferences() 
	{
        gameManagerMaster = GetComponent<GameManager_Master>();
	}

    void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }
}
