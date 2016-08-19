using UnityEngine;
using System.Collections;

public class Flashlight_ToggleOnOff : MonoBehaviour {

    private Flashlight_Master flashLightMaster;
    [SerializeField]
    private Light flashLight;

	void OnEnable() 
	{
		SetInitialReferences();
        flashLightMaster.EventToggleLight += ToggleFlashlight;
	}

	void OnDisable() 
	{
        flashLightMaster.EventToggleLight -= ToggleFlashlight;
    }
	
	void Update () 
	{
	    if(Input.GetButtonDown("Toggle flashlight"))
        {
            flashLightMaster.CallEventToggleLight();
        }
	}

	void SetInitialReferences() 
	{
        flashLightMaster = GetComponent<Flashlight_Master>();
	}

    void ToggleFlashlight()
    {
        flashLightMaster.isLit = !flashLightMaster.isLit;
        if(flashLightMaster.isLit)
        {
            flashLight.enabled = true;
        }
        else
        {
            flashLight.enabled = false;
        }
    }
}
