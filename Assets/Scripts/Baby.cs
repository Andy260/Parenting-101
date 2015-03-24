using UnityEngine;
using System.Collections;

public class Baby : MonoBehaviour 
{
    #region Variables
    //How sad the baby is
    public int sadness = 1;
    //Is the baby holding a dangerous item
    public bool dangerousGoods = false;
    //Is the baby holding anything at all
    bool anyGoods = false;
    //Whether or not the inspector is checking the baby for being hit
    bool checkingForHit = false;
    //A bool keeping track of whether or not the baby was hit
    public bool babyGotHit = false;
    //A tick set to the atention value of goods, this controls how long he plays with the good
    uint atentionTick = 0;
    //A bool to control whether or not the baby is ocupied with an object 
    bool occupied = false;
    //The cool down time when a baby drops a good to prevent it from picking it up immediately 
    uint coolDown = 0;
    //A Tick that counts down from sixty. The time stamp is fixed so this will reset evey second
    uint secondTick = 60;
    //The current goods the baby is holding (if any)
    ConveyerObject CurrentGoods;
    //A reference to the audio component of the baby
    AudioSource myAudio;
    // Use this for initialization
    #endregion
    #region Functions
    void Start() 
    {
        GameObject thisBaby = GameObject.Find("Baby");
        myAudio = thisBaby.GetComponent<AudioSource>();
        myAudio.volume = (float)sadness * 0.10f;

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
        //Ticks once each second to begin to control events on a timer
        if (secondTick == 0)
        {
            //Whether or not the baby is in cool down and can hold an good
            if (coolDown > 0)
            {
                //The baby is still intrested in the goods
                if (atentionTick > 0)
                {
                    atentionTick -= 1;
                    if (sadness > 0)
                        sadness -= 1;
                }
                //The baby is not intrested in the good but does have goods to drop
                else if (occupied)
                {
                    DropGoods();
                    occupied = false;
                }
                //Slowly has a chance increases the babys sadness each second
                else
                    if (1 == (uint)Random.Range(0, 5))
                        sadness += 1;
            }
            else
                coolDown -= 1;
            //Reset the second ticker
            secondTick = 60;
        }
        else
            secondTick -= 1;

        //Converts the sadness into the babys current volume
        myAudio.volume = (float)sadness * 0.10f;
        
	}
    public void StopCheckingForBabyHit()
    {
        checkingForHit = false;
    }
    //Checks if the baby is holding anything and if true drops the good
    public bool DropGoods()
    {
        if (CurrentGoods == null)
            return false;
        //Removes collisions and physics from box
        CurrentGoods.me.AddComponent<Rigidbody2D>();
        CurrentGoods.me.AddComponent<BoxCollider2D>();
        dangerousGoods = false;
        anyGoods = false;
        CurrentGoods.babyMovement = true;
        coolDown = 3;
        return true;
    }
    
    /// Checks whether or not the baby can hold an item, if so it holds it
    ///<param name="HoldItem">The item the baby will hold</param>
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
        CurrentGoods = HoldItem;
        CurrentGoods.babyMovement = false;
        occupied = true;
        return true;
    }
    //Begins checking whether or not the baby is hit
    public void CheckForBabyHit()
    {
        checkingForHit = true; 
    }
    //A method that returns how loud the baby is
    #endregion
    #region Methods
    public int loudness
    {
        get { return sadness; }
    }
    #endregion
}
