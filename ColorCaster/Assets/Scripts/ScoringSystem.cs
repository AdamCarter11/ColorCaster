using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    [SerializeField] private Text ScoreValueUI;
    internal int scoreValue = 0;

    // Update is called once per frame
    void Update()
    {
        ScoreValueUI.text = scoreValue.ToString();
    }
}
