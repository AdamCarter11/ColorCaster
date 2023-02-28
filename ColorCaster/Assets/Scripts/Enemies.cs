using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemies : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] private int health;
    public ScoringSystem ScoringRef;

    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;

        ScoringRef = FindObjectOfType<ScoringSystem>();
    }

    //Setting the enemy velocity
    private void FixedUpdate()
    {
        if(target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetMoveDirectionAndAngle();

        //When Enemy health is less then zero then disable the gameObject and increase the score
        if(health <= 0)
        {
            gameObject.SetActive(false);
            ScoringRef.scoreValue += 10;
        }

         
    }


    //Sets the MoveDirection and rotation Angle for the enemy, have commented out the rotation angle for now if you wanna uncomment it then you can
    void SetMoveDirectionAndAngle()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //rb.rotation = angle;
            moveDirection = direction;
        }
    }

   
}
