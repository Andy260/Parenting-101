using UnityEngine;
using System.Collections;

public class ConveyorMove : MonoBehaviour {
	 
	public GameObject sender;
	public GameObject receiver;
	private float speed = 2;



	// Use this for initialization
	void Start () {
	
		// speed = conveyor object speed


	}
	
	// Update is called once per frame
	void Update () {
	
		// speed = conveyor object speed

		transform.Translate (Vector3.left * speed * Time.deltaTime);


		if (transform.position.x < sender.transform.position.x)
		{
			transform.position = receiver.transform.position;
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject == sender) 
		{
			transform.position = receiver.transform.position;
		}
	}
}
