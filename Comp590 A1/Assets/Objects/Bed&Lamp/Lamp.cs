using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : InteractableObject
{
    [SerializeField] Material onMaterial;
    [SerializeField] Material offMaterial;


    [SerializeField] public GameObject Light;
    public override string GetInteractionDescription(InteractionController source)
    {
        return $"Turn lamp o{(Light.activeSelf ? "ff" : "n")}";
    }

    public override void Interact(InteractionController source)
    {
        Light.SetActive(!Light.activeSelf);
        Material mat = this.GetComponent<Renderer>().material = Light.activeSelf ? onMaterial : offMaterial;
    }
}
