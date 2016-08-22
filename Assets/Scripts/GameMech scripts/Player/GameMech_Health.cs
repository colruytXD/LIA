using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMech_Health : MonoBehaviour {

    private GameManager_Master gameManagerMaster;

    [SerializeField]
    private Image imgHealthBar;
    [SerializeField]
    private Text txtHealthBar;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float minHealth;

    public float CurrentHealth;

	void OnEnable() 
	{
		SetInitialReferences();
	}

	void SetInitialReferences() 
	{
        gameManagerMaster = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager_Master>();
	}

    public void DeductCurrentHealth(float deductAmount)
    {   
        CurrentHealth -= deductAmount;

        imgHealthBar.fillAmount = CurrentHealth / 100;
        txtHealthBar.text = CurrentHealth.ToString("0");

        if (CurrentHealth < minHealth)
        {
            CurrentHealth = minHealth; //Makes sure CurrentHealth doesn't go under zero
            gameManagerMaster.CallEventPlayerDie(); //Kills Player
        }
    }

    public void IncreaseCurrentHealth(float increaseAmount)
    {
        CurrentHealth += increaseAmount;

        if (CurrentHealth > maxHealth)
        {
            CurrentHealth = maxHealth;
        }

        imgHealthBar.fillAmount = CurrentHealth / 100;
        txtHealthBar.text = CurrentHealth.ToString("0");
    }
}
