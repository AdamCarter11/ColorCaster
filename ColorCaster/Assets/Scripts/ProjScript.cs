using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjScript : MonoBehaviour
{
    float speed = 300;
    float aoe = 4;  //scale value
    float damage = 5;

    private void Start() {
        transform.localScale *= aoe;
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
        Destroy(this.gameObject, 10f);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("enemy")){
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //Destroy(this.gameObject);
        }
        
    }
}
