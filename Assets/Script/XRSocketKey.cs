using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketKey : XRSocketInteractor
{
    public string KeyName = string.Empty;
    public override bool CanHover(XRBaseInteractable interactable)
    {
        return base.CanHover(interactable) && MatchUsingName(interactable);
    }
    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return base.CanSelect(interactable) && MatchUsingName(interactable);
    }
    private bool MatchUsingName(XRBaseInteractable interactable){
        return interactable.name.Equals(KeyName);
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args){
        args.interactable.GetComponent<MeshCollider>().enabled = false;
    }
    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
    }
}
