using UnityEngine;
using UnityEditor;
using System.Collections;

public class ConveyerSpawn : MonoBehaviour
{
    public GameObject[] objectList;
    public Sprite[] spriteList;
	public Transform [] spawnPoints; // Added
    public float spawnTime;
	public Transform [] laneList;
	public float conveyorSpeed; // Added

    float initialTime;
    
	// Use this for initialization
	void Start()
    {
		SpawnItem (); // Added so I could debug more quickly
        initialTime = spawnTime;
	}
	
	// Update is called once per frame
	void Update()
    {
        spawnTime -= Time.deltaTime;

        if(spawnTime <= 0)
        {
            SpawnItem();
            spawnTime = initialTime;

        }
	}

    void SpawnItem()
    {
        int objectIndex = (int)Random.Range(0, objectList.Length);
		int spawnIndex = (int)Random.Range(0, spawnPoints.Length); // Added to randomly select index for spawn point

        GameObject newItem = (GameObject)Instantiate(objectList[objectIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
        newItem.GetComponent<SpriteRenderer>().sprite = spriteList[Random.Range(0, spriteList.Length)];
        newItem.layer = LayerMask.NameToLayer("Conveyor" + spawnIndex); // Added to set layer to that of the lane corresponding to the spawn index

		// This is so that the object falls to the start lane before checking for nearest lane... this allows the spawn point to be above or on a higher conveyor without conflict
		//newSprite.GetComponent<ConveyerObject> ().nearestLane = spawnIndex;
    }    
}
