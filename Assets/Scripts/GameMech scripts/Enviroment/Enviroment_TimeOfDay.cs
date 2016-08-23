using UnityEngine;
using System.Collections;

public class Enviroment_TimeOfDay : MonoBehaviour {

    /* 1u = 60sec
     * 1d = 1440sec
     */
    int i;

    [SerializeField, Tooltip("Skyboxes for display TOD, put in order")]
    private Material[] skyboxes;

    [SerializeField, Tooltip("When to change skybox")]
    private float[] timeFrames = { 0, 6, 12, 18 };

    //Time in hr
    private float currentDaytime;
    private float lastMidnight;
    private float lengthOfDay = 24;
    private int amountOfDaysPassed = 0;

    private float currentTime;

    private bool changed;

	void FixedUpdate()
    {
        ConvertDaytime();
        ChangeSkybox();
    }

    void ConvertDaytime()
    {
        if(currentTime > lengthOfDay)
        {
            currentTime = 0;
            amountOfDaysPassed++;
        }

        currentTime = Time.time - lengthOfDay * amountOfDaysPassed;
    }

    void ChangeSkybox()
    {
        //if(currentTime < timeFrames[0]) //0
        //{
        //        //Avond
        //        Debug.Log("Avond");
        //    return;
        //}
        //else if(currentTime < timeFrames[1]) //6
    //    if
    //    {
    //            //Nacht
    //            Debug.Log("Nacht");
    //        return;

    //    }
    //    else if (currentTime < timeFrames[2]) //6
    //    {
    //            //Morgen
    //            Debug.Log("Morgen");
    //        return;

    //    }
    //    else if(currentTime < timeFrames[3]) //6
    //    {
    //            //Middag
    //            Debug.Log("Middag");
    //        return;

    //    }
    }
}
