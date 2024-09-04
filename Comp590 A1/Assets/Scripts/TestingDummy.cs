using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TestingDummy : InteractableObject
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerCarrier;
    public override string GetInteractionDescription(InteractionController source)
    {
        return "Talk to Testing Dummy";
    }

    public override void Interact(InteractionController source)
    {
        source.GetComponentInParent<DialogController>().PlayDialog(
            new DialogChoiceNode("Testing Dummy", "Hello there! Would you like to get to that platform over there?", new DialogOption[]{
                new DialogOption("Of course!", new DialogMessageNode("Testing Dummy", "Glad to hear it, I'll fly you over there now", "FlyCharacterToPlatform", gameObject)),
                new DialogOption("No", new DialogEndNode("Testing Dummy", "Oh. That's a shame, but come back if you ever change your mind!"))
            }
            ));
    }

    private Transform playerOldParent;

    public void FlyCharacterToPlatform()
    {
        Debug.Log(player.transform.parent);
        playerOldParent = player.transform.parent;
        player.transform.parent = playerCarrier.transform;
        GetComponent<PlayableDirector>().Play();
        player.GetComponent<FirstPersonController>().useGravity = false;
        player.GetComponent<FirstPersonController>().SetPlayerCanMove(false);
    }

    override public void Update()
    {
        if (playerOldParent != null && GetComponent<PlayableDirector>().state != PlayState.Playing) {
            player.transform.parent = playerOldParent;
            playerOldParent = null;
            player.GetComponent<FirstPersonController>().useGravity = true;
            player.GetComponent<FirstPersonController>().SetPlayerCanMove(true);
            playerCarrier.GetComponent<Transform>().localPosition = Vector3.zero;
        }
    }
}
