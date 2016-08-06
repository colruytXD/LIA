using UnityEngine;
using System.Collections;

public class BerryBush_SwitchPickState : MonoBehaviour {

    private BerryBush_Master berryBushMaster;

	void OnEnable() 
	{
		SetInitialReferences();
        berryBushMaster.EventBushHit += TogglePickState;
	}

	void OnDisable() 
	{
        berryBushMaster.EventBushHit -= TogglePickState;
    }

	void SetInitialReferences() 
	{
        berryBushMaster = GetComponent<BerryBush_Master>();
	}

    void TogglePickState()
    {
        if(!berryBushMaster.isPicked)
        {
            berryBushMaster.isPicked = true;
        }
    }
}
