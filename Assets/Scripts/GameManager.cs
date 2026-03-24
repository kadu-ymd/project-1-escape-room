using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Objectives")]
    public bool backpackSocket = false;
    public bool booksSocket = false;
    public bool quiltSocket = false;
    public bool trashbagSocket = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public bool AllObjectivesCompleted()
    {
        return backpackSocket && booksSocket && quiltSocket && trashbagSocket;
    }
}