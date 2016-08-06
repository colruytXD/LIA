using UnityEngine;
using System.Collections;

public class GameMech_RemoveTreeInstance : MonoBehaviour {

    private Tree_Master treeMaster;

	void OnEnable() 
	{
		SetInitialReferences();
        treeMaster.EventDestroyTree += DestroyTree;
	}

	void OnDisable() 
	{
        treeMaster.EventDestroyTree += DestroyTree;
	}
	

	void SetInitialReferences() 
	{
        treeMaster = GetComponent<Tree_Master>();
	}

    void DestroyTree(Transform transform)
    {
        print("call");
        GetComponent<TreesPosition>().destroyed = true;
        Component[] comp = gameObject.GetComponents(typeof(Component));

        for(int i = 0; i < comp.Length; i++)
        {
            if(comp[i] != GetComponent<TreesPosition>() && comp[i] != GetComponent<Transform>())
            {
                Destroy(comp[i]);
            }
         }
    }
}
