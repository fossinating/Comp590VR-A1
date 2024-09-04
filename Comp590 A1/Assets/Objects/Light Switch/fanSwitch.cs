using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FanSwitch : InteractableObject
{
    [SerializeField] GameObject fan;
    [SerializeField] bool on = false;
    float position;

    override public string GetInteractionDescription(InteractionController source)
    {
        return $"Turn fan {(on ? "off": "on")}";
    }

    public override void Interact(InteractionController source)
    {
        on = !on;
        fan.GetComponent<Fan_Rotation>().setOn(on);
    }

    public override void Start()
    {
        position = on ? -50 : 50;
    }

    public override void Update()
    {
        position = Mathf.Clamp(position + 250 * Time.deltaTime * (on ? -1 : 1), -50, 50);
        transform.rotation = Quaternion.Euler(position, 180, 0);
    }

    public bool getIsOn() { return on; }
}
