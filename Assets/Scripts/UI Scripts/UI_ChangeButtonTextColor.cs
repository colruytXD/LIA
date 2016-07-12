using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Changes the color of text in an attached button

public class UI_ChangeButtonTextColor : MonoBehaviour {

    private Text _buttonText;

    void OnEnable()
    {
        SetInitialReferences();
    }

    void SetInitialReferences()
    {
        _buttonText = gameObject.GetComponentInChildren<Text>();
    }
    
    public void FadeText()
    {
        _buttonText.CrossFadeAlpha(0.5f, 0.3f, false); //Makes the A channel of the text transparant
        GetComponent<AudioSource>().Play(); //Plays source attached in Audio source component
    }

    public void UnfadeText()
    {
        _buttonText.CrossFadeAlpha(1f, 0.3f, false); //Makes the A channel of the text opaque
        Screen.SetResolution(100, 100, false);
    }
}
