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
		GameObject scoreCard = (GameObject)Instantiate(Resources.Load<GameObject>("ScoreCard"), GameObject.Find("ScoreCardSpawnSpot").transform.position, Quaternion.identity);
		scoreCard.GetComponent<ScoreCard>().lineText[0].GetComponent<TextMesh>().text = "Wires hanging?";
		scoreCard.GetComponent<ScoreCard>().lineText[1].GetComponent<TextMesh>().text = "Conveyor smoking?";
		scoreCard.GetComponent<ScoreCard>().lineText[2].GetComponent<TextMesh>().text = "Baby being loud?";
		
		if (!areWiresHanging)
		{
			//Player succeeded.
			scoreCard.GetComponent<ScoreCard>().resultText[0].GetComponent<TextMesh>().text = "Completed";
		}
		else
		{
			//Player loses life.
			GameObject.Find("InspectorSpawner").GetComponent<LifeManager>().LoseOHSLife();
			scoreCard.GetComponent<ScoreCard>().resultText[0].GetComponent<TextMesh>().text = "Failed";
		}
		
		if (!isConveyorSmoking)
		{
			//Player succeeded.
			scoreCard.GetComponent<ScoreCard>().resultText[1].GetComponent<TextMesh>().text = "Completed";
		}
		else
		{
			//Player loses life.
			GameObject.Find("InspectorSpawner").GetComponent<LifeManager>().LoseOHSLife();
			scoreCard.GetComponent<ScoreCard>().resultText[1].GetComponent<TextMesh>().text = "Failed";
		}
		
		if (!babyIsTooLoud)
		{
			//Player succeeded.
			scoreCard.GetComponent<ScoreCard>().resultText[2].GetComponent<TextMesh>().text = "Completed";
		}
		else
		{
			//Player loses life.
			GameObject.Find("InspectorSpawner").GetComponent<LifeManager>().LoseOHSLife();
			scoreCard.GetComponent<ScoreCard>().resultText[2].GetComponent<TextMesh>().text = "Failed";
		}
	}
}


