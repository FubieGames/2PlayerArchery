using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

    public Archer owner;

    public Rigidbody2D rb;
    public BoxCollider2D boxColl;
    public ArrowAngle arrowAngle;

    public ParticleSystem fire;

    public Animator anim;

    public GameObject hitSounds;
    public GameObject boingSound;

    GameObject gameControllerObj;
    Shake shake;
    TimeController timeController;

    float storeAngle;

    void Start()
    {
        gameControllerObj = GameObject.FindGameObjectWithTag("GameController");
        shake = gameControllerObj.GetComponent<Shake>();
        timeController = gameControllerObj.GetComponent<TimeController>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Arrow>())
        {
            //TODO: Put fun stuff here
        }
        else if (collision.gameObject.tag == "DestroyTrigger")
        {
            Destroy(this.gameObject);
        }
        else
        {
            storeAngle = arrowAngle.angle;
            arrowAngle.Stuck(storeAngle);

            rb.isKinematic = true;
            boxColl.enabled = false;

            this.transform.parent = collision.transform;
            GameObject sound;
            sound = (GameObject)Instantiate(boingSound, transform.position, Quaternion.identity);
            fire.enableEmission = false;
            anim.SetTrigger("Boing");
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Archer>())
        {
            shake.PlayShake();
            timeController.Freeze(.125f);

            Archer archer;
            archer = collider.GetComponent<Archer>();
            archer.Damage(1);

            GameObject sound = (GameObject)Instantiate(hitSounds, transform.position, Quaternion.identity);

            fire.transform.parent = null;
            fire.enableEmission = false;
            Destroy(fire, 0.5f);

            Destroy(gameObject);
        }
    }
}
