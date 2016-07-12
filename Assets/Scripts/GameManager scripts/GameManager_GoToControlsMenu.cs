using UnityEngine;
using System.Collections;

public class GameManager_GoToControlsMenu : MonoBehaviour {

    private GameManager_Master gameManagerMasterScript;

    public GameObject pnlSettingsMenu;
    public GameObject pnlMainMenu;
    public GameObject pnlVideoSettingsMenu;
    public GameObject pnlControlsMenu;

    void OnEnable()
    {
        SetInitialReferences();
        gameManagerMasterScript.EventGoToControlsMenu += GoToControlsMenu;
    }

    void OnDisable()
    {
        gameManagerMasterScript.EventGoToControlsMenu -= GoToControlsMenu;
    }

    void SetInitialReferences()
    {
        gameManagerMasterScript = GetComponent<GameManager_Master>();
    }

    void GoToControlsMenu()
    {
        pnlMainMenu.SetActive(false);
        pnlControlsMenu.SetActive(true);
        pnlVideoSettingsMenu.SetActive(false);
        pnlSettingsMenu.SetActive(false);
    }
}
