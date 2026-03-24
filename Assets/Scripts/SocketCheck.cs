using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class SocketChecker : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor socket;
    [SerializeField] private DoorController porta;

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

        if (attachedObject.CompareTag("BackpackTag"))
            GameManager.Instance.backpackSocket = true;
        else if (attachedObject.CompareTag("BooksTag"))
            GameManager.Instance.booksSocket = true;
        else if (attachedObject.CompareTag("QuiltTag"))
            GameManager.Instance.quiltSocket = true;
        else if (attachedObject.CompareTag("TrashBagTag"))
            GameManager.Instance.trashbagSocket = true;

        ExitCheck();
    }

    private void OnDettach(SelectExitEventArgs args)
    {
        GameObject attachedObject = (args.interactableObject as MonoBehaviour)?.gameObject;

        if (attachedObject.CompareTag("BackpackTag"))
            GameManager.Instance.backpackSocket = false;
        else if (attachedObject.CompareTag("BooksTag"))
            GameManager.Instance.booksSocket = false;
        else if (attachedObject.CompareTag("QuiltTag"))
            GameManager.Instance.quiltSocket = false;
        else if (attachedObject.CompareTag("TrashBagTag"))
            GameManager.Instance.trashbagSocket = false;
    }

    private void ExitCheck()
    {
        if (GameManager.Instance.AllObjectivesCompleted())
        {
            porta.OpenDoor();
        }
    }
}