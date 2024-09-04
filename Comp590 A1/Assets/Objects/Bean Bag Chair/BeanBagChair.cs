using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanBagChair : InteractableObject
{
    [SerializeField] GameObject seat;
    public override string GetInteractionDescription(InteractionController source)
    {
        return "Sit in bean bag chair";
    }

    public override void Interact(InteractionController source)
    {
        source.sitOnObject(seat);
    }
}
