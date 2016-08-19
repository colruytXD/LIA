using UnityEngine;
using System.Collections;

public class GameMech_TreeChoppedDown : MonoBehaviour {

    private Tree_Master treeMaster;

	void OnEnable() 
	{
		SetInitialReferences();
        treeMaster.EventTreeGotChoppedDown += PushOverTree;
	}

	void OnDisable() 
	{
        treeMaster.EventTreeGotChoppedDown -= PushOverTree;
    }

	void SetInitialReferences() 
	{
        treeMaster = GetComponent<Tree_Master>();
	}

    void PushOverTree(Transform HitTransform)
    {
        gameObject.AddComponent<Rigidbody>();
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.mass = 1000;
        rb.AddForceAtPosition(-HitTransform.transform.forward, transform.position /*+ new Vector3(transform.position.x, 5, transform.position.z)*/ * 500, ForceMode.Impulse);
    }
}
