using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    private Text text;
    private int score;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        if (PlayerPrefs.HasKey("score"))
        {
            score = PlayerPrefs.GetInt("score");
            text.text = "Points: " + score.ToString();
        }
	}

    void Update(){
        score = PlayerPrefs.GetInt("score");
        text.text = "Points: "+score.ToString();
    }
}
