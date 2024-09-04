using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKnob : InteractableObject
{
    public override string GetInteractionDescription(InteractionController source)
    {
        return "Open door";
    }

    public override void Interact(InteractionController source)
    {
        if (source != null)
        {
            source.setSubtitle("It's pretty late, I should be staying in my room.", 8);
        }
    }
}
