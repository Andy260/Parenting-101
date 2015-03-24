using UnityEngine;
using System.Collections;

public class Hazards : MonoBehaviour 
{
	// Baby 
	public GameObject _baby;
	public int _babySadnessTrigger;
	Baby _babyScript;

	// Hazards activation
	public float _wiresFrequency;			// Frequency of the wires hazard
	public float _wiresFrequencyChange; 	// Deducts timer within this range
	float _wiresEventTimer;					// Timer until leaver hazard is activated
	public float _leaverFrequency;			// Frequency of the wires hazard
	public float _leaverFrequencyChange; 	// Deducts timer within this range
	float _leaverEventTimer;				// Timer until leaver hazard is activated

    // Leaver Hazard
    GameObject _leaverObject;
    SpriteRenderer _leaverSprite;
    public bool _leaverActivated;
    public GameObject _leaverActive;
    public GameObject _leaverDeactive;

    // Wires Hazard
    GameObject _wiresObject;
    SpriteRenderer _wiresSprite;
    public bool _wiresActivated;
    public GameObject _wiresActive;
    public GameObject _wiresDeactive;

	void Start () 
    {
        // Setup leaver hazard
        if (_leaverActivated)
            StartLeaverHazard();
        else
            StopLeaverHazard();

        // Setup wire hazard
        if (_wiresActivated)
            StartWiresHazard();
        else
            StopWiresHazard();

		_babyScript = _baby.GetComponent<Baby> ();
	}

	void Update () 
    {
		float wiresOffset = Random.Range(0, _wiresFrequencyChange);

		if (_wiresEventTimer + wiresOffset > _wiresFrequency &&
		    _babyScript.sadness > _babySadnessTrigger)
		{
			// Activate hazard / deactivate hazard
			if (_wiresActivated)
				StopWiresHazard();
			else
				StartWiresHazard();

			// Reset timer
			_wiresEventTimer = 0.0f;
		}
		else
		{
			// Tick timer
			_wiresEventTimer += Time.deltaTime;
		}

		float leaverOffset = Random.Range(0, _leaverFrequencyChange);

		if (_leaverEventTimer + leaverOffset > _leaverFrequency)
		{
			// Activate hazard / deactivate hazard
			if (_leaverActivated)
				StopLeaverHazard();
			else
				StartLeaverHazard();

			// Reset timer
			_leaverEventTimer = 0.0f;
		}
		else
		{
			// Tick timer
			_leaverEventTimer += Time.deltaTime;
		}
	}

    public void StartLeaverHazard()
    {
        // Change sprite and update flag
        _leaverActivated = true;

		_leaverActive.gameObject.SetActive(true);
		_leaverDeactive.gameObject.SetActive(false);
    }

    public void StopLeaverHazard()
    {
        // Change sprite and update flag
        _leaverActivated = false;

		_leaverActive.gameObject.SetActive(false);
		_leaverDeactive.gameObject.SetActive(true);
    }

    public void StartWiresHazard()
    {
        // Change sprite and update flag
        _wiresActivated = true;

		_wiresActive.gameObject.SetActive(true);
		_wiresDeactive.gameObject.SetActive(false);
    }

    public void StopWiresHazard()
    {
        // Change sprite and update flag
        _wiresActivated = false;
        
		_wiresActive.gameObject.SetActive(false);
		_wiresDeactive.gameObject.SetActive(true);
    }
}
