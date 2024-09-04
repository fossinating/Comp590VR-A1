using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeline_script : MonoBehaviour
{
    [SerializeField] public GameObject[] enableObjects;

    private void OnTriggerEnter(Collider other)
    {
        foreach(GameObject obj in enableObjects)
        {
            obj.SetActive(true);
        }
    }
}
