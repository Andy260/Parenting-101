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
    public bool babyGotHit = false;
    uint atentionTick = 0;
    bool seekingAtention = false;
    uint secondTick = 60;
    ConveyerObject CurrentItem;
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
        DropGoods();
    }
	// Update is called once per frame
    public void Update() 
    {
        if (secondTick == 0)
        {
            if (atentionTick > 0)
            {
                atentionTick -= 1;
                if (sadness > 0)
                    sadness -= 1;
            }
            else if (seekingAtention)
            {
                DropGoods();
                seekingAtention = false;
            }
            else
            {
                if (1 == (uint)Random.Range(0, 5))
                    sadness += 1;
            }
            secondTick = 60;
        }
        else
            secondTick -= 1;
	}
    public void StopCheckingForBabyHit()
    {
        checkingForHit = false;
    }
    public bool DropGoods()
    {
        if (CurrentItem == null)
            return false;
        CurrentItem.me.AddComponent<Rigidbody2D>();
        CurrentItem.me.AddComponent<BoxCollider2D>();
        dangerousGoods = false;
        anyGoods = false;
        CurrentItem.babyMovement = true;
        return true;
    }
    public bool CanHold(ConveyerObject HoldItem)
    {

        if (anyGoods)
            return false;
        if (sadness < HoldItem.attentionValue)
            return false;

        dangerousGoods = HoldItem.isDangerous;
        anyGoods = true;
        atentionTick = (uint)HoldItem.attentionValue;
        Vector3 offSet = new Vector3(00,0,0);
        HoldItem.transform.position = (this.transform.position + offSet);

        Rigidbody2D blah = HoldItem.me.GetComponent<Rigidbody2D>();
        Destroy(blah);
        BoxCollider2D bloh = HoldItem.me.GetComponent<BoxCollider2D>();
        Destroy(bloh);
        CurrentItem = HoldItem;
        CurrentItem.babyMovement = false;
        seekingAtention = true;
        return true;
    }

    public void CheckForBabyHit()
    {
        checkingForHit = true; 
    }
}
