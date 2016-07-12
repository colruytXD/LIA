using UnityEngine;
using System.Collections;

public class GameManager_CreateSaveFile : MonoBehaviour {

	void OnEnable() 
	{
        CheckForSaveFile();
	}
    
    void CheckForSaveFile()
    {
        if(PlayerPrefs.HasKey("Exists"))
        {
            return;
        }
        else
        {
            CreateSaveFile();
        }
    }

    void CreateSaveFile()
    {
        PlayerPrefs.SetInt("Exists", 1);
    }
}
