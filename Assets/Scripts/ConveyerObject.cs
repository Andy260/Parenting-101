using UnityEngine;
using System.Collections;

public class ConveyerObject : MonoBehaviour
{
   // public ConveyerSpawn.ObjectType objectType;

    Vector3 dragOffset;
    Vector3 screenPoint;

    public int attentionValue;
    public GameObject me;
    public bool isDangerous;
    bool allowMovement;
    bool allowInput;
    public bool babyMovement = true;
    bool pressingMouse;

    float takeAwayTimer;


	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody2D>().rotation += 5;
        allowMovement = true;
        allowInput = false;
        pressingMouse = false;
        takeAwayTimer = 1;        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (allowMovement && babyMovement)
        {
            transform.Translate(new Vector3(-5 * Time.deltaTime, 0, 0), Space.World);
        }
        
        if (allowInput && pressingMouse)
        {
            takeAwayTimer -= Time.deltaTime;

            if (takeAwayTimer <= 0)
            {
                Destroy(this.gameObject);
            }            
        }
	}

    void OnTriggerStay2D(Collider2D trigger)
    {
        if (trigger.name == "Swipe Trigger")
        {
            //Debug.Log("In Swipe Zone!");
            GetComponent<SpriteRenderer>().color = Color.green;
            allowInput = true;
        }
        else if (trigger.name == "Object Trigger" || trigger.name == "Object Trigger 1")
        {
            Destroy(this.gameObject);
            SceneManger.Score += 10;
            if (!SceneManger.BadItemPacked)
            {
                SceneManger.BadItemPacked = this.isDangerous;
            }
        }
        else if(trigger.name == "Take Trigger")
        {

        }
        else if (trigger.name == "Give Trigger")
        {
            GameObject findBabyObj = GameObject.Find("Baby");
            Baby babyObj = findBabyObj.GetComponent<Baby>();
            babyObj.CanHold(this);
        }
    }

    void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.name == "Swipe Trigger")
        {
            //Debug.Log("In Swipe Zone!");
            allowInput = false;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void OnMouseUp()
    {
        if (allowInput)
        {
            allowMovement = true;
            pressingMouse = false;
        }
    }

    void OnMouseDown()
    {
        if (allowInput)
        {
            pressingMouse = true;
            allowMovement = false;

            dragOffset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(0, Input.mousePosition.y, 0)); 
        }         
    }

    void OnMouseDrag()
    {
        if (allowInput && pressingMouse)
        {
            Vector3 currentScreenPoint = new Vector3(0, Input.mousePosition.y, 0);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + dragOffset;
            transform.position = currentPosition;
        }
    }
}
