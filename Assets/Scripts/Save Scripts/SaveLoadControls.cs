using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class SaveLoadControls : MonoBehaviour {

    public InputField[] inpControls;

	void OnEnable() 
	{
        Load();
	}

	void OnDisable() 
	{
        Save();
	}

    public void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Controls.dat");

        List<SaveAble_Controls> saveAbleControlsCollection = new List<SaveAble_Controls>();

        for(int i = 0; i< inpControls.Length; i++)
        {
            SaveAble_Controls saveAbleControlsData = new SaveAble_Controls();
            saveAbleControlsData.Control = inpControls[i].GetComponent<Controls>().chosenControl();
            saveAbleControlsCollection.Add(saveAbleControlsData);
        }
        binaryFormatter.Serialize(file, saveAbleControlsCollection);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/Controls.dat"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Controls.dat", FileMode.Open);
            file.Seek(0, SeekOrigin.Begin);

            List<SaveAble_Controls> saveAbleControlsCollection = new List<SaveAble_Controls>();
            saveAbleControlsCollection = (List<SaveAble_Controls>)binaryFormatter.Deserialize(file);

            for(int i = 0; i < inpControls.Length; i++)
            {
                inpControls[i].text = saveAbleControlsCollection[i].Control;
            }
            file.Close();
        }
        else
        {
            Save();
        }
    }
}

[System.Serializable]
class SaveAble_Controls
{
    public string Control;
}
