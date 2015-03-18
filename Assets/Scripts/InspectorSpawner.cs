using UnityEngine;
using System.Collections;

public class InspectorSpawner : MonoBehaviour {
	public float minTimeToSpawn = 13.0f;
	public float maxTimeToSpawn = 30.0f;
	public float timeBeforeReveal = 4.0f;
	public GameObject inspectorSillouhette;
	public GameObject[] possibleInspectors;
	private float curTimeUntilSpawn;
	private float curTimeUntilReveal;
	// Use this for initialization
	void Start () 
	{
		curTimeUntilSpawn = Random.Range (minTimeToSpawn, maxTimeToSpawn);
		curTimeUntilReveal = timeBeforeReveal;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(curTimeUntilSpawn>0)
		{
			curTimeUntilSpawn -= Time.deltaTime;
		}
		else
		{
			inspectorSillouhette.SetActive(true);
		}

		if(inspectorSillouhette.activeSelf)
		{
			if(curTimeUntilReveal > 0)
			{
				curTimeUntilReveal -= Time.deltaTime;
			}
			else
			{
				inspectorSillouhette.SetActive(false);
				int inspectorIndex = Random.Range(0, possibleInspectors.Length);
				Instantiate(possibleInspectors[inspectorIndex], inspectorSillouhette.gameObject.transform.position, Quaternion.identity);
				curTimeUntilSpawn = Random.Range (minTimeToSpawn, maxTimeToSpawn);
				curTimeUntilReveal = timeBeforeReveal;

			}
		}
	}
}
