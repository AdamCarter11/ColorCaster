using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ForceField : MonoBehaviour
{
    
    private bool isForceField = false;
    private float forceFieldTimer = 0;
    private int forceFieldValue = 100;
    


    //private float shield
    [SerializeField] private ForceFieldSlider slider;
    [SerializeField] private float forceFiedDuration = 0;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private SpriteRenderer ForceFieldSprite;
    [SerializeField] private GameObject ForceFieldGameObject;



    // Start is called before the first frame update
    void Start()
    {
        slider = FindObjectOfType<ForceFieldSlider>();

        slider.SetMaxForceField(forceFieldValue);

    }

    // Update is called once per frame
    void Update()
    {
        ForceFieldFunctionality();

        slider.SetForceFieldValue(forceFieldValue);
    }

    void ForceFieldFunctionality()
    {
        if (Input.GetKeyDown(KeyCode.D) && forceFieldTimer == 0 && forceFieldValue > 0)
        {

            isForceField = true;

            forceFieldValue -= 10;

            

           

            

            //ForceFieldSprite.col

        }
        
        if (isForceField == true)
        {
            forceFieldTimer += Time.deltaTime;

            SpawnForceField();
           
        }
        else
        {
            ForceFieldGameObject.SetActive(false);
        }

        if (forceFieldTimer >= forceFiedDuration)
        {

            isForceField = false;

            forceFieldTimer = 0;

        }
    }

    void SpawnForceField()
    {
        RaycastHit2D hitInfo;
        hitInfo = Physics2D.CircleCast(transform.position, radius, Vector2.one, playerLayer);
        ForceFieldGameObject.SetActive(true);

        //ForceFieldGameObject.gameObject.transform.localScale = new Vector3(Mathf.Lerp(0, 0.5f, Time.deltaTime*5), Mathf.Lerp(0, 0.5f, Time.deltaTime*5), Mathf.Lerp(0, 0.5f, Time.deltaTime * 5));

        if (hitInfo.collider != null)
        {
            if(hitInfo.collider.name != "Player")
            {
                hitInfo.collider.gameObject.SetActive(false);

                Debug.Log(hitInfo.collider.name);

            }
        }

    }

}
