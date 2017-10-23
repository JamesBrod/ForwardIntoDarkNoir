using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBulletScript : MonoBehaviour
{

    public float bulletSpeed = 1000f;
    public int owner;
    public Vector2 prevPosition;
    public Vector2 currPos;
    public int bulletType = 0;
    public Rigidbody2D rb;



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

        //  Rigidbody2D rig = this.GetComponent<Rigidbody2D>();
        //  rig.AddForce(new Vector2(0, bulletSpeed));

        rb.AddForce(transform.up * bulletSpeed);

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

    private void Update()
    {
        if (this.transform.position.y > 6.5)
        {
            Destroy(gameObject);
        }

        if (this.transform.position.y < -18)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (!(collision.gameObject.GetComponent<PlayerMovement>().playerPeerId == owner))
                Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyScript>().HitByBullet();
            Destroy(gameObject);
        }
    }

    public void getBulletType(string s)
    {
        if (s.Equals(""))
        {
            bulletType = 1;
        }

        if (s.Equals(""))
        {
            bulletType = 2;
        }

        if (s.Equals(""))
        {
            bulletType = 3;
        }

        if (s.Equals(""))
        {
            bulletType = 4;
        }
    }
}
