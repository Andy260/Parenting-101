using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamescoreManager : MonoBehaviour 
{
	public GameObject _highscoreDisplay;
	public int _score;

	void Start () 
	{
		
	}

	void Update () 
	{
		// Update score display
		_highscoreDisplay.GetComponent<TextMesh>().text = "Score: " + _score.ToString ();
	}

	public void AddScore(int a_score)
	{
		_score += a_score;
	}

	public void Gameover()
	{
		// Save new score if higher than saved score
		int savedScore = PlayerPrefs.GetInt ("p101_highscore");
		if (savedScore < _score)
		{
			PlayerPrefs.SetInt("p101_highscore", _score);
		}

		// Change level
		Application.LoadLevel ("MenuState");
	}
}
