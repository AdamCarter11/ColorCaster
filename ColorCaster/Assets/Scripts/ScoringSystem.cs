using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoringSystem : MonoBehaviour
{
    [SerializeField] private Text ScoreValueUI;
    internal int scoreValue = 0;
    int multi = 1;
    [SerializeField] internal int playerHealth;
    Camera cam;

    private void Start() {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        if(!PlayerPrefs.HasKey("highscore")){
            PlayerPrefs.SetInt("highscore", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ScoreValueUI.text = scoreValue.ToString();
    }
    public void resetMulti(){
        multi = 1;
    }
    public void increaseMulti(){
        multi++;
    }
    public void increaseScore(int increaseVal){
        scoreValue = scoreValue + (increaseVal * multi);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("enemy")){
            cam.GetComponent<ScreenShake>().TriggerShake();
            StartCoroutine(backgroundColor());
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            playerHealth--;
            if(playerHealth <= 0){
                //player loses
                PlayerPrefs.SetInt("score", scoreValue);
                if(scoreValue > PlayerPrefs.GetInt("highscore")){
                    PlayerPrefs.SetInt("highscore", scoreValue);
                }
                print("GAME OVER");
                SceneManager.LoadScene("GameOver");
            }   
        }
    }
    IEnumerator backgroundColor(){
        cam.backgroundColor = new Color(255.0f/255, 87.0f/255, 51.0f/255);
        yield return new WaitForSeconds(.3f);
        cam.backgroundColor = new Color(195.0f/255, 195.0f/255, 195.0f/255);
    }
}
