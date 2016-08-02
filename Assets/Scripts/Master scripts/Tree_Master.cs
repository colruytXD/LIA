using UnityEngine;
using System.Collections;

public class Tree_Master : MonoBehaviour {

    public bool isCutDown;

    public delegate void TreeEventHandler(Transform hitTransform);

    public event TreeEventHandler EventTreeGotChoppedDown;
    public event TreeEventHandler EventDestroyTree;

    public delegate void TreeHitHandler(float amount, Transform hitTransform);

    public event TreeHitHandler EventTreeHit;

    public void CallEventTreeHit(float amount, Transform transform)
    {
        print("amt" + amount);
        if (EventTreeHit != null)
        {
            EventTreeHit(amount, transform);
            
        }
    }

    public void CallEventGotChoppedDown(Transform hitTransform)
    {
        if (EventTreeGotChoppedDown != null)
        {
            EventTreeGotChoppedDown(transform);
        }
    }

    public void CallEventDestroyTree(Transform hitTransform)
    {
        if(EventDestroyTree != null)
        {
            EventDestroyTree(transform);
        }
    }

}
