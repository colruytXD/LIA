using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleState : MonoBehaviour {

	public bool isOn()
    {
        return gameObject.GetComponent<Toggle>().isOn;
    }
}
