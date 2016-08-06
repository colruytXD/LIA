using UnityEngine;
using System.Collections;

public class BerryBush_ShowPickState : MonoBehaviour {

    private BerryBush_Master berryBushMaster;
    [SerializeField]
    private GameObject berryGO;

	void OnEnable() 
	{
		SetInitialReferences();
        berryBushMaster.EventBushHit += HideBerries;
        berryBushMaster.EventRegenerateBush += ShowBerries;
	}

	void OnDisable() 
	{
        berryBushMaster.EventBushHit -= HideBerries;
        berryBushMaster.EventRegenerateBush -= ShowBerries;
    }

	void SetInitialReferences() 
	{
        berryBushMaster = GetComponent<BerryBush_Master>();
	}

    void HideBerries()
    {
        berryGO.SetActive(false);
    }

    void ShowBerries()
    {
        berryGO.SetActive(true);
    }
}
