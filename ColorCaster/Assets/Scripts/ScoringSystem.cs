using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    [SerializeField] private Text ScoreValueUI;
    internal int scoreValue = 0;
    [SerializeField] int playerHealth;

    // Update is called once per frame
    void Update()
    {
        ScoreValueUI.text = scoreValue.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("enemy")){
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            playerHealth--;
            if(playerHealth <= 0){
                //player loses
                print("GAME OVER");
            }
        }
    }
}
