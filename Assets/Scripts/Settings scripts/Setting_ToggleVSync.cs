using UnityEngine;
using System.Collections;

public class Setting_ToggleVSync : MonoBehaviour {

    public bool isVSyncEnabled = true;

    public void ToggleVSync()
    {
        isVSyncEnabled = !isVSyncEnabled;

        if (isVSyncEnabled == true)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }
}
