using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Filtering;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class TagTargetFilter : XRBaseTargetFilter
{
    [SerializeField] private string tagPermitida;

    public override void Process(IXRInteractor interactor, List<IXRInteractable> targets, List<IXRInteractable> results)
    {
        results.Clear();

        foreach (var interactable in targets)
        {
            if (interactable.transform.CompareTag(tagPermitida))
            {
                results.Add(interactable);
            }
        }
    }
}