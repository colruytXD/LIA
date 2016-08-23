using UnityEngine;
using System.Collections;

public class Food_PlayEatingAnimation : MonoBehaviour {

    private Food_Master foodMaster;

	void OnEnable() 
	{
		SetInitialReferences();
        foodMaster.EventEatFood += PlayAnimation;
	}

	void OnDisable() 
	{
        foodMaster.EventEatFood -= PlayAnimation;
    }

	void SetInitialReferences() 
	{
        foodMaster = GetComponent<Food_Master>();
	}

    void PlayAnimation()
    {
        //Play animation

        OnEndAnimation();
    }

    void OnEndAnimation()
    {
        foodMaster.CallEventAteFood();
    }
}
