using UnityEngine;
using System.Collections;

public class Baby : MonoBehaviour 
{
    //How sad the baby is
    public int sadness = 0;
    //How loud the baby is
    public int loudness = 0;
    //Is holding a dangerous item
    public bool dangerousGoods = false;
    bool anyGoods = false;
    bool checkingForHit = false;
    bool babyGotHit = false;
    uint atentionTick = 0;
    uint secondTick = 60;
    ConveyerObject HoldItem;
	// Use this for initialization
	void Start () 
    {

	}
    //The animation playing for the baby swiping a hazzard
    public void HitBaby()
    {
        sadness += 1;
        if (checkingForHit)
            babyGotHit = true;
    }
	// Update is called once per frame
    public void Update() 
    {
        if (secondTick == 0)
        {
            if (atentionTick > 0)
            {
                atentionTick -= 1;
            }
        }
	}

    public bool CanHold(ConveyerObject HoldItem)
    {

        if (anyGoods)
            return false;
        if (Random.Range(0, 10) < HoldItem.attentionValue)
        {
            dangerousGoods = HoldItem.isDangerous;
            anyGoods = true;
            atentionTick = (uint)HoldItem.attentionValue;
            return true;
        }

        return false;
    }

    public void CheckForBabyHit()
    {
        checkingForHit = true; 
    }

    void GetGoods()
    {
        GameObject objectBaby = GameObject.Find("ThePlayer");
        Baby babyScript = objectBaby.GetComponent<Baby>();
        transform.position = babyScript.transform.position;
    }
}
