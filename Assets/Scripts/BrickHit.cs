using UnityEngine;
using System.Collections;

public class BrickHit : MonoBehaviour {
    public Sprite[] hitSprites;
    public AudioClip crack;
    public static int numberOfBricks{get;set;}
    public GameObject smoke;

    private int hitTimeMax;
    private int hitTimes;
    private LvManager lvmanger;
    private bool isBreakable;


    void OnCollisionExit2D(Collision2D collion)
    {
        //GetComponent<AudioSource>().PlayClipAtPoint(crack,this.transform.position);
        // TODO Find out the problem dat why PlayClipAtPoint() method need a vector3.   
                                                                                              
        if (isBreakable)
        {
            hitController();
        }
    }

//    void getSmoke()
//    {
//        smoke.transform.position = this.transform.position;
//        smoke.GetComponent<ParticleSystem>().Play();
//    }

    void hitController()
    {
        hitTimes++;
        hitTimeMax = hitSprites.Length + 1;
        if (hitTimes >= hitTimeMax)
        {
            numberOfBricks--;
            Destroy(gameObject);
            getSmoke();
            if (numberOfBricks <= 0)
            {
                lvmanger.LoadNextLv();
            }
        }
        else
        {
            LoadSprites(); 
        }
    }

    void getSmoke()
    {
        Instantiate(smoke,transform.position,Quaternion.identity);
    }

    void LoadSprites()
    {
        int spritesIndex = hitTimes - 1;
        if (hitSprites[spritesIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spritesIndex];
        }
        else
        {
            Debug.LogError(hitSprites.Length+" hit brick spreite missing");
        }
    }

   

	// Use this for initialization
	void Start()
    {
        this.isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            numberOfBricks++;
        }
	    hitTimes=0;
        lvmanger = GameObject.FindObjectOfType<LvManager>();

	}
	
	// Update is called once per frame
	void Update () {
	  
	}
   
}
