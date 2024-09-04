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
        if (!agreed)
        {
            source.GetComponentInParent<DialogController>().PlayDialog(
            new DialogChoiceNode("Fox", "Hello There! Can you help us?", new DialogOption[]{
                new DialogOption("Of course!", new DialogMessageNode("Fox", "Thank you! Go talk to Griffin at the shrine, they can tell you more", "AgreedToHelp", gameObject)),
                new DialogOption("No", new DialogEndNode("Fox", "Oh. That's a shame, but come back if you ever change your mind!"))
            }
            ));
        } else
        {
            source.GetComponentInParent<DialogController>().PlayDialog(
            new DialogEndNode("Fox", "Go to Griffin at the shrine to get more information about how to help us!"));
        }
        
    }

    private Transform playerOldParent;

    public void AgreedToHelp()
    {
        agreed = true;
    }
}
