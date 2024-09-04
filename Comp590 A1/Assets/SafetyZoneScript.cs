using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyZoneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<FirstPersonController>()  != null)
        {
            other.GetComponent<Transform>().localPosition = new Vector3(1018f, 165f, -373f);
        }
    }
}
