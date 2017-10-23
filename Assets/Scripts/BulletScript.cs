using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float bulletSpeed = 1000f;
    public int owner;
    public Vector2 prevPosition;
    public Vector2 currPos;
    public int bulletType = 1;
    public Rigidbody2D rb;
    private int count = 0;
    public bool gamePaused = false;



    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("test");
       // bulletType = 2;
        

	}

    public void GetPlayerId(int ownerInt)
    {
        owner = ownerInt;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if(!gamePaused)
        {
            if (bulletType == 1)
            {

                rb.AddForce(transform.up * bulletSpeed);
            }


            if (bulletType == 2)
            {
                //Debug.Log(count);
                rb.AddForce(transform.up * bulletSpeed);
                if (count == 30)
                {

                    rb.velocity = Vector3.zero;

                    this.transform.Rotate(0, 0, -45);
                    rb.AddForce(transform.up * bulletSpeed);

                }
            }

            if (bulletType == 3)
            {
                //Debug.Log(count);
                rb.AddForce(transform.up * bulletSpeed);
                if (count == 30)
                {

                    rb.velocity = Vector3.zero;

                    this.transform.Rotate(0, 0, -180);
                    rb.AddForce(transform.up * bulletSpeed);

                }
            }

            count++;

            //if (bulletType == 0)
            //{
            //    Debug.Log("test");
            //    Vector2 position = this.transform.localPosition;
            //    prevPosition = position;
            //    position.y = position.y + bulletSpeed;
            //    this.transform.localPosition = position;
            //    currPos = position;
            //}

            //if (bulletType == 1)
            //{
            //    Vector2 position = this.transform.position;
            //    prevPosition = position;
            //    position.y = position.y + bulletSpeed;
            //    this.transform.position = position;
            //    currPos = position;
            //}

            //if (bulletType == 2)
            //{
            //    Vector2 position = this.transform.position;
            //    prevPosition = position;
            //    position.y = position.y + bulletSpeed;
            //    this.transform.position = position;
            //    currPos = position;
            //}

            //if (bulletType == 3)
            //{
            //    Vector2 position = this.transform.position;
            //    prevPosition = position;
            //    position.y = position.y + bulletSpeed;
            //    this.transform.position = position;
            //    currPos = position;
            //}


        }
        //Debug.Log(bulletType);
        // rb.AddForce(transform.up * bulletSpeed);
        //  Rigidbody2D rig = this.GetComponent<Rigidbody2D>();
        //  rig.AddForce(new Vector2(0, bulletSpeed));



    }

    private void Update()
    {
        if (this.transform.position.y > 13)
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
        
        if(collision.gameObject.tag == "Player")
        {
            if(!(collision.gameObject.GetComponent<PlayerMovement>().playerPeerId == owner))
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyScript>().HitByBullet();
            Destroy(gameObject);
        }
    }

    public void getBulletType(string s)
    {
        if(s.Equals("1"))
        {
            bulletType = 1;
        }

        if (s.Equals("2"))
        {
            bulletType = 2;
        }

        if (s.Equals("3"))
        {
            bulletType = 3;
        }

        if (s.Equals(""))
        {
            bulletType = 4;
        }
    }
}
