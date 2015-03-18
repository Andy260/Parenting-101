using UnityEngine;
using System.Collections;

public class WelfareInspector : Inspector {
	private bool isBabyHoldingHazard = false;
	private bool isPlayerBeingMean = false;
	public int babyLoudnessLimit = 6;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		UpdateTimer();
	}

	public override void CompleteAssessment()
	{
		//Check if baby is holding hazards.

		//Check if player is mean.

		//Check baby loudnes.

		//Create score card.
	}
}
