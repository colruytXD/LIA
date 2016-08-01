using UnityEngine;
using System.Collections;

public class GameMech_TreeGotCutDown : MonoBehaviour {

    public void TreeChoppedDown(Transform hitter)
    {
        if (gameObject.GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();
            gameObject.AddComponent<GameMech_TreeChopInPieces>();
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.mass = 1000;
            rb.AddForceAtPosition(hitter.transform.forward * 3000, transform.position + new Vector3(transform.position.x, 5, transform.position.z), ForceMode.Impulse);
        }
    }
}
