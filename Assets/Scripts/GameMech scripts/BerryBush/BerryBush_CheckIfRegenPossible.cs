using UnityEngine;
using System.Collections;

public class BerryBush_CheckIfRegenPossible : MonoBehaviour {

    private BerryBush_Master berryBushMaster;

    private float lastCheck;
    private float nextCheck;
    [SerializeField]
    private float checkRate;

	void OnEnable() 
	{
		SetInitialReferences();
	}

	void OnDisable() 
	{

	}
	
	void Update () 
	{
        CheckForRegen();
	}

	void SetInitialReferences() 
	{
        berryBushMaster = GetComponent<BerryBush_Master>();
	}

    void CheckForRegen()
    {
        if (nextCheck < Time.time)
        {
            if(Random.value > .5)
            {
                if(berryBushMaster.isPicked)
                {
                    berryBushMaster.CallEventRegenerateBush();
                    berryBushMaster.isPicked = false;                 
                }
            }

            nextCheck = Time.time + checkRate;
        }
    }
}
