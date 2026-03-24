using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Filtering;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class BackpackFilter : XRBaseTargetFilter
{
    [SerializeField] private string tagPermitida = "BackpackTag";

    // Removido o método Process(IXRInteractor, IXRInteractable) pois não existe na base para sobrescrever

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