using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : InteractableObject
{
    [SerializeField] GameObject fanSwitch;
    [SerializeField] GameObject ceilingLightSwitch;
    [SerializeField] GameObject player;
    public override string GetInteractionDescription(InteractionController source)
    {
        return "Go to bed";
    }

    public override void Interact(InteractionController source)
    {
        if (source.getHeldItem() != null)
        {
            source.setSubtitle("I should put this down before going to bed.", 13);
            return;
        }

        if (!fanSwitch.GetComponent<FanSwitch>().getIsOn())
        {
            source.setSubtitle("I need the fan to be on in order to sleep.", 13);
            return;
        }

        if (ceilingLightSwitch.GetComponent<LightSwitch>().getIsOn())
        {
            source.setSubtitle("I need the ceiling light off in order to sleep.", 13);
            return;
        }

        source.transform.localPosition = new Vector3((float)3.3, (float)-0.48, (float)-4.24);
        source.transform.localRotation = Quaternion.Euler(6, -90, 0);
        source.GetComponentInParent<FirstPersonController>().enabled = false; ;
        source.GetComponentInParent<FirstPersonController>().gameObject.transform.localPosition = new Vector3(0, 1, 0);
        source.GetComponentInParent<FirstPersonController>().gameObject.transform.localRotation = Quaternion.Euler(0,0,0);
        Debug.Log(player);
        Debug.Log(player.GetComponentInChildren<FadeCanvas>());
        player.GetComponentInChildren<FadeCanvas>().FadeToScene("First Dream");
    }
}
