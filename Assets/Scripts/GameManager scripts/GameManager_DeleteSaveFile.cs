using UnityEngine;
using System.Collections;
using System.IO;

// There is definetly a better way to do this! Lazyness :p

public class GameManager_DeleteSaveFile : MonoBehaviour {

    private GameManager_Master gameManagerMaster;
    [SerializeField]
    private string[] DeletableDataPaths;

	void OnEnable() 
	{
		SetInitialReferences();
        gameManagerMaster.EventDeleteSave += DeleteSaveFiles;
	}

	void OnDisable() 
	{
        gameManagerMaster.EventDeleteSave -= DeleteSaveFiles;
    }

	void SetInitialReferences() 
	{
        gameManagerMaster = GetComponent<GameManager_Master>();
	}

    void DeleteSaveFiles()
    {
        Debug.Log("Deleting saves");
        for(int i = 0; i < DeletableDataPaths.Length; i++)
        {
            if(File.Exists(Application.persistentDataPath + DeletableDataPaths[i].ToString()))
            {
                File.Delete(Application.persistentDataPath + DeletableDataPaths[i].ToString());
            }
        }
    }
}
