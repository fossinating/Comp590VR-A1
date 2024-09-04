using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FoxInteract : InteractableObject
{
    private bool agreed = false;
    public override string GetInteractionDescription(InteractionController source)
    {
        return "Talk to Fox";
    }

    public override void Interact(InteractionController source)
    {  
        
        
    }

    private Transform playerOldParent;

    public void AgreedToHelp()
    {
        agreed = true;
    }
}
