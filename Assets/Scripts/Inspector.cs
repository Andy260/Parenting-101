using UnityEngine;
using System.Collections;

public abstract class Inspector : MonoBehaviour {
	private float timeToAssess = 4.0f;
	private float timeToIdle = 4.0f;
	private bool assessingCompleted = false;
	// Use this for initialization
	void Start () 
	{

	}


	protected void UpdateTimer()
	{
		if(timeToAssess > 0 & !assessingCompleted)
		{
			timeToAssess -= Time.deltaTime;
		}
		else
		{
			assessingCompleted = true;
			CompleteAssessment();
		}

		if(assessingCompleted)
		{
			if(timeToIdle > 0)
			{
				timeToIdle -= Time.deltaTime;
			}
			else
			{
				Destroy(gameObject);
			}
		}


	}

	public abstract void CompleteAssessment();
}
