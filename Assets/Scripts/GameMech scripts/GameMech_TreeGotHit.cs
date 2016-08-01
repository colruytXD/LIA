using UnityEngine;
using System.Collections;

public class GameMech_TreeGotHit : MonoBehaviour {

    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float minHealth;

    void OnEnable() 
	{
		SetInitialReferences();
        currentHealth = maxHealth;
	}

	void OnDisable() 
	{

	}

	void SetInitialReferences() 
	{

	}

    public void TakeDamage(float amount, Transform hitter)
    {
        if (currentHealth > minHealth - 1)
        {
            currentHealth -= amount;
        }

        if (currentHealth < minHealth)
        {
            GetComponent<GameMech_TreeGotCutDown>().TreeChoppedDown(hitter);
            GetComponent<GameMech_TreeChopInPieces>().TakeDamage(amount);
        }
    }
}
