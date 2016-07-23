using UnityEngine;
using System.Collections;

public class GameManager_DestroyPlayer : MonoBehaviour {

    private GameManager_Master gameManagerMaster;
    private GameObject player;

	void OnEnable() 
	{
		SetInitialReferences();
        gameManagerMaster.EventPlayerDie += DestroyPlayer;
	}

	void OnDisable() 
	{
        gameManagerMaster.EventPlayerDie -= DestroyPlayer;
    }

	void SetInitialReferences() 
	{
        player = GameObject.FindGameObjectWithTag("Player");
        gameManagerMaster = GetComponent<GameManager_Master>();
	}

    void DestroyPlayer()
    {
        Destroy(player);
    }
}
