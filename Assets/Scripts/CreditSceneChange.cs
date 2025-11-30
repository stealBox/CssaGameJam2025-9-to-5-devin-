using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditSceneChange : MonoBehaviour
{
    public void QuitCredits()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
