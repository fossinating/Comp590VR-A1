using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphericEnemy : MonoBehaviour
{
    // https://discussions.unity.com/t/how-can-i-make-movement-on-a-sphere/12686/3
    private const float radius = 11;
    private float xAngle;
    private float angle;
    private const float speed = 3f;

    void Start()
    {
        float randAngle = Random.Range(0, 2 * Mathf.PI);
        Debug.Log(
            radius + ", " +
            Mathf.Sin(randAngle) + ", " +
            radius * Mathf.Sin(randAngle) + ", " +
            0 + ", " +
            radius * Mathf.Cos(randAngle));
        transform.position = new Vector3(
            radius * Mathf.Sin(randAngle),
            0,
            radius * Mathf.Cos(randAngle));
        angle = Mathf.Atan(transform.position.z / transform.position.x);
        xAngle = Mathf.Atan(transform.position.y / radius);
    }

    void FixedUpdate()
    {
        xAngle += speed / radius * Time.fixedDeltaTime;

        float h = radius * Mathf.Cos(xAngle);

        transform.position = new Vector3(
            h * Mathf.Cos(angle),
            radius * Mathf.Sin(xAngle),
            h * Mathf.Sin(angle));

        transform.up = transform.position.normalized;
    }
}
