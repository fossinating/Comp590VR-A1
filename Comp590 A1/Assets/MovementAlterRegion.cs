using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAlterRegion : MonoBehaviour
{
    [SerializeField] public float walkBoost = 0.0f;
    [SerializeField] public float sprintBoost = 0.0f;
    [SerializeField] public float jumpBoost = 0.0f;
    [SerializeField] public float gravityMultiplier = 1.0f;
    [SerializeField] public bool enableFlight = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonController>() != null)
        {
            other.GetComponent<FirstPersonController>().sprintSpeed += sprintBoost;
            other.GetComponent<FirstPersonController>().walkSpeed += walkBoost;
            other.GetComponent<FirstPersonController>().jumpPower += jumpBoost;
            other.GetComponent<FirstPersonController>().gravityPower *= gravityMultiplier;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<FirstPersonController>() != null)
        {
            other.GetComponent<FirstPersonController>().walkSpeed -= walkBoost;
            other.GetComponent<FirstPersonController>().sprintSpeed -= sprintBoost;
            other.GetComponent<FirstPersonController>().jumpPower -= jumpBoost;
            other.GetComponent<FirstPersonController>().gravityPower /= gravityMultiplier;
        }
    }
}
