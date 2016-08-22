using UnityEngine;
using System.Collections;

public class GameMech_Interact : MonoBehaviour {

    private RaycastHit hit;
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private LayerMask interactLayer;
	
	void Update () 
	{
        CheckForInteract();
	}

    void CheckForInteract()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, interactLayer))
            {
                Interact(hit);
            }
        }
    }

    void Interact(RaycastHit hit)
    {
        hit.transform.GetComponent<Interactable_Master>().CallEventInteracted();
        Debug.Log("Interacted with " + hit.transform.name);
    }
}
