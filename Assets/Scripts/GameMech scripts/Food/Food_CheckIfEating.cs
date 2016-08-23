using UnityEngine;
using System.Collections;

public class Food_CheckIfEating : MonoBehaviour {

    private Food_Master foodMaster;

	void OnEnable() 
	{
		SetInitialReferences();
	}
	
	void Update () 
	{
        CheckIfEating();
	}

	void SetInitialReferences() 
	{
        foodMaster = GetComponent<Food_Master>();
	}

    void CheckIfEating()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            if(foodMaster.eatAble)
            {
                foodMaster.CallEventEatFood();
                Debug.Log("Called eatEvent");
            }
            
        }
    }
}
