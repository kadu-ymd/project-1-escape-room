using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("FirstRoom");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
