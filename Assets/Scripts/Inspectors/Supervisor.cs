using UnityEngine;
using System.Collections;

public class Supervisor : Inspector {
	private bool isQuotaMet = false;
	private bool areObjectsMisplaced = false;
	public int babyLoudnessLimit = 6;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		UpdateTimer();
	}

	public override void CompleteAssessment()
	{
		//Check wires.

		//Check cobjects are in correct boxes.

		//Check baby loudness.

		//Create score card.
	}
}
