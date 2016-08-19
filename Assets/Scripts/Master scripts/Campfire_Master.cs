using UnityEngine;
using System.Collections;

public class Campfire_Master : MonoBehaviour {

    private Interactable_Master interactableMaster;

    void OnEnable()
    {
        SetInitialReferences();
        interactableMaster.EventInteracted += CallEventToggleCampfire;
    }

    void OnDisable()
    {
        interactableMaster.EventInteracted -= CallEventToggleCampfire;
    }

    void SetInitialReferences()
    {
        interactableMaster = GetComponent<Interactable_Master>();
    }

    //-----------------------------------------------------------

    public bool isLit;

    public delegate void GeneralEventHandler();

    public event GeneralEventHandler EventToggleCampfire;

    public void CallEventToggleCampfire()
    {
        if(EventToggleCampfire != null)
        {
            EventToggleCampfire();
        }
    }
}
