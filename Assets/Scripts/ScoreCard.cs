using UnityEngine;
using System.Collections;

public class ScoreCard : MonoBehaviour {
    public GameObject[] lineText;
    public GameObject[] resultText;
    private float timer = 4.0f;
	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
	}

   
}
