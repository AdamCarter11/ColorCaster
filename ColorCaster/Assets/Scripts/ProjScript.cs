using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjScript : MonoBehaviour
{
    [SerializeField] float speed = 300;
    [SerializeField] float aoeX, aoeY;  //scale value
    [SerializeField] int damage;
    [SerializeField] float destructionDelay;
    [SerializeField] int pierceHealth;

    private void Start() {
        transform.localScale = new Vector2(transform.localScale.x * aoeX, transform.localScale.y * aoeY);
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
        Destroy(this.gameObject, 10f);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("enemy")){
            //if we want to freeze the projectile for a bit (fire aoe thing)
            //this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            
            other.gameObject.GetComponent<Enemies>().TakeDamage(damage);
            pierceHealth--;
            if(pierceHealth <= 0){
                Destroy(this.gameObject, destructionDelay);
            }
            
        }
        
    }
    
}
