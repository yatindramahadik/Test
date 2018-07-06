using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {
    //private int maxHits;
    public Sprite[] hitSprites;
    public static int breakableCounts = 0;
    public AudioClip crack;
    public GameObject smoke;

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;

	// Use this for initialization
	void Start () {
        isBreakable = (this.tag == "Breakable");
        if (isBreakable){
            breakableCounts++;
            //print(breakableCounts);
        }
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D col)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable){
            HandleHits();
        }
    }
    void HandleHits(){
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCounts--;
            levelManager.BrickDestroyed();
            GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
#pragma warning disable CS0618 // Type or member is obsolete
            smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
#pragma warning restore CS0618 // Type or member is obsolete
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }

    }


    void LoadSprites(){
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {

            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
            Debug.LogError("gayab hai ");
    }
    //TODO remove this
    void SimulateWin(){
        levelManager.LoadNextLevel();
    }
}
