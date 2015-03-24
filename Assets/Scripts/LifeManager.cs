using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour 
{
	int ohsLives = 3;
	int supervisorLives = 3;
	int welfareLives = 3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoseOHSLife()
	{
		if(ohsLives > 1)
		{
			ohsLives -= 1;
		}
		else
		{
			GameObject.Find("SceneManager").GetComponent<GameScoreManager>().Gameover();
		}
	}

	public void LoseSupervisorLife()
	{
		if(supervisorLives > 1)
		{
			supervisorLives -= 1;
		}
		else
		{
			GameObject.Find("SceneManager").GetComponent<GameScoreManager>().Gameover();
		}
	}

	public void LoseWelfareLife()
	{
		if(welfareLives > 1)
		{
			welfareLives -= 1;
		}
		else
		{
			GameObject.Find("SceneManager").GetComponent<GameScoreManager>().Gameover();
		}
	}
}
