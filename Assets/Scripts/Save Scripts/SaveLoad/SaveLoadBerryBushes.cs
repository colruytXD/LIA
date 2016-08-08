using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadBerryBushes : MonoBehaviour {

    private GameManager_Master gameManagerMaster;
    private GameObject[] berryBushes;

	void OnEnable() 
	{
		SetInitialReferences();
        gameManagerMaster.EventSaveGame += Save;
        Load();
	}

	void OnDisable() 
	{
        gameManagerMaster.EventSaveGame += Save;
    }

	void SetInitialReferences() 
	{
        gameManagerMaster = GetComponent<GameManager_Master>();
	}

    void Save()
    {
        Debug.Log("Saving BerryBushState");

        berryBushes = GameObject.FindGameObjectsWithTag("BerryBush");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/BerryBushState.dat");

        List<SaveAble_BushState> saveAbleBushStateCollection = new List<SaveAble_BushState>();
        
        for(int i = 0; i < berryBushes.Length; i++)
        {
            SaveAble_BushState saveAbleBushStateData = new SaveAble_BushState();

            saveAbleBushStateData.isPicked = berryBushes[i].transform.GetComponent<BerryBushState>().isPicked();

            saveAbleBushStateCollection.Add(saveAbleBushStateData);
        }

        bf.Serialize(file, saveAbleBushStateCollection);
        file.Close(); 
    }

    void Load()
    {
        Debug.Log("Loading BerryBush State");

        berryBushes = GameObject.FindGameObjectsWithTag("BerryBush");

        if(File.Exists(Application.persistentDataPath + "/BerryBushState.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/BerryBushState.dat", FileMode.Open);
            file.Seek(0, SeekOrigin.Begin);

            List<SaveAble_BushState> saveAbleBushStateCollection = new List<SaveAble_BushState>();
            saveAbleBushStateCollection = (List<SaveAble_BushState>)bf.Deserialize(file); 

            for(int i = 0; i < berryBushes.Length; i++)
            {
                berryBushes[i].GetComponent<BerryBush_Master>().isPicked = saveAbleBushStateCollection[i].isPicked;
            }

            file.Close();
        }
        else
        {
            Debug.LogError("No SaveFile exists");
        }
    }
}

[System.Serializable]
class SaveAble_BushState
{
    public bool isPicked;
}
