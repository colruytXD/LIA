using UnityEngine;
using System.Collections;

public class Hittable_Master : MonoBehaviour {

    public delegate void HitHandler(float deductAmount, Transform hitter);

    public event HitHandler EventTransformGotHit;

    public void CallEventTransformGotHit(float deductAmount, Transform hitter)
    {
        if(EventTransformGotHit != null)
        {
            EventTransformGotHit(deductAmount, hitter);
        }
    }
}
