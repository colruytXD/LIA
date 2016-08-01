using UnityEngine;
using System.Collections;

public class GameMech_TreeDestroy : MonoBehaviour {

	void OnEnable() 
	{
		SetInitialReferences();
	}

	void OnDisable() 
	{

	}

	void SetInitialReferences() 
	{

	}

    public void DestroyTree()
    {
        //Give player wood
        Destroy(GetComponent<Rigidbody>());
        Destroy(GetComponent<MeshFilter>());
        Destroy(GetComponent<MeshRenderer>());
        Destroy(GetComponent<BoxCollider>());
        Destroy(GetComponent<GameMech_TreeChopInPieces>());
        GetComponent<GameMech_TreeChopInPieces>().enabled = false;
        Destroy(GetComponent<GameMech_TreeGotCutDown>());
        Destroy(GetComponent<GameMech_TreeGotHit>());
        Destroy(this);
        transform.position = new Vector3(0, -10000, 0);
    }
}
