using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {



    public int playerPeerId = 1;
    public GameObject bullet;
    public int bulletShootDelay = 20;
    public int count = 0;
    public float speed = 0.2f;
    public int moveCount = 0;
    public GameObject bulletmanager;
    public GameObject enemymanager;
    public float waitTime= 0.0002f;
    public bool lockPos = false;
    public int megaChance = 0;
    public Sprite img1, img2, img3, img4;
    public bool lock2 = false;
    public int lockCount = 0;
    public bool gamePaused = false;

    // Use this for initialization
    void Start () {

        bulletmanager = GameObject.FindGameObjectWithTag("BulletManager");
        enemymanager = GameObject.FindGameObjectWithTag("EnemyManager");
        int i = Random.Range(1, 4);
        if(i == 1)
        gameObject.GetComponent<SpriteRenderer>().sprite = img1;

        if (i == 2)
            gameObject.GetComponent<SpriteRenderer>().sprite = img2;

        if (i == 3)
            gameObject.GetComponent<SpriteRenderer>().sprite = img3;

        if (i == 4)
            gameObject.GetComponent<SpriteRenderer>().sprite = img4;





    }

    // Update is called once per frame
    void Update () {
      
     

    }

    private void FixedUpdate()
    {


        if(!gamePaused)
        {

            if (!lockPos)
            {

                int mega = Random.Range(megaChance, 200);
                if (mega > 199)
                {
                    megaChance = 0;
                    StartCoroutine("MegaAttack");
                }
                megaChance++;
                if (count == 0)
                {

                    Shoot();
                }

                count++;
                if (count > bulletShootDelay)
                {
                    count = 0;
                }

                int randLock = Random.Range(0, 100);
                if (randLock > 99)
                {
                    lock2 = true;
                }

                if (!lock2)
                {
                    int rand = Random.Range(0, 100);
                    Vector2 position = this.transform.position;
                    if (rand > 98)
                    {
                        if (speed > 0)
                        {
                            speed = -0.2f;
                        }
                        else
                        {
                            speed = 0.2f;
                        }
                    }


                    position.x = position.x + speed;
                    position.y = position.y + speed;
                    this.transform.position = position;
                    if (position.x > 17)
                    {
                        speed = -0.2f;
                    }
                    if (position.x < -17)
                    {
                        speed = 0.2f;
                    }

                    if (position.y > 13)
                    {
                        speed = -0.2f;
                    }
                    if (position.y < -6)
                    {
                        speed = 0.2f;
                    }
                }


                if (lockCount > 5)
                {
                    lock2 = false;
                }
                if (lock2)
                {
                    lockCount++;
                }

            }

        }




    }

    // private void OnTriggerEnter2D(Collider2D collision)
    //  {
    //     if (collision.gameObject.tag == "PlayerBullet")
    //     {
    //         Debug.Log("OwO");
    //     }
    //  }

    public void HitByBullet()
    {
        Debug.Log("OwO");
        enemymanager.GetComponent<EnemyManagerScript>().RemoveEnemy(this.gameObject);

        Destroy(gameObject);
    }

    public void Shoot()
    {
        GameObject bul =  Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
        bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul);
        //bul.GetComponent<EnemyBulletScript>().getBulletType("1");

        //  bullet.GetComponent<EnemyBulletScript>().GetPlayerId(playerPeerId);

    }

    IEnumerator MegaAttack()
    {

        
        Debug.Log("MEGA ATTACK");
        int j = 0;
        j = Random.Range(1, 8);
        if (j == 1)
        {
            lockPos = true;
            for (int i = 0; i < 50; i++)
            {
                Debug.Log("test");
                GameObject bul = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 7.2f * i));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul);

                yield return new WaitForSeconds(waitTime);
            }

        }

        if (j == 2)
        {
            lockPos = true;
            for (int i = 0; i < 31; i++)
            {
                Debug.Log("test");
                GameObject bul = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 11 * i));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul);


            }
            yield return new WaitForSeconds(waitTime);
            for (int i = 0; i < 31; i++)
            {
                Debug.Log("test");
                GameObject bul = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 11 * i));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul);

                //yield return new WaitForSeconds(waitTime);
            }
            yield return new WaitForSeconds(waitTime);
            for (int i = 0; i < 31; i++)
            {
                Debug.Log("test");
                GameObject bul = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 11 * i));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul);

                //yield return new WaitForSeconds(waitTime);
            }
        }

        if (j == 3)
        {
            lockPos = true;
            for (int i = 0; i < 20; i++)
            {
                Debug.Log("test");
                GameObject bul1 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 7.2f));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul1);

                GameObject bul2 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 97.2f));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul2);

                GameObject bul3 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 187.2f));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul3);

                GameObject bul4 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 277.2f));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul4);

                yield return new WaitForSeconds(waitTime);
            }
        }

        if (j == 4)
        {
            lockPos = true;
            for (int i = 0; i < 20; i++)
            {
                Debug.Log("test");
                GameObject bul1 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 7.2f * i));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul1);

                GameObject bul2 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 97.2f * i));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul2);

                GameObject bul3 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 187.2f * i));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul3);

                GameObject bul4 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 277.2f * i));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul4);

                yield return new WaitForSeconds(waitTime);
            }
        }

        if (j == 5)
        {
            lockPos = true;
            for (int i = 0; i < 20; i++)
            {
                Debug.Log("test");
                GameObject bul1 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 7.2f * i));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul1);

                GameObject bul2 = Instantiate(bullet, new Vector2(this.transform.position.x + 5, this.transform.position.y), Quaternion.Euler(0, 0, 97.2f * i));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul2);

                GameObject bul3 = Instantiate(bullet, new Vector2(this.transform.position.x - 5, this.transform.position.y), Quaternion.Euler(0, 0, 187.2f * i));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul3);

                GameObject bul4 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 277.2f * i));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul4);




                yield return new WaitForSeconds(waitTime);
            }
        }

        if (j == 6)
        {
            lockPos = true;
            for (int i = 0; i < 50; i++)
            {
                Debug.Log("test");
                GameObject bul = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 7.2f * i));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul);

                GameObject bul1 = Instantiate(bullet, new Vector2(this.transform.position.x - 5, this.transform.position.y), Quaternion.Euler(0, 0, 7.2f * i));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul1);

                GameObject bul2 = Instantiate(bullet, new Vector2(this.transform.position.x + 5, this.transform.position.y), Quaternion.Euler(0, 0, 7.2f * i));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul2);

                yield return new WaitForSeconds(waitTime);
            }

        }


        if (j == 7)
        {
            lockPos = true;
            for (int i = 0; i < 30; i++)
            {
                Debug.Log("test6");
                GameObject bul = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 11 * i));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul);

                GameObject bul2 = Instantiate(bullet, new Vector2(this.transform.position.x + 5, this.transform.position.y), Quaternion.Euler(0, 0, 11 * i));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul2);

                GameObject bul3 = Instantiate(bullet, new Vector2(this.transform.position.x - 5, this.transform.position.y), Quaternion.Euler(0, 0, 11 * i));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul3);

                //yield return new WaitForSeconds(waitTime);
            }
        }

        if (j == 8)
        {
            lockPos = true;
            for (int i = 0; i < 20; i++)
            {
                Debug.Log("test");
                GameObject bul1 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 7.2f * i));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul1);

                GameObject bul2 = Instantiate(bullet, new Vector2(this.transform.position.x + 5, this.transform.position.y), Quaternion.Euler(0, 0, 97.2f * i));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul2);

                GameObject bul3 = Instantiate(bullet, new Vector2(this.transform.position.x - 5, this.transform.position.y), Quaternion.Euler(0, 0, 187.2f * i));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul3);

                GameObject bul4 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 277.2f * i));
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul4);




                yield return new WaitForSeconds(waitTime);
            }
        }



        lockPos = false;
    }
}
