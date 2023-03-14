using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPhysics : MonoBehaviour
{
    private Rigidbody2D rb;
    private ScoringSystem player;

    [SerializeField] private float forceValue;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.position * -forceValue, ForceMode2D.Impulse );

        //transform.position += new Vector3(transform.position.x * -forceValue, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player = collision.GetComponent<ScoringSystem>();
            player.playerHealth -= 1;
            gameObject.SetActive(false);
            print("Hit Player");
             
        }
    }
}
