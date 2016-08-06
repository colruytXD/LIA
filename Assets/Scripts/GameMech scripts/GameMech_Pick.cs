using UnityEngine;
using System.Collections;

public class GameMech_Pick : MonoBehaviour {

    private RaycastHit hit;
    [SerializeField]
    private float maxDistance;
	
	void Update () 
	{
        CheckForPickup();
	}

    void CheckForPickup()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
            {
                Pickup(hit);
            }
        }
    }

    void Pickup(RaycastHit hit)
    {
        if (hit.transform.CompareTag("BerryBush"))
        {
            hit.transform.GetComponent<BerryBush_Master>().CallEventBushHit();
        } 
    }
}
