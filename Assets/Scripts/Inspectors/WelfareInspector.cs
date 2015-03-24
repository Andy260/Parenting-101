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
        //Checks if baby is holiding hazardous item
		isBabyHoldingHazard = GameObject.Find ("Baby").GetComponent<Baby> ().dangerousGoods;

        //Did player hit baby in the presence of welfare inspector
		isPlayerBeingMean = GameObject.Find ("Baby").GetComponent<Baby> ().babyGotHit;
		GameObject.Find ("Baby").GetComponent<Baby> ().StopCheckingForBabyHit();

        //Is baby being really loud.
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
        GameObject scoreCard = (GameObject)Instantiate(Resources.Load<GameObject>("ScoreCard"), gameObject.transform.position, Quaternion.identity);
        scoreCard.GetComponent<ScoreCard>().lineText[0].GetComponent<TextMesh>().text = "Baby holding anything dangerous?";
        scoreCard.GetComponent<ScoreCard>().lineText[1].GetComponent<TextMesh>().text = "Child harmed at all?";
        scoreCard.GetComponent<ScoreCard>().lineText[2].GetComponent<TextMesh>().text = "Baby being really loud?";

        if (!isBabyHoldingHazard)
        {
            //Player succeeded.
            scoreCard.GetComponent<ScoreCard>().resultText[0].GetComponent<TextMesh>().text = "Completed";
        }
        else
        {
            //Player loses life.
            scoreCard.GetComponent<ScoreCard>().resultText[0].GetComponent<TextMesh>().text = "Failed";
        }

        if (!isPlayerBeingMean)
        {
            //Player succeeded.
            scoreCard.GetComponent<ScoreCard>().resultText[1].GetComponent<TextMesh>().text = "Completed";
        }
        else
        {
            //Player loses life.
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
            scoreCard.GetComponent<ScoreCard>().resultText[2].GetComponent<TextMesh>().text = "Failed";
        }
	}
}
