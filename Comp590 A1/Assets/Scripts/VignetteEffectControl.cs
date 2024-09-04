using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignetteEffectControl : MonoBehaviour
{
    public PostProcessProfile postProcessProfile;

    private Vignette vignette;

    private void Start()
    {
        if (postProcessProfile == null)
        {
            Debug.LogError("Post Process Profile not assigned!");
            return;
        }

        postProcessProfile.TryGetSettings(out vignette);
    }

    private bool fading = false;

    const float speed = .5f;

    private void Update()
    {
        if (vignette != null)
        {
            // Check if the 'P' key is pressed
            if (Input.GetKeyDown(KeyCode.P))
            {
                fading = !fading;
            }
            // Modify vignette intensity dynamically
            vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, fading ? 1.0f : 0.0f, Time.deltaTime*speed);
        }
    }
}
