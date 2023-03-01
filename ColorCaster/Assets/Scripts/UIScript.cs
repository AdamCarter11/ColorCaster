using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText, highScoreText;

    private void Start() {
        scoreText.text = "Your score: " + PlayerPrefs.GetInt("score");
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("highscore");
    }
    
    public void RestartGame(){
        SceneManager.LoadScene("SampleScene");
    }
}
