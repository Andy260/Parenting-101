using UnityEngine;
using System.Collections;

public class ConveyerObjectOld : MonoBehaviour
{
    Vector3 dragOffset;
    Vector3 screenPoint;

//    bool allowMovement; // Not Using
    bool allowInput;

    bool pressingMouse;
	bool falling = true; // Added

    float takeAwayTimer;
	float conveyorSpeed; // Added

	public int nearestLane; // Added

	GameObject spawnObject; // Added
	ConveyerSpawn spawnScript; // Added
	Transform [] laneList; // Added

	// Added Awake Function
	void Awake () 
	{
		spawnObject = GameObject.Find ("Conveyor Spawn Point Node");
		spawnScript = spawnObject.GetComponent<ConveyerSpawn>();
		laneList = spawnScript.laneList;
	}


	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody2D>().rotation += 5;
		GetComponent<Rigidbody2D> ().velocity = Vector3.left * 5; // Added: Gives an initial velocity kick on spawn and stops objects spawning on top of each other at low speeds
//        allowMovement = true;
        allowInput = false;
        pressingMouse = false;
        takeAwayTimer = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
		conveyorSpeed = spawnScript.conveyorSpeed; // Added: Object speed set to external variable
//        if (allowMovement) // Removed
//        {
            transform.Translate(new Vector3(-conveyorSpeed * Time.deltaTime, 0, 0), Space.World); // Adjusted to use ConveyorSpeed
//        }
        
        if (allowInput && pressingMouse)
        {
            takeAwayTimer -= Time.deltaTime;

            if (takeAwayTimer <= 0)
            {
				DropObject (); // Previously Destroy(this.GameObject);
            }            
        }

		if (falling) // Added If Else statement to check if the object is currently on its nearest lane
		{
			CheckFalling ();
		}
		else 
		{
			CheckLanes ();
		}
	}

	void CheckFalling () // Added this function
	{
		if (Mathf.Abs (transform.position.y - laneList [nearestLane].position.y) < 0.4f) 
		{
			falling = false;
		}
	}

	void CheckLanes ()  // Added this function to find the nearest lane below the y position of the object and set the object's collider to match that lane
	{
		float [] distances = new float[laneList.Length];
		bool foundLane = false;
		for (int i = 0; i < laneList.Length; i++) // Make a list of the distance on the y axis for each of the lanes from the object's y position
		{
			if (transform.position.y > laneList[i].position.y - 0.5f) // If the lane's y position is below the object's y position, add the distance to an array
			{
				distances [i] =  Mathf.Abs (transform.position.y - laneList[i].position.y);
				foundLane = true;
			}
			else // add a filler
			{
				distances [i] = 1000; // this is probably not the cleanest way to make the indices of both arrays match, but it works
			}
		}

		if (foundLane) // If a lane was found to be below the y value of the object
		{
			float minDist = Mathf.Max (distances); // Find the highest value in distances
			for (int i = 0; i < distances.Length; i++) // Check every value in distances
			{
				if(distances[i] < minDist) // If a value is lower than the previous lowest, it becomes the new lowest
				{
					minDist = distances[i];
					nearestLane = i; // nearestLane is set to the index of the lowest value in distances
				}
			}
		}
		else // If there was no lane below object, set nearestLane to lowest lane so its collider forces it back up
		{
			nearestLane = laneList.Length -1;
		}

		gameObject.layer = LayerMask.NameToLayer ("Conveyor "+ nearestLane); // nearestLane is used to set the layer of the object
	}
	
	void OnTriggerStay2D(Collider2D trigger) // Removed colour change
    {
        if (trigger.name == "Swipe Trigger")
        {
//            Debug.Log("In Swipe Zone!");
            allowInput = true;
        }
        else if (trigger.name == "Object Trigger" || trigger.name == "Object Trigger 1")
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D trigger) // Removed colour change
    {
        if (trigger.name == "Swipe Trigger")
        {
            //Debug.Log("In Swipe Zone!");
            allowInput = false;
        }
    }

	void OnMouseUp() // Removed allowMovement = true; // Removed pressingMouse = false; // Added DropObject ();
    {
        if (allowInput)
        {
			DropObject ();
//            allowMovement = true;
        }
    }

    void OnMouseDown()
    {
        if (allowInput)
        {
			GetComponent<SpriteRenderer>().color = Color.green; // Added
            pressingMouse = true;
  //          allowMovement = false;

            dragOffset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(0, Input.mousePosition.y, 0));
			falling = false; // Added

			// turn off colliders so you can drag object through colliders below
			GetComponent<BoxCollider2D>().enabled = false; // Added
        }         
    }

    void OnMouseDrag()
    {
        if (allowInput && pressingMouse)
        {
            Vector3 currentScreenPoint = new Vector3(0, Input.mousePosition.y, 0);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + dragOffset;
	        transform.position = new Vector3(transform.position.x, currentPosition.y, transform.position.z); // Adjusted from transform.position = currentPosition
        }
    }

	void DropObject () // Added this function
	{
		pressingMouse = false;
		// Sets object to collide with only objects on the nearest lane layer
		gameObject.layer = LayerMask.NameToLayer ("Conveyor "+ nearestLane);
		GetComponent<BoxCollider2D>().enabled = true;
		GetComponent<SpriteRenderer>().color = Color.white;
//		allowInput = false;
		falling = true;
		takeAwayTimer = 1;
	}
}
