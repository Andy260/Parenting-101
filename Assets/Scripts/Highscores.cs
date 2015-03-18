using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HighScores : MonoBehaviour 
{
    // Current score
    int _score;
    bool newSave;

	void Start () 
    {
        if (PlayerPrefs.HasKey("highscore"))
            _score = PlayerPrefs.GetInt("highscore");
        else
            _score = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    void SaveScore()
    {
        PlayerPrefs.SetInt("highscore", _score);
    }

    public int GetScore()
    {
        return _score;
    }

    public void AddScore(int a_score)
    {
        if (a_score > _score)
            _score = a_score;

        SaveScore();
    }
}
