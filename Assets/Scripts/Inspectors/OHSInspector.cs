using UnityEngine;
using System.Collections;

public class OHSInspector : Inspector {
	private bool areWiresHanging = false;
	private bool isConveyorSmoking = false;
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

		//Check conveyor belt.

		//Check baby loudness.

		//Create score card.
	}
}
