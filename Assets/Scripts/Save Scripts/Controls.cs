using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controls : MonoBehaviour {

	public string chosenControl()
    {
        return gameObject.GetComponent<InputField>().text;
    }
}
