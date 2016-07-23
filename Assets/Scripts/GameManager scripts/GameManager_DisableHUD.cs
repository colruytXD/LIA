using UnityEngine;
using System.Collections;

public class GameManager_DisableHUD : MonoBehaviour {

    private GameManager_Master gameManagerMaster;
    [SerializeField]
    private GameObject HUD;

	void OnEnable() 
	{
		SetInitialReferences();
        gameManagerMaster.EventPlayerDie += DisableHud;
	}

	void OnDisable() 
	{
        gameManagerMaster.EventPlayerDie -= DisableHud;
    }

	void SetInitialReferences() 
	{
        gameManagerMaster = GetComponent<GameManager_Master>();
	}

    void DisableHud()
    {
        HUD.SetActive(false);
    }
}
