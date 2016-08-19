using UnityEngine;
using System.Collections;

public class GameMech_CallHitAnimation : MonoBehaviour {

    private GameMech_Master gameMechMaster;
    [SerializeField]
    private Animator anim;

	void OnEnable() 
	{
		SetInitialReferences();
	}

	void OnDisable() 
	{

	}

	void SetInitialReferences() 
	{
        gameMechMaster = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameMech_Master>();
	}

    void CallHitAnimation()
    {
        anim.SetTrigger("Hit");
    }
}
