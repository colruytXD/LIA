using UnityEngine;
using System.Collections;

public class Food_IncreaseFoodLevel : MonoBehaviour {

    private Food_Master foodMaster;

	void OnEnable() 
	{
		SetInitialReferences();
        foodMaster.EventAteFood += IncreaseHunger;
	}

	void OnDisable() 
	{
        foodMaster.EventAteFood -= IncreaseHunger;
	}

	void SetInitialReferences() 
	{
        foodMaster = GetComponent<Food_Master>();
	}

    void IncreaseHunger()
    {
        if(transform.root.GetComponent<GameMech_Hunger>() != null)
        {
            transform.root.GetComponent<GameMech_Hunger>().IncreaseHunger(foodMaster.foodAmount);
        }
        else
        {
            Debug.Log("Player isn't the root parent");
        }
    }
}
