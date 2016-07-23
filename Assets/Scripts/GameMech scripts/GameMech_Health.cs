using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMech_Health : MonoBehaviour {

    private GameMech_Master gameMechMaster;

    [SerializeField]
    private Image imgHealthBar;
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

        imgHealthBar.fillAmount = CurrentHealth / 100;

        if (CurrentHealth < minHealth)
        {
            CurrentHealth = minHealth; //Makes sure CurrentHealth doesn't go under zero
            gameMechMaster.CallEventKillPlayer(); //Kills Player
        }
    }

    public void IncreaseCurrentHealth(float increaseAmount)
    {
        CurrentHealth += increaseAmount;

        imgHealthBar.fillAmount = CurrentHealth / 100;

        if(CurrentHealth > maxHealth)
        {
            CurrentHealth = maxHealth;
        }
    }
}
