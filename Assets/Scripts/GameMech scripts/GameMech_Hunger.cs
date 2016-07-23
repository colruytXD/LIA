using UnityEngine;
using System.Collections;

public class GameMech_Hunger : MonoBehaviour {

    private GameMech_Health gameMechHealth;

    [SerializeField]
    private float timeBetweenHungerDecrease;
    [SerializeField]
    private float amountHungerDecrease;
    [SerializeField]
    private float amountHealthLossWhenStarving;

    private float maxHunger = 100;
    private float minHunger = 0;

    public float HungerAmount;

    float nextCheck;


    void OnEnable() 
	{
		SetInitialReferences();
        StartCoroutine(HungerDecrease()); //Starts the hungerDecrease coroutine
	}

	void OnDisable() 
	{

	}

	void SetInitialReferences() 
	{
        gameMechHealth = GetComponent<GameMech_Health>();
	}

    void DecreaseHunger(float amount) //Decreases hunger by certain amount
    {
        HungerAmount -= amount;

        if(HungerAmount < minHunger) //this if statement makes sure the hunger doesnt go over max or min hunger (DEFAULT: 100, 0)
        {
            //Sets hunger to 0 and makes the player lose health via Health script
            print("starving");
            gameMechHealth.DeductCurrentHealth(amountHealthLossWhenStarving);
            HungerAmount = minHunger;
            
        }
        else if(HungerAmount > maxHunger)
        {
            HungerAmount = maxHunger;
        }
    }

    IEnumerator HungerDecrease() //Runs forever with some time between => calls decreaseHunger function
    {
        yield return new WaitForSeconds(timeBetweenHungerDecrease);
        DecreaseHunger(amountHungerDecrease);

        StartCoroutine(HungerDecrease());
    }
}
