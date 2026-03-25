using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Dictionary<string, bool> objectives = new Dictionary<string, bool>();

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;

        objectives.Add("backpackSocket", false);
        objectives.Add("booksSocket", false);
        objectives.Add("quiltSocket", false);

        objectives.Add("redCardSocket", false);
        objectives.Add("blueCardSocket", false);
        objectives.Add("yellowCardSocket", false);
        objectives.Add("greenCardSocket", false);
    }

    public void SetObjective(string id, bool valor)
    {
        if (objectives.ContainsKey(id))
            objectives[id] = valor;
            Debug.Log($"Objective {id} set to {valor}");
    }

    public bool AllObjectivesCompleted()
    {
        foreach (var objective in objectives)
        {
            Debug.Log("Checking objective: " + objective.Key + objective.Value);

            if (!objective.Value)
            {
                Debug.Log("Not all objectives completed yet");
                return false;
            }
        }
            
        return true;
    }
}