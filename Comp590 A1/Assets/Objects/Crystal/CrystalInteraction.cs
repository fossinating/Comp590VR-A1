using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalInteraction : InteractableObject
{
    [SerializeField] GameObject griffin;
    [SerializeField] GameObject crystal;
    public override string GetInteractionDescription(InteractionController source)
    {
        return "Collect crystal shard";
    }

    public override void Interact(InteractionController source)
    {
        griffin.GetComponent<GriffinInteract>().ProgressQuest();
        crystal.SetActive(true);
        gameObject.SetActive(false);
    }

    Vector3 initialPosition;

    public override void Start()
    {
        initialPosition = GetComponent<Transform>().localPosition;
    }

    public void FixedUpdate()
    {
        GetComponent<Transform>().localPosition = initialPosition + Vector3.up*0.3f*Mathf.Sin(Time.time);
    }
}
