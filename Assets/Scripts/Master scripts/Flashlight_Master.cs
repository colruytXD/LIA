using UnityEngine;
using System.Collections;

public class Flashlight_Master : MonoBehaviour {

    public bool isLit = false;

    public delegate void GeneralEventHandler();

    public event GeneralEventHandler EventToggleLight;

    public void CallEventToggleLight()
    {
        if(EventToggleLight != null)
        {
            EventToggleLight();
        }
    }
}
