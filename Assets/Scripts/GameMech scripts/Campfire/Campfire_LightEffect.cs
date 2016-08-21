using UnityEngine;
using System.Collections;

public class Campfire_LightEffect : MonoBehaviour {

    private Campfire_Master campfireMaster;

    [SerializeField]
    private Light fire;
    [SerializeField]
    private ParticleSystem fireParticles;
    [SerializeField]
    private float maxIntensity;
    [SerializeField]
    private float minIntensity;
    [SerializeField]
    private float intensityChangeTime;

    private float _nextIntensityAmount;

	void OnEnable() 
	{
		SetInitialReferences();
        campfireMaster.EventToggleCampfire += ToggleLit;
        StartCoroutine(Timer());
	}

	void OnDisable() 
	{
        campfireMaster.EventToggleCampfire -= ToggleLit;
    }

    void ToggleLit()
    {
        campfireMaster.isLit = !campfireMaster.isLit;

        if(campfireMaster.isLit)
        {
            fire.enabled = true;
            fireParticles.Play();
            StartCoroutine(Timer());
        }
        else
        {
            StopCoroutine(Timer());
            fire.enabled = false;
            fireParticles.Stop();
        }
    }

	void SetInitialReferences() 
	{
        campfireMaster = GetComponent<Campfire_Master>();
	}

    void ChangeIntensity()
    {
        _nextIntensityAmount = (_nextIntensityAmount + Random.Range(minIntensity, maxIntensity)) / 2;
        fire.intensity = _nextIntensityAmount;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(intensityChangeTime);
        if(campfireMaster.isLit)
        {
            ChangeIntensity();
            StartCoroutine(Timer());
        }
        
    }

}
