using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadTreePositions : MonoBehaviour
{

    private GameManager_Master gameManagerMaster;
    public GameObject[] trees;

    void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.EventSaveGame += Save;
        Load();
    }

    void OnDisable()
    {
        gameManagerMaster.EventSaveGame -= Save;
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();
    }

    void Save()
    {
        Debug.Log("Saving TreePositions");
        trees = GameObject.FindGameObjectsWithTag("Tree");
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/TreePositions.dat");

        List<SaveAble_TreePositions> saveAbleTreePositionCollection = new List<SaveAble_TreePositions>();

        for (int i = 0; i < trees.Length; i++)
        {
            if (trees[i] != null)
            {
                SaveAble_TreePositions saveAbleTreePositionsData = new SaveAble_TreePositions(); //Creates new instance of saveAble_TreePositions
                saveAbleTreePositionsData.myPosX = trees[i].GetComponent<TreesPosition>().MyPosX();     //Gets current X Vector of the tree of certain tree
                saveAbleTreePositionsData.myPosY = trees[i].GetComponent<TreesPosition>().MyPosY();     //Gets current Y Vector of the tree of certain tree
                saveAbleTreePositionsData.myPosZ = trees[i].GetComponent<TreesPosition>().MyPosZ();     //Gets current Z Vector of the tree of certain tree
                saveAbleTreePositionsData.myQuaternionX = trees[i].GetComponent<TreesPosition>().MyQuaternionX();   //Gets current X Quaternion of the tree of certain tree
                saveAbleTreePositionsData.myQuaternionY = trees[i].GetComponent<TreesPosition>().MyQuaternionY();   //Gets current Y Quaternion of the tree of certain tree
                saveAbleTreePositionsData.myQuaternionZ = trees[i].GetComponent<TreesPosition>().MyQuaternionZ();   //Gets current Z Quaternion of the tree of certain tree
                saveAbleTreePositionsData.myQuaternionW = trees[i].GetComponent<TreesPosition>().MyQuaternionW();   //Gets current W Quaternion of the tree of certain tree
                saveAbleTreePositionsData.destroyed = trees[i].GetComponent<TreesPosition>().Destroyed();   //Gets current destroyed bool of tree
                saveAbleTreePositionCollection.Add(saveAbleTreePositionsData); //Adds that instance of class to List for saving
            }
        }
        binaryFormatter.Serialize(file, saveAbleTreePositionCollection); //Saves List
        file.Close();
    }

    void Load()
    {
        Debug.Log("Loading TreePositions");
        trees = GameObject.FindGameObjectsWithTag("Tree");

        if (File.Exists(Application.persistentDataPath + "/TreePositions.dat"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/TreePositions.dat", FileMode.Open);
            file.Seek(0, SeekOrigin.Begin);

            List<SaveAble_TreePositions> saveAbleTreePostionCollection = new List<SaveAble_TreePositions>();
            saveAbleTreePostionCollection = (List<SaveAble_TreePositions>)binaryFormatter.Deserialize(file);

            for (int i = 0; i < trees.Length; i++)
            {
                trees[i].transform.position = new Vector3(saveAbleTreePostionCollection[i].myPosX, saveAbleTreePostionCollection[i].myPosY, saveAbleTreePostionCollection[i].myPosZ);
                trees[i].transform.rotation = new Quaternion(saveAbleTreePostionCollection[i].myQuaternionX, saveAbleTreePostionCollection[i].myQuaternionY, saveAbleTreePostionCollection[i].myQuaternionZ, saveAbleTreePostionCollection[i].myQuaternionW);
                Debug.Log(trees[i].transform.name);
                if (saveAbleTreePostionCollection[i].destroyed)
                {
                    Debug.Log(trees[i].transform.name + " has been destroyed, not loading");
                    trees[i].GetComponent<TreesPosition>().destroyed = true;

                    Component[] components = trees[i].GetComponents(typeof(Component));
                    for (int x = 0; x < components.Length; x++)
                    {
                        print(components[x]);
                    }

                    foreach(Component comp in components)
                    {
                        print(comp);
                        if(comp != trees[i].GetComponent<Transform>() && comp != trees[i].GetComponent<TreesPosition>())
                        {
                            Destroy(comp);
                        }
                    }


                }
            }
            file.Close();
        }
        else
        {
            Debug.LogError("No SaveFile exists");
        }
    }


    [System.Serializable]
    class SaveAble_TreePositions
    {
        public float myPosX;
        public float myPosY;
        public float myPosZ;

        public float myQuaternionX;
        public float myQuaternionY;
        public float myQuaternionZ;
        public float myQuaternionW;

        public bool destroyed;
    }
}
