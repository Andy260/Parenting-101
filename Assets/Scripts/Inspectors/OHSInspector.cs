using UnityEngine;
using System.Collections;

public class OHSInspector : Inspector {
	private bool areWiresHanging = false;
	private bool isConveyorSmoking = false;
	private bool babyIsTooLoud = false;
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
        //Machine smoking check
        isConveyorSmoking = GameObject.Find("Hazards").GetComponent<Hazards>()._leaverActivated;

        //Wires check.
        areWiresHanging = GameObject.Find("Hazards").GetComponent<Hazards>()._wiresActivated;

		int babyVolume = GameObject.Find ("Baby").GetComponent<Baby>().loudness;
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
