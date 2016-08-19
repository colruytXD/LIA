using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class SaveLoadControls : MonoBehaviour {

    public InputField moveForward;
    public InputField moveBackward;
    public InputField moveLeft;
    public InputField moveRight;
    public InputField interact;

    public string moveForwardStr;
    public string moveBackwardStr;
    public string moveLeftStr;
    public string moveRightStr;
    public string interactStr;

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

        SaveAble_Controls saveAbleControls = new SaveAble_Controls();

        saveAbleControls.moveForward = moveForward.text;
        saveAbleControls.moveBackward = moveBackward.text;
        saveAbleControls.moveLeft = moveLeft.text;
        saveAbleControls.moveRight = moveRight.text;
        saveAbleControls.interact = interact.text;

        binaryFormatter.Serialize(file, saveAbleControls);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/Controls.dat"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Controls.dat", FileMode.Open);
            file.Seek(0, SeekOrigin.Begin);

            SaveAble_Controls saveAbleControls = new SaveAble_Controls();
            if(saveAbleControls.moveForward != null)
            {
                moveForwardStr = saveAbleControls.moveForward;
                moveBackwardStr = saveAbleControls.moveBackward;
                moveLeftStr = saveAbleControls.moveLeft;
                moveRightStr = saveAbleControls.moveRight;
                interactStr = saveAbleControls.interact;
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
    //Movement
    public string moveForward;
    public string moveBackward;
    public string moveLeft;
    public string moveRight;
    public string crouch;

    //Other
    public string interact;
}
