using UnityEngine;
using System.Collections;

public class BerryBushState : MonoBehaviour {


    private BerryBush_Master berryBushMaster;

    void OnEnable()
    {
        SetInitialReferences();
    }

    void SetInitialReferences()
    {
        berryBushMaster = GetComponent<BerryBush_Master>();
    }

    public bool isPicked()
    {
        return berryBushMaster.isPicked;
    }
}
