using UnityEngine;
using System.Collections;

public class GameMech_Thirst : MonoBehaviour {

    private GameMech_Health gameMechHealth;

    [SerializeField]
    private float timeBetweenThirstDecrease;
    [SerializeField]
    private float amountThirstDecrease;
    [SerializeField]
    private float amountHealthLossWhenDehydrated;

    private float maxThirst = 100;
    private float minThirst = 0;

    public float thirstAmount;

    float nextCheck;


    void OnEnable()
    {
        SetInitialReferences();
        StartCoroutine(ThirstDecrease()); //Starts the hungerDecrease coroutine
    }

    void OnDisable()
    {

    }

    void SetInitialReferences()
    {
        gameMechHealth = GetComponent<GameMech_Health>();
    }

    void DecreaseHunger(float amount) //Decreases thirst by certain amount
    {
        thirstAmount -= amount;

        if (thirstAmount < minThirst) //this if statement makes sure the thirst doesnt go over max or min thirst (DEFAULT: 100, 0)
        {
            //Sets thirst to 0 and makes the player lose health via Health script
            print("drying out");
            gameMechHealth.DeductCurrentHealth(amountHealthLossWhenDehydrated);
            thirstAmount = minThirst;

        }
        else if (thirstAmount > maxThirst)
        {
            thirstAmount = maxThirst;
        }
    }

    IEnumerator ThirstDecrease() //Runs forever with some time between => calls decreaseThirst function
    {
        yield return new WaitForSeconds(timeBetweenThirstDecrease);
        DecreaseHunger(amountThirstDecrease);

        StartCoroutine(ThirstDecrease());
    }
}
