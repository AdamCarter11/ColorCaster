using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testLaunch : MonoBehaviour
{
    [SerializeField] GameObject projToShoot;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(projToShoot, transform.position, transform.rotation);
        }
    }
}
