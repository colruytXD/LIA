﻿using UnityEngine;
using System.Collections;

public class GameMech_Hit : MonoBehaviour {

    RaycastHit hit;
    [SerializeField]
    private float maxHitDistance;

    public float HitDamage;

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
            if(Physics.Raycast(transform.position, transform.forward, out hit, maxHitDistance))
            {
                Hit(hit);
            }
        }
    }

    void Hit(RaycastHit hit)
    {
        if(hit.transform.CompareTag("Tree"))
        {
            hit.transform.GetComponent<GameMech_TreeGotHit>().TakeDamage(HitDamage, transform);
        }
    }
}