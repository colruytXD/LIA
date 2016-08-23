using UnityEngine;
using System.Collections;

public class Food_Master : MonoBehaviour {

    public float foodAmount;
    public bool eatAble;

    public delegate void EatEventHandler();

    public event EatEventHandler EventEatFood;
    public event EatEventHandler EventAteFood;

    public void CallEventEatFood()
    {
        if(EventEatFood != null)
        {
            EventEatFood();
        }
    }

    public void CallEventAteFood()
    {
        if(EventAteFood != null)
        {
            EventAteFood();
        }
    }
}
