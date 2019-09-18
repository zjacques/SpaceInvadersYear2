using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;
    AudioSource audio;
    public Boundary boundary;

    public float speed;
    public float tilt;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    public GameObject playerExplosion;
    public GameController gameController;
    bool dead;
    float flashTime;
    public float respawnTime;
    public int lives;
    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;



    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        lives = 3;
        respawnTime = 2;
        flashTime = 0.5f;
        dead = false;

    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire && !dead)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audio.Play();
        }
    }
	

	void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        rb.velocity = movement * speed;

        rb.position = new Vector3
                (
                    Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                    0.0f,
                    0.0f
                );

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Instantiate(playerExplosion, transform.position, transform.rotation);
            dead = true;
            respawn();
        }
    }

    public void respawn()
    {
        switch (lives)
        {
            case 3:
                Life3.SetActive(false);
                lives--;
                break;
            case 2:
                Life2.SetActive(false);
                lives--;
                break;
            case 1:
                Life1.SetActive(false);
                lives--;
                gameController.GameOver();
                
                Destroy(gameObject);
                break;
            default:
                Debug.Log("Respawn Default");
                Destroy(gameObject);
                gameController.GameOver();
                break;
        }
        
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().isTrigger = true;

        StartCoroutine(Flash());


    }

    IEnumerator Flash()
    {
        yield return new WaitForSeconds(respawnTime);
        
        SpriteRenderer visible = gameObject.GetComponent<SpriteRenderer>();
        CircleCollider2D damageable = gameObject.GetComponent<CircleCollider2D>();
        dead = false;
        for (int i = 0; i<6; i++)
        {
            visible.enabled = !visible.enabled;
            

            yield return new WaitForSeconds(flashTime);
        }
        visible.enabled = true;
        damageable.isTrigger = false;
    }
}
