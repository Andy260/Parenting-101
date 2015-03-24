using UnityEngine;
using System.Collections;

public class Supervisor : Inspector {
	private bool isQuotaMet = false;
	private bool areObjectsCorrectlySorted = false;
    private int quota = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		UpdateTimer();
	}

	public override void CompleteAssessment()
	{

		//TODO: Check objects are in correct boxes.

        //TODO: Check object quota is met.

        GameObject scoreCard = (GameObject)Instantiate(Resources.Load<GameObject>("ScoreCard"), gameObject.transform.position, Quaternion.identity);
        scoreCard.GetComponent<ScoreCard>().lineText[0].GetComponent<TextMesh>().text = "Objects sorted correctly:";
        scoreCard.GetComponent<ScoreCard>().lineText[1].GetComponent<TextMesh>().text = "Quota of " + quota.ToString() + " was met:";

        if (areObjectsCorrectlySorted)
        {
            //Player succeeded.
            scoreCard.GetComponent<ScoreCard>().resultText[0].GetComponent<TextMesh>().text = "Completed";
        }
        else
        {
            //Player loses life.
            scoreCard.GetComponent<ScoreCard>().resultText[0].GetComponent<TextMesh>().text = "Failed";
        }

        if (isQuotaMet)
        {
            //Player succeeded.
            scoreCard.GetComponent<ScoreCard>().resultText[1].GetComponent<TextMesh>().text = "Completed";
        }
        else
        {
            //Player loses life.
            scoreCard.GetComponent<ScoreCard>().resultText[1].GetComponent<TextMesh>().text = "Failed";
        }
	}
}
