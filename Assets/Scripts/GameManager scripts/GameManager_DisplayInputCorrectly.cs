using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager_DisplayInputCorrectly : MonoBehaviour {

    [SerializeField]
    private string input;
    [SerializeField]
    private string output;
    private InputField myInputField;

	void OnEnable() 
	{
		SetInitialReferences();
        DisplayCorrectly();
    }

    void OnDisable()
    {
        DisplayCorrectly();
    }

	void SetInitialReferences() 
	{
        myInputField = gameObject.GetComponent<InputField>();
	}

    public void DisplayCorrectly()
    {
        myInputField.text = myInputField.text.ToUpper();
    }
}
