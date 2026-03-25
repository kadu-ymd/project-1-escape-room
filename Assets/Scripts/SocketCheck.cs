using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class SocketChecker : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor socket;
    [SerializeField] private DoorController doorController;
    [SerializeField] private string expectedTag;
    [SerializeField] private string objectiveIdentifier;

    private void OnEnable()
    {
        socket.selectEntered.AddListener(OnAttach);
        socket.selectExited.AddListener(OnDettach);
    }

    private void OnDisable()
    {
        socket.selectEntered.RemoveListener(OnAttach);
        socket.selectExited.RemoveListener(OnDettach);
    }

    private void OnAttach(SelectEnterEventArgs args)
    {
        GameObject attachedObject = (args.interactableObject as MonoBehaviour)?.gameObject;

        if (attachedObject.CompareTag(expectedTag))
        {
            GameManager.Instance.SetObjective(objectiveIdentifier, true);
            Debug.Log($"Objective {objectiveIdentifier} completed!");
            ExitCheck();
        }
    }

    private void OnDettach(SelectExitEventArgs args)
    {
        GameObject attachedObject = (args.interactableObject as MonoBehaviour)?.gameObject;

        if (attachedObject.CompareTag(expectedTag))
        {
            GameManager.Instance.SetObjective(objectiveIdentifier, false);
        }
    }

    private void ExitCheck()
    {
        if (GameManager.Instance.AllObjectivesCompleted())
        {
            Debug.Log("All objectives completed! Opening the door...");
            doorController.OpenDoor();
        }
    }
}