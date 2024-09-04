using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class FadeCanvas : MonoBehaviour
{
    bool fadeBlack = false;
    const float speed = 2f;
    String fadeToSceneName;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<CanvasGroup>().alpha = Mathf.Lerp(GetComponent<CanvasGroup>().alpha, fadeBlack ? 1.0f : 0.0f, Time.deltaTime * speed);

        if (GetComponent<CanvasGroup>().alpha > 0.999f && fadeToSceneName != null)
        {
            SceneManager.LoadScene(fadeToSceneName);
        }
    }
    public void FadeToBlack()
    {
        fadeBlack = true;
    }

    public void FadeToScene(String sceneName)
    {
        fadeBlack = true;
        fadeToSceneName = sceneName;
    }

    public void ResetScreen()
    {
        fadeBlack = false;
    }

}
