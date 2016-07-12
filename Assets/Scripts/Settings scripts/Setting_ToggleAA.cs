using UnityEngine;
using System.Collections;

public class Setting_ToggleAA : MonoBehaviour {

    public bool isAAEnabled = true;

    public void ToggleAA()
    {
        isAAEnabled = !isAAEnabled;

        if(isAAEnabled == true)
        {
            QualitySettings.antiAliasing = 8;
        }
        else
        {
            QualitySettings.antiAliasing = 0;
        }
    }
}
