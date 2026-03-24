using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class DoorController : MonoBehaviour
{
    private HingeJoint hingeJoint;
    private Rigidbody rb;

    private void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        rb = GetComponent<Rigidbody>();
        DoorLock();
    }

    public void OpenDoor()
    {
        DoorUnlock();
    }

    private void DoorLock()
    {
        rb.isKinematic = true;
        JointLimits limites = hingeJoint.limits;
        limites.min = 0;
        limites.max = 0;
        hingeJoint.limits = limites;
        hingeJoint.useLimits = true;
    }

    private void DoorUnlock()
    {
        rb.isKinematic = false;
        JointLimits limites = hingeJoint.limits;
        limites.min = -90;
        limites.max = 90;
        hingeJoint.limits = limites;
        hingeJoint.useLimits = true;
    }
}