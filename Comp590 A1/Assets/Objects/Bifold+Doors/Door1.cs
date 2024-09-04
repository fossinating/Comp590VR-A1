using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RightDoor : InteractableObject
{
    private bool open = false;
    [SerializeField] GameObject doorA;
    [SerializeField] GameObject doorB;
    public override string GetInteractionDescription(InteractionController source)
    {
        return $"{(open ? "Close" : "Open")} door.";
    }

    public override void Interact(InteractionController source)
    {
        open = !open;
        doorA.transform.SetLocalPositionAndRotation(open ? new Vector3((float)-27.8125, 0, 0) : new Vector3((float)-27.8125, 0, 0), Quaternion.Euler(-180, 0, open ? 80 : 0));
        doorB.transform.SetLocalPositionAndRotation(open ? new Vector3((float)-22.3, (float)-13.65, 0) : new Vector3((float)-13.875, 0,0), Quaternion.Euler(-180, 0, open ? -80 : 0));
    }
}
