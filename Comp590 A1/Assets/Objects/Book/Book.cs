using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : InteractableObject
{
    [SerializeField] private string bookTitle;
    override public string GetInteractionDescription(InteractionController source)
    {
        return $"Pick up {bookTitle}";
    }

    public override void Interact(InteractionController source)
    {
        source.setHand(this);
    }
}
