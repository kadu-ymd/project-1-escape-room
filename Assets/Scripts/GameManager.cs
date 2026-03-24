using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Objetivos")]
    public bool objetivoSocket = false;
    // adicione mais conforme precisar:
    // public bool objetivoB = false;
    // public bool objetivoC = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public bool TodosObjetivosConcluidos()
    {
        return objetivoSocket; // && objetivoB && objetivoC;
    }
}