using UnityEngine;
using System.Collections;

public class GameMech_RemoveTreeInstance : MonoBehaviour {

    private Tree_Master treeMaster;
    [SerializeField]
    private GameObject[] toDestroyGO;

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
        GetComponent<TreesPosition>().destroyed = true;
        Component[] comp = gameObject.GetComponents(typeof(Component));

        for(int i = 0; i < comp.Length; i++)
        {
            if(comp[i] != GetComponent<TreesPosition>() && comp[i] != GetComponent<Transform>())
            {
                Destroy(comp[i]);
            }
         }

        for(int i = 0; i < toDestroyGO.Length; i++)
        {
            Destroy(toDestroyGO[i]);
        }
    }
}
