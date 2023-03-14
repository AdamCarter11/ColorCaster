using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private float BulletSpawnTime;
    //[SerializeField] private Vector2 BulletOffset;

    private float BulletTimeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BulletTimeElapsed += Time.deltaTime;

        if(BulletTimeElapsed >= BulletSpawnTime)
        {
            Instantiate(Bullet, transform.position, Quaternion.LookRotation(Vector3.forward, transform.position));

            BulletTimeElapsed = 0;
        }
    }
}
