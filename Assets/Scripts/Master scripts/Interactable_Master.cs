using UnityEngine;
using System.Collections;

public class Interactable_Master : MonoBehaviour {

    public delegate void GeneralEventHandler();

    public event GeneralEventHandler EventInteracted;

    public void CallEventInteracted()
    {
        if(EventInteracted != null)
        {
            EventInteracted();
        }
    }
}
