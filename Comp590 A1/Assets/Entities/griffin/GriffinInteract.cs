using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GriffinInteract : InteractableObject
{
    public override string GetInteractionDescription(InteractionController source)
    {
        return "Talk to Griffin";
    }

    public override void Interact(InteractionController source)
    {
        FlyCharacterToPlatform();
    }

    [SerializeField] GameObject middleField;
    [SerializeField] GameObject rightField;
    [SerializeField] GameObject player;

    [SerializeField] private GameObject playerCarrier;

    private Transform playerOldParent;

    public void FlyCharacterToPlatform()
    {
        playerOldParent = player.transform.parent;
        player.transform.parent = playerCarrier.transform;
        GetComponent<PlayableDirector>().Play();
        player.GetComponent<FirstPersonController>().useGravity = false;
    }

    override public void Update()
    {
        if (playerOldParent != null && GetComponent<PlayableDirector>().state != PlayState.Playing)
        {
            player.transform.parent = playerOldParent;
            playerOldParent = null;
            player.GetComponent<FirstPersonController>().useGravity = true;
            playerCarrier.GetComponent<Transform>().localPosition = Vector3.zero;
        }
    }
}
