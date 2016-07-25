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
	
	void Update () 
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
            TreeChoppedDown(hitter);
        }
    }

    void TreeChoppedDown(Transform hitter)
    {
        if(gameObject.GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.mass = 100;
            rb.AddForceAtPosition(hitter.transform.forward * 300, transform.position, ForceMode.Impulse);
        } 
    }
}
