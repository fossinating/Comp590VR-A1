using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TestDummyTheSecond : InteractableObject
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerCarrier;
    public override string GetInteractionDescription(InteractionController source)
    {
        return "Talk to Testing Dummy The Second";
    }

    public override void Interact(InteractionController source)
    {
        source.GetComponentInParent<DialogController>().PlayDialog(
            new DialogChoiceNode("Testing Dummy The Second", "Welcome to the higher plane! I take it you met my predecessor on the lower plane, would you like to go back?", new DialogOption[]{
                new DialogOption("Sure!", new DialogMessageNode("Testing Dummy The Second", "Sorry to lose you, but I'll send you back now", "FlyCharacterToPlatform", gameObject)),
                new DialogOption("No", new DialogEndNode("Testing Dummy The Second", "Smart decision, you can stick with me for now, but come back if you change your mind!"))
            }
            ));
    }

    private Transform playerOldParent;

    public void FlyCharacterToPlatform()
    {
        playerOldParent = player.transform.parent;
        player.transform.parent = playerCarrier.transform;
        GetComponent<PlayableDirector>().Play();
        player.GetComponent<Rigidbody>().useGravity = false;
    }

    override public void Update()
    {
        if (playerOldParent != null && GetComponent<PlayableDirector>().state != PlayState.Playing) {
            player.transform.parent = playerOldParent;
            playerOldParent = null;
            player.GetComponent<FirstPersonController>().useGravity = true;
            playerCarrier.GetComponent<Transform>().localPosition = Vector3.zero;
        }
    }
}
