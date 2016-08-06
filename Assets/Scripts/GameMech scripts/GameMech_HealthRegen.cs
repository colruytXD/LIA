using UnityEngine;
using System.Collections;

public class GameMech_HealthRegen : MonoBehaviour {

    //private GameMech_Master gameMechMaster;
    [SerializeField]
    private float minFoodToRegen;
    [SerializeField]
    private float minThirstToRegen;
    [SerializeField]
    private float regenAmount;
    [SerializeField, Tooltip("Amount of seconds")]
    private float regenTime;

    private bool isRunning = false;

	void OnEnable() 
	{
		SetInitialReferences();
	}

	void OnDisable() 
	{

	}
	
	void Update () 
	{
	
	}

	void SetInitialReferences() 
	{
        //gameMechMaster = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameMech_Master>();
	}

    public void CheckIfRegenIsPossible()
    {
        if (GetComponent<GameMech_Health>().CurrentHealth > 0 && GetComponent<GameMech_Health>().CurrentHealth <= 100) //Checks if health is in bounds for regen
        {
            if(GetComponent<GameMech_Thirst>().thirstAmount > minThirstToRegen && GetComponent<GameMech_Hunger>().HungerAmount > minFoodToRegen) //Checks if the requirements for regen are true
            {
                if(!isRunning)
                {
                    StartCoroutine(Heal(regenTime));
                }  
            }
            else
            {
                StopCoroutine(Heal(regenTime));
            }
        }
    }

    IEnumerator Heal(float seconds)
    {
        isRunning = true;
        GetComponent<GameMech_Health>().IncreaseCurrentHealth(regenAmount);
        yield return new WaitForSeconds(seconds);
        isRunning = false;
        StartCoroutine(Heal(seconds));
        
    }
}
