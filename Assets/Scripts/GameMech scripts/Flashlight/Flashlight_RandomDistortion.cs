using UnityEngine;
using System.Collections;

public class Flashlight_RandomDistortion : MonoBehaviour {

    private Flashlight_Master flashlightMaster;

    [SerializeField]
    private float minDistortionTime;
    [SerializeField]
    private float maxDistortionTime;
    [SerializeField]
    private int minAmountOfToggles;
    [SerializeField]
    private int maxAmountOfToggles;

    private float nextToggle;
    private int currentAmountOfToggles;
    private int amountOfTogglesToBeDone;

    int counter;

	void OnEnable() 
	{
		SetInitialReferences();
        CheckWhenToToggle();
	}

	void OnDisable() 
	{

	}

	void SetInitialReferences() 
	{
        flashlightMaster = GetComponent<Flashlight_Master>();
	}

    void CheckWhenToToggle()
    {
        if(flashlightMaster.isLit)
        {
            nextToggle = Random.Range(minDistortionTime, maxDistortionTime);
            amountOfTogglesToBeDone = Random.Range(minAmountOfToggles, maxAmountOfToggles);

            StartCoroutine(TimerToFlicker());
        }
        else
        {
            StopCoroutine(TimerToFlicker());
            StopCoroutine(TimerBetweenFlickers());
        }
    }

    IEnumerator TimerToFlicker()
    {
        yield return new WaitForSeconds(nextToggle);

        StartCoroutine(TimerBetweenFlickers());

        CheckWhenToToggle();
    }

    IEnumerator TimerBetweenFlickers()
    {
        if (currentAmountOfToggles <= amountOfTogglesToBeDone)
        {
            flashlightMaster.CallEventToggleLight();
            currentAmountOfToggles++;
        }
        else
        {
            StopCoroutine(TimerBetweenFlickers());
            currentAmountOfToggles = 0;
        }

        yield return new WaitForSeconds(0.2f);
        StartCoroutine(TimerBetweenFlickers());
    }
}
