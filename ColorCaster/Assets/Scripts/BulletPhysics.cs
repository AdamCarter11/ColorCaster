using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPhysics : MonoBehaviour
{
    private Rigidbody2D rb;
    private SampleMessageListener resetSeq;

    [SerializeField] private float forceValue;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        resetSeq = GameObject.FindGameObjectWithTag("listener").GetComponent<SampleMessageListener>();
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
            resetSeq.resetColorSequence();
            gameObject.SetActive(false);
            print("Hit Player");
             
        }
    }
}
