using UnityEngine;
using System.Collections;

public class BerryBush_Master : MonoBehaviour
{
    private Interactable_Master interactableMaster;

    void OnEnable()
    {
        SetInitialReferences();
        interactableMaster.EventInteracted += CallEventBushHit;
    }

    void OnDisable()
    {
        interactableMaster.EventInteracted -= CallEventBushHit;
    }

    void SetInitialReferences()
    {
        interactableMaster = GetComponent<Interactable_Master>();
    }

    //--------------------------------------------------------------

    public bool isPicked;

    public delegate void GeneralEventHandler();

    public event GeneralEventHandler EventBushHit;
    public event GeneralEventHandler EventRegenerateBush;

    public void CallEventBushHit()
    {
        if (EventBushHit != null)
        {
            EventBushHit();
        }
    }

    public void CallEventRegenerateBush()
    {
        if (EventRegenerateBush != null)
        {
            EventRegenerateBush();
        }
    }
}
