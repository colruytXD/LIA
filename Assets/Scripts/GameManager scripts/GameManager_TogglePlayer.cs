using UnityEngine;
using System.Collections;

public class GameManager_TogglePlayer : MonoBehaviour {

    private GameManager_Master gameManagerMaster;
    [SerializeField]
    private GameObject player;

    void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.EventTogglePause += TogglePlayer;
    }

    void OnDisable()
    {
        gameManagerMaster.EventTogglePause -= TogglePlayer;
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();
    }

    void TogglePlayer()
    {
        player.SetActive(!player.activeSelf);
    }
}
