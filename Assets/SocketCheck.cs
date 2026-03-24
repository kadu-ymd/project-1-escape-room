using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class SocketChecker : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor socket;

    private void OnEnable()
    {
        socket.selectEntered.AddListener(OnEncaixou);
        socket.selectExited.AddListener(OnDesencaixou);
    }

    private void OnDisable()
    {
        socket.selectEntered.RemoveListener(OnEncaixou);
        socket.selectExited.RemoveListener(OnDesencaixou);
    }

    private void OnEncaixou(SelectEnterEventArgs args)
    {
        GameManager.Instance.objetivoSocket = true;
        VerificarSaida();
    }

    private void OnDesencaixou(SelectExitEventArgs args)
    {
        GameManager.Instance.objetivoSocket = false;
    }

    private void VerificarSaida()
    {
        if (GameManager.Instance.TodosObjetivosConcluidos())
        {
            Debug.Log("Todos objetivos cumpridos! Liberar saída.");
            // acione aqui a porta, um evento, animação, etc.
        }
    }
}