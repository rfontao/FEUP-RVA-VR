using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketInteractorScaled : XRSocketInteractor
{
    [SerializeField] private float interactableScaleFactor;

    protected override void OnSelectEntered(XRBaseInteractable interactable)
    {
        base.OnSelectEntered(interactable);
        interactable.transform.localScale *= interactableScaleFactor;
    }

    protected override void OnSelectExited(XRBaseInteractable interactable)
    {
        base.OnSelectExited(interactable);
        interactable.transform.localScale /= interactableScaleFactor;
    }
}