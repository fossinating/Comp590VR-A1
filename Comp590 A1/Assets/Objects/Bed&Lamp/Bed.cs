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
