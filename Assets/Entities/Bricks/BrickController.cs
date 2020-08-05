using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {

    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject breakEffect;
    public GameObject collectible;

    Animator anim;
    int bounceHash = Animator.StringToHash("Bounce");

    private LevelManager levelManager;
    private int maxHits;
    private int timesHit;
    private bool isBreakable;

    void Start()
    {
        isBreakable = (tag == "Brick");
        if (isBreakable)
        {
            breakableCount++;
        }
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ball")
        {
            Debug.Log("I'm Hit!" + collision.collider.tag.ToString());
            AudioSource.PlayClipAtPoint(crack, transform.position);
            if (isBreakable)
            {
                HandleHits();
            }
        }

        if (collision.collider.tag == "Zombie")
        {
            Destroy(gameObject);
            GameObject obj = ObjectPooler.current.GetPooledObject();

        obj.transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y);
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
        }

        if (collision.collider.tag == "Pound Cloud")
        {
            HandleHits();
        }

        if (collision.collider.tag == "Bounce Ring")
        {
            Debug.Log("Bounce!!!");
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                anim.SetTrigger(bounceHash);
        }
    }

    void HandleHits()
    {
        timesHit++;
        maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            MakeBreakEffect();
            Instantiate(collectible, transform.position, Quaternion.identity);
            Destroy(gameObject);
            //AstarPath.active.Scan();         //!!!!!!!!!!!!!!!!!!!!!!!!!!!!SCAN IS HERE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
        else
        {
            LoadSprites();
        }
    }

    void MakeBreakEffect()
    {
        GameObject effect = Instantiate(breakEffect, transform.position, Quaternion.identity) as GameObject;
        effect.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("No Sprite Available");
        }
    }
}
