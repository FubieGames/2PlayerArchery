using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Archer : MonoBehaviour {

    [Header("AI")]
    public bool AI;
    public Transform testTarget;

    public float helpingAccuracy;

    [Range(1.0f,2.0f)]
    public float difficulty;
    [Range(1.0f, 2.0f)]
    public float maxDifficulty;
    [Range(0,2.0f)]
    public float inAccuracy;
    [Range(0, 8.0f)]
    public float bigInaccyracy;

    public float minWaitBetweenShots;
    public float maxWaitBetweenShots;

    [Header("Player")]
    public Color playerColor;
    public string playerName;

    public int health = 5;

    public GameObject arrow;
    public Transform shotPos;
    public float forse;
    public float maxForce = 100f;
    public float forsePerRate = 10f;

    public Animator anim;
    public Image powerImg;
    float rateTime;

    public bool isDrawing;
    public bool canDraw;

    public bool dead;
    public bool winner;

    bool _dead;

    float helpForce;

    public AudioClip[] shotClips;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

	void Update () {

        if (winner)
        {
            GameObject trgt = GameObject.Find("FixTarget");
            testTarget = trgt.transform;
            canDraw = false;
            isDrawing = false;
            forse = 0;
        }

        if (AI)
        {
            if (canDraw)
            {
                float rnd = Random.Range(minWaitBetweenShots, maxWaitBetweenShots);
                StartCoroutine("WaitForRandomSec", rnd);
            }

            if (forse >= WantedForce())
            {
                isDrawing = false;
            }
        }


        if (!dead && !winner)
        {

            if (isDrawing && canDraw)
            {

                if (helpForce == 0)
                {
                    forse += Time.deltaTime * forsePerRate;
                    if (forse >= maxForce)
                        helpForce = maxForce;
                }

                if (helpForce == maxForce)
                {
                    forse -= Time.deltaTime * forsePerRate;
                    if (forse <= 0)
                        helpForce = 0;
                }

            }

            if (!isDrawing)
            {

                if (forse != 0)
                {
                    if (forse < 5f) Shot(5f);
                    else Shot(forse);
                }
                
            }

        }
        anim.SetBool("isDrawing", isDrawing);
        powerImg.rectTransform.localScale = new Vector3(forse / maxForce, 1f, 1f);
	}


    //Handling Inputs
    public void Pressed()
    {
        isDrawing = true;
    }

    public void Released()
    {
        isDrawing = false;
    }

    public void Draw()
    {
        canDraw = true;
    }

    public void Notdraw()
    {
        canDraw = false;
    }


    //Shooting
    void Shot(float shotforce)
    {
        //Shot code here
        GameObject clone;
        clone = (GameObject)Instantiate(arrow, shotPos.position, shotPos.rotation);
        Rigidbody2D rb;
        rb = clone.GetComponent<Rigidbody2D>();
        clone.GetComponent<Arrow>().owner = this.gameObject.GetComponent<Archer>();

        //Adding Force
        rb.AddRelativeForce(Vector2.right * shotforce, ForceMode2D.Impulse);

        clone.transform.localRotation = new Quaternion(0, 0, 0, 0);

        AfterShot();
    }

    void AfterShot()
    {
        //Audio Stuff
        int rand = Random.Range(0, shotClips.Length);

        AudioSource src = this.gameObject.GetComponent<AudioSource>();
        src.pitch = Random.Range(0.85f, 1.2f);
        src.PlayOneShot(shotClips[rand]);

        //Reset force
        forse = 0;
    }


    //Damage and Dead
    public void Damage(int dmg)
    {
        forse = 0;
        canDraw = false;
        anim.SetTrigger("hit");
        health -= dmg;
        if (health <= 0)
        {
            anim.SetTrigger("dead");
            dead = true;
        }
    }

    public void Dead()
    {
        if (!_dead)
        {
            this.gameObject.transform.parent = null;
            SpriteRenderer spr = this.gameObject.GetComponent<SpriteRenderer>();
            spr.sortingLayerName = "Front";
            this.gameObject.layer = 8;
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.isKinematic = false;
            rb.AddTorque(Random.Range(-50f, 50f));
            rb.AddForce(Vector2.up * Random.Range(7.5f, 15f), ForceMode2D.Impulse);
            _dead = true;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.layer == 8)
        {
            //TODO: Call winning function for other player;
            Destroy(this.gameObject);
        }
    }


    //Artificial Inteligence
    float WantedForce()
    {

        float dist = Vector2.Distance(shotPos.position, testTarget.position); //Calculating Distance;

        float fixForce = helpingAccuracy;                       //This was adjusted for better accuracy;
        float randomForce = Random.Range(-inAccuracy, inAccuracy); //Adding little inaccuracy;

        float addForce = fixForce + randomForce;                      //Creating new adjustment vector;

        int chance = Random.Range(0, 100);
        if (chance > 50)
        {
            addForce += Random.Range(-bigInaccyracy, bigInaccyracy/bigInaccyracy);
        }

        float desiredForce = dist + addForce;

        return desiredForce * Random.Range(difficulty,maxDifficulty);
    }

    IEnumerator WaitForRandomSec(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isDrawing = true;
        StopCoroutine("WaitForRandomSec");
    }

}
