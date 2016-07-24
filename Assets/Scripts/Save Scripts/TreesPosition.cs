using UnityEngine;
using System.Collections;

public class TreesPosition : MonoBehaviour {

    public bool destroyed;

	public float MyPosX()
    {
        return transform.position.x;
    }

    public float MyPosY()
    {
        return transform.position.y;
    }

    public float MyPosZ()
    {
        return transform.position.z;
    }

    public float MyQuaternionX()
    {
        return transform.rotation.x;
    }

    public float MyQuaternionY()
    {
        return transform.rotation.y;
    }

    public float MyQuaternionZ()
    {
        return transform.rotation.z;
    }

    public float MyQuaternionW()
    {
        return transform.rotation.w;
    }

    public bool Destroyed()
    {
        return destroyed;
    }

}
