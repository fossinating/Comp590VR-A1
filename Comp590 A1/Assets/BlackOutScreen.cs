using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BlackOutScreen : MonoBehaviour
{
    bool fadeBlack = false;

    public void fadeToBlack()
    {
        fadeBlack = true;
    }

    public void resetScreen()
    {
        fadeBlack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeBlack)
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, GetComponent<SpriteRenderer>().color.a - 25);
        }
    }
}
