using UnityEngine;
using System.Collections;

public class GameMech_Hit : MonoBehaviour {

    RaycastHit hit;
    [SerializeField]
    private float maxHitDistance;

    public float currentHitDamage = 20;

    [SerializeField]
    private LayerMask hittableLayer;

	void OnEnable() 
	{
		SetInitialReferences();
	}

	void OnDisable() 
	{

	}
	
	void Update () 
	{
        CheckForHit();
	}

	void SetInitialReferences() 
	{

	}

    void CheckForHit()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(Physics.Raycast(transform.position, transform.forward, out hit, maxHitDistance, hittableLayer))
            {
                Hit(currentHitDamage ,hit);
                print(hit.transform.name);
            }
        }
    }

    void Hit(float damage, RaycastHit hit)
    {
        if(hit.transform.GetComponent<Hittable_Master>() != null)
        {
            hit.transform.GetComponent<Hittable_Master>().CallEventTransformGotHit(damage, hit.transform);
        }
        
    }
}
