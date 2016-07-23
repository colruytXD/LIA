using UnityEngine;
using System.Collections;

public class GameMech_Master : MonoBehaviour {

    public delegate void GameMechHandler();

    public event GameMechHandler EventKillPlayer;

    public void CallEventKillPlayer()
    {
        if(EventKillPlayer != null)
        {
            EventKillPlayer();
        }
    }
}
