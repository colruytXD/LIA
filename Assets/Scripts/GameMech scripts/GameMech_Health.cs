using UnityEngine;
using System.Collections;

public class GameMech_Health : MonoBehaviour {

    private GameMech_Master gameMechMaster;

    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float minHealth;

    public float CurrentHealth;

	void OnEnable() 
	{
		SetInitialReferences();
	}

	void OnDisable() 
	{

	}

	void SetInitialReferences() 
	{
        gameMechMaster = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameMech_Master>();
	}

    public void DeductCurrentHealth(float deductAmount)
    {   
        CurrentHealth -= deductAmount;

        if (CurrentHealth < minHealth)
        {
            CurrentHealth = minHealth; //Makes sure CurrentHealth doesn't go under zero
            gameMechMaster.CallEventKillPlayer(); //Kills Player
        }
    }

    public void IncreaseCurrentHealth(float increaseAmount)
    {
        CurrentHealth += increaseAmount;

        if(CurrentHealth > maxHealth)
        {
            CurrentHealth = maxHealth;
        }
    }
}
