using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSlot : InteractableObject
{
    [SerializeField] GameObject properItem;
    bool properItemInPlace = true;
    public override string GetInteractionDescription(InteractionController source)
    {
        if (properItemInPlace) {
            return properItem.GetComponent<InteractableObject>().GetInteractionDescription(source);
        } else
        {
            return "Put away";
        }
    }

    public override void Interact(InteractionController source)
    {
        /*if (properItemInPlace)
        {
            source.setHand(properItem.GetComponent<InteractableObject>());
            properItemInPlace = false;
        }
        else
        {
            if (source.getHeldItem() != properItem)
            {
                source.setSubtitle("That doesn't go here!", 10);
            }
            else
            {
                source.getHeldItem().transform.SetParent(transform);
                source.getHeldItem().transform.localPosition = Vector3.zero;
                source.getHeldItem().transform.localRotation = Quaternion.Euler(0, 0, 0);
                source.getHeldItem().transform.localScale = (float)0.3 * Vector3.one;
                source.setHand(null);
                properItemInPlace = true;
            }
        }*/
        
    }
}
