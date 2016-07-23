using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager_GoToMainGameScene : MonoBehaviour {

    private GameManager_Master gameManagerMaster;

	void OnEnable() 
	{
		SetInitialReferences();
        gameManagerMaster.EventGoToMainGameScene += GoToMainGameScene;
	}

	void OnDisable() 
	{
        gameManagerMaster.EventGoToMainGameScene -= GoToMainGameScene;
    }

	void SetInitialReferences() 
	{
        gameManagerMaster = GetComponent<GameManager_Master>();
	}

    void GoToMainGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
