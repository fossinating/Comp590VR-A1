using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Player"))
        {
            go.GetComponent<FirstPersonController>().enabled = false;
            Debug.Log("No more movement");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                go.GetComponent<FirstPersonController>().enabled = true;
                Debug.Log("Movement");
            }
        }
    }
}
