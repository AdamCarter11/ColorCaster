using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherScript : MonoBehaviour
{
    [SerializeField] GameObject rotateAround;
    [SerializeField] float speed;

    private void Update() {
        transform.RotateAround(rotateAround.transform.position, Vector3.forward, speed * Time.deltaTime);
    }
}
