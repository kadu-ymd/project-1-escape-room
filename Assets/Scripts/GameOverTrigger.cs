using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class GameOverTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerTag"))
        {
            Debug.Log("Game Over!");

            HandleGameOver();
        }
    }

    void HandleGameOver()
    {
         SceneManager.LoadScene("GameOverMenu");
    }
}
