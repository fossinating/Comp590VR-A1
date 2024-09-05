using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] SphericEnemy enemyPrefab;
    float timeLeft;
    float waitTime = 10.0f;
    float radius = 10f;

    // Start is called before the first frame update
    void Start()
    {
    }

    void FixedUpdate()
    {
        timeLeft -= Time.fixedDeltaTime;
        if (timeLeft < 0) {
            SphericEnemy enemy = Instantiate(enemyPrefab);
            waitTime = Mathf.Max(1f, waitTime - .3f);
            timeLeft = waitTime;
        }
    }
}
