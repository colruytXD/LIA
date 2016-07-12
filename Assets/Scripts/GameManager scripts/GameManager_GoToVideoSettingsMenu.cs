using UnityEngine;
using System.Collections;

public class GameManager_GoToVideoSettingsMenu : MonoBehaviour {

    private GameManager_Master gameManagerMasterScript;

    public GameObject pnlSettingsMenu;
    public GameObject pnlMainMenu;
    public GameObject pnlVideoSettingsMenu;
    public GameObject pnlControlsMenu;

    void OnEnable()
    {
        SetInitialReferences();
        gameManagerMasterScript.EventGoToVideoSettingsMenu += GoToVideoSettingsMenu;
    }

    void OnDisable()
    {
        gameManagerMasterScript.EventGoToVideoSettingsMenu -= GoToVideoSettingsMenu;
    }

    void SetInitialReferences()
    {
        gameManagerMasterScript = GetComponent<GameManager_Master>();
    }

    void GoToVideoSettingsMenu()
    {
        pnlMainMenu.SetActive(false);
        pnlControlsMenu.SetActive(false);
        pnlVideoSettingsMenu.SetActive(true);
        pnlSettingsMenu.SetActive(false);
    }
}
