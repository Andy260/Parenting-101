using UnityEngine;
using System.Collections;

public abstract class Inspector : MonoBehaviour {
	private float timeSpentAssessing = 4.0f;
	private float timeSpentIdling = 4.0f;
	private float currentTimeAssessing;
	private float currentTimeIdling;
	// Use this for initialization
	void Start () 
	{
		currentTimeAssessing = timeSpentAssessing;
		currentTimeIdling = timeSpentIdling;
	}


	protected void UpdateTimer()
	{
		if(currentTime > 0)
		{
			timeSpentAssessing -= Time.deltaTime;
		}
		else
		{
			CompleteAssessment();
		}'
	}

	public virtual void CompleteAssessment();
}
