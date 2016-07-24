using UnityEngine;
using System.Collections;

public class GameManager_DisableHUD : MonoBehaviour {

    private GameManager_Master gameManagerMaster;
    [SerializeField]
    private GameObject HUD;

	void OnEnable() 
	{
		SetInitialReferences();
        gameManagerMaster.EventPlayerDie += ToggleHud;
        gameManagerMaster.EventTogglePause += ToggleHud;
	}

	void OnDisable() 
	{
        gameManagerMaster.EventPlayerDie -= ToggleHud;
        gameManagerMaster.EventTogglePause -= ToggleHud;
    }

	void SetInitialReferences() 
	{
        gameManagerMaster = GetComponent<GameManager_Master>();
	}

    void ToggleHud()
    {
        HUD.SetActive(!HUD.activeSelf);
    }
}
