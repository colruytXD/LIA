using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class SaveLoadTogglesVideoSettings : MonoBehaviour {

    public Toggle[] toggles;

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
        FileStream file = File.Create(Application.persistentDataPath + "VideoSettingsToggleAble.dat");
        List<SaveAble_Toggle> saveAblesCollection = new List<SaveAble_Toggle>();

        for(int i = 0; i < toggles.Length; i++)
        {
            SaveAble_Toggle saveAbleToggleData = new SaveAble_Toggle();

            saveAbleToggleData.isOn = toggles[i].GetComponent<ToggleState>().isOn();

            saveAblesCollection.Add(saveAbleToggleData);
        }
        binaryFormatter.Serialize(file, saveAblesCollection);
        file.Seek(0, SeekOrigin.Begin);
        file.Close();
       
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "VideoSettingsToggleAble.dat"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "VideoSettingsToggleAble.dat", FileMode.Open);
            file.Seek(0, SeekOrigin.Begin);
            List<SaveAble_Toggle> saveAblesCollection = new List<SaveAble_Toggle>();
            saveAblesCollection = (List<SaveAble_Toggle>)binaryFormatter.Deserialize(file);

            for(int i = 0; i < toggles.Length; i++)
            {
                toggles[i].isOn = saveAblesCollection[i].isOn;
            }
            file.Close();
        }
        else
        {
            File.Create(Application.persistentDataPath + "VideoSettingsToggleAble.dat");
        }
    }
}

[System.Serializable]
class SaveAble_Toggle
{
    public bool isOn;
}
