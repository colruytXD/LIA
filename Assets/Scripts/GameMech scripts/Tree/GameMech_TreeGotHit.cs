using UnityEngine;
using System.Collections;

public class GameMech_TreeGotHit : MonoBehaviour {

    private Tree_Master treeMaster;
    public float currentHealth = 100;
    [SerializeField]
    private float minHealth = 0;
    [SerializeField]
    private float maxHealth = 100;

	void OnEnable() 
	{
		SetInitialReferences();
        treeMaster.EventTreeHit += TreeGotHit;
	}

	void OnDisable() 
	{
        treeMaster.EventTreeHit -= TreeGotHit;
	}

	void SetInitialReferences() 
	{
        treeMaster = GetComponent<Tree_Master>();
	}

    void TreeGotHit(float amount, Transform transform)
    {
        
        if (currentHealth > minHealth - 1)
        {
            currentHealth -= amount;
        }
        else if (treeMaster.isCutDown == false)
        {
            treeMaster.CallEventGotChoppedDown(transform);
            treeMaster.isCutDown = true;
            currentHealth = maxHealth;
        }
        else
        {
            print("else");
            treeMaster.CallEventDestroyTree(transform);
        }
    }
}
