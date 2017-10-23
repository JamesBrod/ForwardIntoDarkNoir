using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{

    public float bulletSpeed = -0.2f;
    public int owner;
    public Rigidbody2D rb;
    public bool gamePaused = false;
    public Vector2 v;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void GetPlayerId(int ownerInt)
    {
        owner = ownerInt;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!gamePaused)
        {
            rb.AddForce(transform.up * bulletSpeed);
            v = rb.velocity;
            //Vector2 position = this.transform.position;
            //position.y = position.y - bulletSpeed;
            //this.transform.position = position;

        }
       

    }

    public void PauseBullets()
    {
        gamePaused = !gamePaused;

        if (gamePaused)
        {
            
            rb.velocity = new Vector2(0, 0);
        }

        if(!gamePaused)
        {
            rb.velocity = v;
        }

       

    }

    private void Update()
    {
        if (this.transform.position.y > 12)
        {
            Destroy(gameObject);
        }

        if (this.transform.position.y < -24)
        {
            Destroy(gameObject);
        }

        if (this.transform.position.x > 17)
        {
            Destroy(gameObject);
        }

        if (this.transform.position.x < -17)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().HitByBullet();
            

            if (!(collision.gameObject.GetComponent<PlayerMovement>().playerPeerId == owner))
                Destroy(gameObject);
        }

      
    }
}
