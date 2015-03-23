using UnityEngine;
using UnityEditor;
using System.Collections;

public class ConveyerSpawn : MonoBehaviour
{
    public enum ObjectType
    {
        TAKE,
        GIVE,
        NONE
    }

    public Sprite[] spriteList;
    public ObjectType[] spriteTypes;
    public float spawnTime;   

    float initialTime;
    
	// Use this for initialization
	void Start()
    {
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
        
        GameObject newSprite = new GameObject();

        SpriteRenderer renderer = newSprite.AddComponent<SpriteRenderer>();

        renderer.sprite = Sprite.Create(spriteList[spriteIndex].texture, spriteList[spriteIndex].rect, new Vector2(0,0));
        newSprite.transform.position = transform.position;
        newSprite.AddComponent<ConveyerObject>();
        newSprite.AddComponent<Rigidbody2D>();
        newSprite.AddComponent<BoxCollider2D>();
        newSprite.GetComponent<ConveyerObject>().objectType = spriteTypes[spriteIndex];
        newSprite.GetComponent<ConveyerObject>().me = newSprite;
        if (spriteIndex > 7)
        {
            newSprite.GetComponent<ConveyerObject>().isDangerous = true;
            newSprite.GetComponent<ConveyerObject>().attentionValue = (int)Random.Range(5,10);
        }
        else
        {
            newSprite.GetComponent<ConveyerObject>().isDangerous = false;
            newSprite.GetComponent<ConveyerObject>().attentionValue = (int)Random.Range(1, 6);
        }
    }    
}