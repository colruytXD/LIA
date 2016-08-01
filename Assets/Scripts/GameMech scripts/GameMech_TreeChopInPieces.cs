using UnityEngine;
using System.Collections;

public class GameMech_TreeChopInPieces : MonoBehaviour {

    [SerializeField]
    private float minChopHealth;
    [SerializeField]
    private float maxChopHealth;
    [SerializeField]
    private float currentChopHealth;

	void OnEnable() 
	{
		SetInitialReferences();
        currentChopHealth = maxChopHealth;
	}

	void SetInitialReferences() 
	{

	}

    public void TakeDamage(float amount)
    {
        if (currentChopHealth > minChopHealth - 1)
        {
            currentChopHealth -= amount;
        }

        if(currentChopHealth < minChopHealth)
        {
            GetComponent<GameMech_TreeDestroy>().DestroyTree();
        }
    }
}
