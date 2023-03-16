using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemies : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] internal int health;
    [SerializeField] ParticleSystem ps;
    public ScoringSystem ScoringRef;

    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    Camera cam;
    float randoSpeedMulti;

    //color enemy types (for now just do RGB)
    string whatColor;
    [SerializeField] string[] colors;


    private void Awake()
    {
        randoSpeedMulti = Random.Range(.9f, 2.0f);
        rb = GetComponent<Rigidbody2D>();
        whatColor = colors[Random.Range(0,colors.Length)];
        if(whatColor == "red"){
            GetComponent<SpriteRenderer>().color = Color.red;
            health = 5;
            moveSpeed = moveSpeed * .5f;
            transform.localScale *= 2;
        }
        else if(whatColor == "green"){
            GetComponent<SpriteRenderer>().color = Color.green;
            health = 3;
            moveSpeed = moveSpeed * .8f;
            transform.localScale *= 1.2f;
        }
        else if(whatColor == "blue"){
            GetComponent<SpriteRenderer>().color = Color.blue;
            health = 1;
            moveSpeed = moveSpeed * 1.1f;
            //transform.localScale *= .7f;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;

        ScoringRef = FindObjectOfType<ScoringSystem>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    //Setting the enemy velocity
    private void FixedUpdate()
    {
        if(target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed * randoSpeedMulti;
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

    public void TriggerColorAction(string colorSent){
        if(colorSent == whatColor){
            //trigger destruction of enemy
            Instantiate(ps, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            ScoringRef.increaseMulti();
            ScoringRef.increaseScore(10);
        }
    }
    public void TakeDamage(int damage){
        health -= damage;
        if(health < 0){
            ScoringRef.scoreValue += 10;
            Instantiate(ps, transform.position, Quaternion.identity);
            ScoringRef.increaseMulti();
            ScoringRef.increaseScore(10);
            gameObject.SetActive(false);
        }
    }
}
