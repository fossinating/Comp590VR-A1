using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] public int pointValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit()
    {
        transform.parent.GetComponentInChildren<GameManager>().AddPoints(pointValue);
        Destroy(gameObject);
    }
}
