using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    private float spawnTimer = 0;
    [SerializeField] private float timeElasped;

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= timeElasped)
        {
            Instantiate(Enemy, transform.position, transform.rotation);

            spawnTimer = 0;

        }

    }
}
