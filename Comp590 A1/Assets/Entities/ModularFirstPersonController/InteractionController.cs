using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using static Unity.VisualScripting.Member;

public class InteractionController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        EnhancedTouchSupport.Enable();
    }

    bool IsPressed()
    {
        // Source: https://docs.unity3d.com/Packages/com.unity.inputsystem@1.10/api/UnityEngine.InputSystem.EnhancedTouch.Touch.html
        foreach (var touch in UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches)
        {
            return true;
        }
        return false;
    }
    

    // Update is called once per frame
    void Update()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8 | 1 << 9;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 4, layerMask) && hit.collider.GetComponent<InteractableObject>() != null && hit.distance < hit.collider.GetComponent<InteractableObject>().GetMaxDistance())
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            if (Input.GetMouseButtonDown(0))
            {
                hit.collider.GetComponent<InteractableObject>().Interact(this);
            }
        }
    }
}
