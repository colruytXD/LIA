﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMech_Hunger : MonoBehaviour {

    private GameMech_Health gameMechHealth;

    [SerializeField]
    private Image imgHungerBar;
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
    

	void SetInitialReferences() 
	{
        gameMechHealth = GetComponent<GameMech_Health>();
	}

    void DecreaseHunger(float amount) //Decreases hunger by certain amount
    {
        HungerAmount -= amount;

        imgHungerBar.fillAmount = HungerAmount / 100;

        if(HungerAmount < minHunger) //this if statement makes sure the hunger doesnt go over max or min hunger (DEFAULT: 100, 0)
        {
            //Sets hunger to 0 and makes the player lose health via Health script
            gameMechHealth.DeductCurrentHealth(amountHealthLossWhenStarving);
            HungerAmount = minHunger;
            
        }
    }

    void IncreaseHunger(float amount)
    {
        HungerAmount += amount;

        imgHungerBar.fillAmount = HungerAmount / 100;

        if(HungerAmount > maxHunger)
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
