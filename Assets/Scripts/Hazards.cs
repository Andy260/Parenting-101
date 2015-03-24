using UnityEngine;
using System.Collections;

public class Hazards : MonoBehaviour 
{
    //public GameObject _hazardPrefab;

    // Leaver Hazard
    GameObject _leaverObject;
    SpriteRenderer _leaverSprite;
    public bool _leaverActivated;
    public Sprite _leaverActiveSprite;
    public Sprite _leaverDeactiveSprite;

    // Wires Hazard
    GameObject _wiresObject;
    SpriteRenderer _wiresSprite;
    public bool _wiresActivated;
    public Sprite _wiresActiveSprite;
    public Sprite _wiresDeactiveSprite;

	void Start () 
    {
        // Get game object references
        _leaverObject = gameObject.transform.FindChild("Leaver").gameObject;
        _wiresObject = gameObject.transform.FindChild("Wires").gameObject;

        // Get SpriteRender references
        _leaverSprite = _leaverObject.GetComponent<SpriteRenderer>();
        _wiresSprite = _wiresObject.GetComponent<SpriteRenderer>();

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
	}

	void Update () 
    {

	}

    public void StartLeaverHazard()
    {
        // Change sprite and update flag
        _leaverActivated = true;
        _leaverSprite.sprite = _leaverActiveSprite;
    }

    public void StopLeaverHazard()
    {
        // Change sprite and update flag
        _leaverActivated = false;
        _leaverSprite.sprite = _leaverDeactiveSprite;
    }

    public void StartWiresHazard()
    {
        // Change sprite and update flag
        _wiresActivated = true;
        _wiresSprite.sprite = _wiresActiveSprite;
    }

    public void StopWiresHazard()
    {
        // Change sprite and update flag
        _wiresActivated = false;
        _wiresSprite.sprite = _wiresDeactiveSprite;
    }
}
