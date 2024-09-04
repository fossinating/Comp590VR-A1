using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] public GameObject[] objects;
    [SerializeField] public int threshold;
    [SerializeField] public GameObject[] enableObjects;
    [SerializeField] public GameObject[] disableObjects;
    [SerializeField] public bool disableSelf = false;

    void Update()
    {
        int count = 0;

        foreach (GameObject obj in objects)
        {
            if ( obj.activeSelf )
            {
                count++;
            }
        }

        if (count > threshold)
        {
            foreach (GameObject obj in enableObjects)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in disableObjects)
            {
                obj.SetActive(false);
            }
        } 
    }
}
