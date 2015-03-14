using UnityEngine;
using UnityEditor;
using System.Collections;

public class ConveyerSpawn : MonoBehaviour
{
    public Sprite[] spriteList;
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

        renderer.sprite = Sprite.Create(spriteList[spriteIndex].texture, new Rect(0, 0, spriteList[spriteIndex].textureRect.width, spriteList[spriteIndex].textureRect.height), new Vector2(0,0));
        newSprite.transform.position = transform.position;
        newSprite.AddComponent<ConveyerObject>();
        newSprite.AddComponent<Rigidbody2D>();
        newSprite.AddComponent<BoxCollider2D>();  
    }    
}
