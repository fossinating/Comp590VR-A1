using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : InteractableObject
{
    private bool open = false;
    [SerializeField] GameObject doorRoot;
    [SerializeField] GameObject doorB;
    public override string GetInteractionDescription(InteractionController source)
    {
        return $"{(open ? "Close" : "Open")} door.";
    }

    public override void Interact(InteractionController source)
    {
        open = !open;
        doorRoot.transform.localRotation = Quaternion.Euler(0, 0, open ? 80 : 0);
        doorB.transform.SetLocalPositionAndRotation(open ? new Vector3((float)-14.1, (float)3.1, 0) : new Vector3(-14, 0,0), Quaternion.Euler(0, 0, open ? -170 : 0));
    }
}
