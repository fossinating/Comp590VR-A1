using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GriffinInteract : InteractableObject
{
    private int questStage = 0;
    public override string GetInteractionDescription(InteractionController source)
    {
        return "Talk to Griffin";
    }

    public override void Interact(InteractionController source)
    {
        switch (questStage)
        {
            case 0:
                source.GetComponentInParent<DialogController>().PlayDialog(
                new DialogChoiceNode("Griffin", "Greetings! Are you here to help?", new DialogOption[]{
                    new DialogOption("I am!", new DialogChoiceNode("Griffin", "Great! Our power crystal suddenly exploded and shards were spread all over our community. As a result, I've lost most of my magical abilities, but if you could go and collect the pieces we would be forever indebted to you", new DialogOption[] {
                        new DialogOption("I'm in!", new DialogMessageNode("Griffin", "Wonderful! I think one ended up at the end of that path to your left, that should be the easiest for you to get!", "ProgressQuest", gameObject)),
                        new DialogOption("Actually, nevermind.", new DialogEndNode("Griffin", "Oh. If you change your mind, come talk to me again."))})),
                    new DialogOption("No", new DialogEndNode("Griffin", "Oh. If you change your mind, come talk to me again."))
                }
                ));
                break;
            case 1:
                source.GetComponentInParent<DialogController>().PlayDialog(
                new DialogEndNode("Griffin", "There should be a shard at the end of the path to your left, come back when you've collected it."));
                break;
            case 2:
                source.GetComponentInParent<DialogController>().PlayDialog(
                    new DialogMessageNode("Griffin", "Great job! There should be another shard at the end of the path behind me. I was able to set up a magical field on the path with the magic from this shard, so you should be able to get to the end with no issues.", "ProgressQuest", gameObject));
                break;
            case 3:
                source.GetComponentInParent<DialogController>().PlayDialog(
                new DialogEndNode("Griffin", "There should be another shard at the end of the path behind me, come back when you've collected it."));
                break;
            case 4:
                source.GetComponentInParent<DialogController>().PlayDialog(
                    new DialogMessageNode("Griffin", "Excellent! I believe there is another shard at the end of the path to the right. I was able to set up another magical field on the path with the magic from this shard, so you should be able to get to the end with no issues.", "ProgressQuest", gameObject));
                break;
            case 5:
                source.GetComponentInParent<DialogController>().PlayDialog(
                new DialogEndNode("Griffin", "I believe there is another shard at the end of the path to the right, come back when you've collected it."));
                break;
            case 6:
                source.GetComponentInParent<DialogController>().PlayDialog(
                    new DialogMessageNode("Griffin", "Perfect! I should have enough magic gathered to lift you close to one of the last crystals, get it and then come back.", "ProgressQuest", gameObject));
                break;
            case 7:
                source.GetComponentInParent<DialogController>().PlayDialog(
                new DialogMessageNode("Griffin", "You need another lift? Here you go.", "FlyCharacterToPlatform", gameObject));
                break;
            case 8:
                source.GetComponentInParent<DialogController>().PlayDialog(
                    new DialogMessageNode("Griffin", "Perfect! I've gathered enough magic from the shards to repair the magical field that lets us fly around, so you should be able to collect the last two shards above us.", "ProgressQuest", gameObject));
                break;
            case 9:
                source.GetComponentInParent<DialogController>().PlayDialog(
                new DialogEndNode("Griffin", "Get the last shard from above us and then come back."));
                break;
            case 10:
                source.GetComponentInParent<DialogController>().PlayDialog(
                new DialogMessageNode("Griffin", "Thank you so much for collecting the shards! We will forever be thankful, and we hope you can visit again soon.", "ProgressQuest", gameObject));
                break;
        }

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

    public void ProgressQuest()
    {
        questStage++;
        if (questStage == 3)
        {
            middleField.SetActive(true);
        }
        else if (questStage == 5)
        {
            rightField.SetActive(true);
        }
        else if (questStage == 7)
        {
            FlyCharacterToPlatform();
        }
        else if (questStage == 9)
        {
            player.GetComponent<FirstPersonController>().playerCanFly = true;
        }
        else if (questStage == 11)
        {
            player.GetComponentInChildren<FadeCanvas>().FadeToScene("SampleScene");
        }
    }

    public int getQuestStage()
    {
        return questStage;
    }
}
