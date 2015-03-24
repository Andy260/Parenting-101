using UnityEngine;
using UnityEditor;
using System.Collections;

public class ConveyerSpawn : MonoBehaviour
{
    public Sprite[] spriteList;
	public Transform [] spawnPoints; // Added
    public float spawnTime;
	public float whatever = 10.0f;
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
        int spriteIndex = (int)Random.Range(0, spriteList.Length);
		int spawnIndex = (int)Random.Range(0, spawnPoints.Length); // Added to randomly select index for spawn point

        GameObject newSprite = new GameObject();

        SpriteRenderer renderer = newSprite.AddComponent<SpriteRenderer>();

        renderer.sprite = Sprite.Create(spriteList[spriteIndex].texture, new Rect(0, 0, spriteList[spriteIndex].textureRect.width, spriteList[spriteIndex].textureRect.height), new Vector2(0,0));

		newSprite.transform.position = spawnPoints [spawnIndex].position; // Adjusted to use spawnPoints array and random spawnIndex
		
        newSprite.AddComponent<ConveyerObject>();
        newSprite.AddComponent<Rigidbody2D>();
        newSprite.AddComponent<BoxCollider2D>(); 
		newSprite.layer = LayerMask.NameToLayer ("Conveyor "+ spawnIndex); // Added to set layer to that of the lane corresponding to the spawn index

		// This is so that the object falls to the start lane before checking for nearest lane... this allows the spawn point to be above or on a higher conveyor without conflict
		newSprite.GetComponent<ConveyerObject> ().nearestLane = spawnIndex;
    }    
}
