using UnityEngine;
using System.Collections;

public class WelfareInspector : Inspector {
	private bool isBabyHoldingHazard = false;
	private bool isPlayerBeingMean = false;
	private bool babyIsTooLoud = false;
	public int babyLoudnessLimit = 6;
	// Use this for initialization
	void Start () 
	{
		GameObject.Find ("Baby").GetComponent<Baby> ().CheckForBabyHit ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		UpdateTimer();
	}

	public override void CompleteAssessment()
	{
		isBabyHoldingHazard = GameObject.Find ("Baby").GetComponent<Baby> ().dangerousGoods;

		isPlayerBeingMean = GameObject.Find ("Baby").GetComponent<Baby> ().babyGotHit;
		GameObject.Find ("Baby").GetComponent<Baby> ().StopCheckingForBabyHit();

		int babyVolume = GameObject.Find ("Baby").GetComponent<Baby>.loudness;
		if(babyVolume >= babyLoudnessLimit)
		{
			babyIsTooLoud = true;
		}
		else
		{
			babyIsTooLoud = false;
		}

		//Create score card.
	}
}
