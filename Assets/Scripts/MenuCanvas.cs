using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuCanvas : MonoBehaviour
{
    public Button buttonQuit;
    public Canvas canvasButtons;
    public Canvas canvasStats;

    public Text statsJumps;
    public Text statsLevels;
    public Text statsEvolved;
    public Text statsArms;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Disable quit button on web builds.
        if (Application.platform == RuntimePlatform.WebGLPlayer) {
            buttonQuit.gameObject.SetActive(false);
        }
        // Update statistics text with stats from GlobalVars.
        
        statsJumps.text = statsJumps.text + GlobalVars.Instance.statsJumps.ToString();
        statsLevels.text = statsLevels.text + GlobalVars.Instance.statsLevels.ToString();
        statsEvolved.text = statsEvolved.text + GlobalVars.Instance.statsEvolved.ToString();
        statsArms.text = statsArms.text + GlobalVars.Instance.statsArms.ToString();

        ShowButtons();
    }


    public void NewGame() {
        SceneManager.LoadScene(1);
    }

    public void ShowStatistics() {
        canvasButtons.gameObject.SetActive(false);
        canvasStats.gameObject.SetActive(true);
        // It's put here so it saves after it tries loading when the game starts urghh.
        GlobalVars.Instance.SavePrefs();
    }

    public void ShowButtons() {
        canvasStats.gameObject.SetActive(false);
        canvasButtons.gameObject.SetActive(true);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
