using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : MonoBehaviour {



    private float speed = 0.3f;
    public int playerPeerId;
    public GameObject bullet;
    public int count = 0;
    public int playerShootDelay = 3;
    public Vector2 prevPosition;
    public Vector2 currPos;
    public GameObject bulletmanager;
    public float waitTime = 0.0002f;
    private IEnumerator coroutine;
    private bool lockPos = false;
    public string bullType = "1";
    public int playerLives = 3;
    public int invulTime = 10;
    public GameObject deathpart;
    public GameObject enemymanager;
    public bool gamePaused = false;

    // Use this for initialization
    void Start () {
        bulletmanager = GameObject.FindGameObjectWithTag("BulletManager");
        enemymanager = GameObject.FindGameObjectWithTag("EnemyManager");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(!gamePaused)
        {

            if (!lockPos)
            {




                prevPosition = this.transform.position;





                if (Input.GetKey(KeyCode.W))
                {
                    Vector2 position = this.transform.position;
                    if (!(position.y > -6))
                    {
                        position.y = position.y + speed;
                        this.transform.position = position;
                    }

                }

                if (Input.GetKey(KeyCode.S))
                {
                    Vector2 position = this.transform.position;
                    if (!(position.y < -24))
                    {
                        position.y = position.y - speed;
                        this.transform.position = position;
                    }

                }

                if (Input.GetKey(KeyCode.A))
                {
                    Vector2 position = this.transform.position;
                    if (!(position.x < -17))
                    {
                        position.x = position.x - speed;
                        this.transform.position = position;
                    }

                }

                if (Input.GetKey(KeyCode.D))
                {
                    Vector2 position = this.transform.position;
                    if (!(position.x > 17))
                    {
                        position.x = position.x + speed;
                        this.transform.position = position;
                    }

                }

                currPos = this.transform.position;

                if (Input.GetKey(KeyCode.Space))
                {
                    if (count == 0)
                    {
                        Shoot();

                    }
                    count++;
                    if (count > playerShootDelay)
                    {
                        count = 0;
                    }


                }

                if (Input.GetKeyDown(KeyCode.B))
                {
                    UseBomb();
                }

                if (Input.GetKeyDown(KeyCode.P))
                {
                    coroutine = UseSpread("test");
                    StartCoroutine(coroutine);

                }

                if (Input.GetKeyDown(KeyCode.O))
                {
                    coroutine = UseSpread("test1");
                    StartCoroutine(coroutine);

                }
                if (Input.GetKeyDown(KeyCode.L))
                {
                    coroutine = UseSpread("test2");
                    StartCoroutine(coroutine);

                }

                if (Input.GetKeyDown(KeyCode.K))
                {
                    coroutine = UseSpread("test4");
                    StartCoroutine(coroutine);

                }

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    ChangeAmmo();

                }
            }
        }
        //if (!isLocalPlayer)
       // {
       //     return;
      //  }

    }


    public void Shoot()
    {
       
        GameObject bul =  Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
        bul.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
        bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul);
        bul.GetComponent<BulletScript>().getBulletType(bullType);
    }

    public void ChangeAmmo()
    {
        if (bullType.Equals("1"))
            bullType = "2";
        else
            bullType = "1";

       // bullType = "3";

    }

    public void HitByBullet()
    {
        //if(invulTime == 30)
        // {
        //     Debug.Log("OwO");
        //     playerLives -= 1;

        // if (playerLives < 1)
        // {

        Vector2 pos = this.transform.position;
        Instantiate(deathpart, pos, Quaternion.identity);
        enemymanager.GetComponent<EnemyManagerScript>().GameOver();
        
        Destroy(gameObject);
        Debug.Log("GAME OVER");
       // }
        //     invulTime--;
        // }
        //if(invulTime < 30)
        // {
        //     invulTime--;
        // }



    }

    public void UseBomb()
    {
        Debug.Log("Bomb");
        bulletmanager.GetComponent<BulletManager>().DestroyAllBullets();
    }

    IEnumerator UseSpread(string spreadType)
    {

        if(spreadType.Equals("test"))
        {
            lockPos = true;
            for (int i = 0; i < 50; i++)
            {
                Debug.Log("test");
                GameObject bul = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 7.2f * i));
                bul.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul);
                bul.GetComponent<BulletScript>().getBulletType(bullType);

                yield return new WaitForSeconds(waitTime);
            }
           
        }

        if (spreadType.Equals("test1"))
        {
            lockPos = true;
            for (int i = 0; i < 31; i++)
            {
                Debug.Log("test");
                GameObject bul = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 11 * i));
                bul.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul);
                bul.GetComponent<BulletScript>().getBulletType(bullType);

                
            }
            yield return new WaitForSeconds(waitTime);
            for (int i = 0; i < 31; i++)
            {
                Debug.Log("test");
                GameObject bul = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 11 * i));
                bul.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul);
                bul.GetComponent<BulletScript>().getBulletType(bullType);

                //yield return new WaitForSeconds(waitTime);
            }
            yield return new WaitForSeconds(waitTime);
            for (int i = 0; i < 31; i++)
            {
                Debug.Log("test");
                GameObject bul = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 11 * i));
                bul.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul);
                bul.GetComponent<BulletScript>().getBulletType(bullType);

                //yield return new WaitForSeconds(waitTime);
            }
        }

        if (spreadType.Equals("test2"))
        {
            lockPos = true;
            for (int i = 0; i < 20; i++)
            {
                Debug.Log("test");
                GameObject bul1 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 7.2f ));
                bul1.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul1);
                bul1.GetComponent<BulletScript>().getBulletType(bullType);

                GameObject bul2 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 97.2f));
                bul2.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul2);
                bul2.GetComponent<BulletScript>().getBulletType(bullType);

                GameObject bul3 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 187.2f));
                bul3.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul3);
                bul3.GetComponent<BulletScript>().getBulletType(bullType);

                GameObject bul4 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 277.2f ));
                bul4.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul4);
                bul4.GetComponent<BulletScript>().getBulletType(bullType);


                yield return new WaitForSeconds(waitTime);
            }
        }

        if (spreadType.Equals("test3"))
        {
            lockPos = true;
            for (int i = 0; i < 20; i++)
            {
                Debug.Log("test");
                GameObject bul1 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 7.2f*i));
                bul1.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul1);
                bul1.GetComponent<BulletScript>().getBulletType(bullType);

                GameObject bul2 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 97.2f*i));
                bul2.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul2);
                bul2.GetComponent<BulletScript>().getBulletType(bullType);

                GameObject bul3 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 187.2f*i));
                bul3.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul3);
                bul3.GetComponent<BulletScript>().getBulletType(bullType);

                GameObject bul4 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 277.2f*i));
                bul4.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul4);
                bul4.GetComponent<BulletScript>().getBulletType(bullType);

                yield return new WaitForSeconds(waitTime);
            }
        }

        if (spreadType.Equals("test4"))
        {
            lockPos = true;
            for (int i = 0; i < 20; i++)
            {
                Debug.Log("test");
                GameObject bul1 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 7.2f * i));
                bul1.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul1);
                bul1.GetComponent<BulletScript>().getBulletType(bullType);

                GameObject bul2 = Instantiate(bullet, new Vector2(this.transform.position.x + 5, this.transform.position.y), Quaternion.Euler(0, 0, 97.2f * i));
                bul2.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul2);
                bul2.GetComponent<BulletScript>().getBulletType(bullType);

                GameObject bul3 = Instantiate(bullet, new Vector2(this.transform.position.x - 5, this.transform.position.y), Quaternion.Euler(0, 0, 187.2f * i));
                bul3.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul3);
                bul3.GetComponent<BulletScript>().getBulletType(bullType);

                GameObject bul4 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 277.2f * i));
                bul4.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul4);
                bul4.GetComponent<BulletScript>().getBulletType(bullType);


            

                yield return new WaitForSeconds(waitTime);
            }
        }

        if (spreadType.Equals("test5"))
        {
            lockPos = true;
            for (int i = 0; i < 50; i++)
            {
                Debug.Log("test");
                GameObject bul = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 7.2f * i));
                bul.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul);
                bul.GetComponent<BulletScript>().getBulletType(bullType);

                GameObject bul1 = Instantiate(bullet, new Vector2(this.transform.position.x-5, this.transform.position.y), Quaternion.Euler(0, 0, 7.2f * i));
                bul.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul1);
                bul1.GetComponent<BulletScript>().getBulletType(bullType);

                GameObject bul2 = Instantiate(bullet, new Vector2(this.transform.position.x+5, this.transform.position.y), Quaternion.Euler(0, 0, 7.2f * i));
                bul2.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul2);
                bul2.GetComponent<BulletScript>().getBulletType(bullType);

                yield return new WaitForSeconds(waitTime);
            }

        }


        if (spreadType.Equals("test6"))
        {
            lockPos = true;
            for (int i = 0; i < 30; i++)
            {
                Debug.Log("test6");
                GameObject bul = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 11 * i));
                bul.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul);
                bul.GetComponent<BulletScript>().getBulletType(bullType);

                GameObject bul2 = Instantiate(bullet, new Vector2(this.transform.position.x +5, this.transform.position.y), Quaternion.Euler(0, 0, 11 * i));
                bul2.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul2);
                bul2.GetComponent<BulletScript>().getBulletType(bullType);

                GameObject bul3 = Instantiate(bullet, new Vector2(this.transform.position.x-5, this.transform.position.y), Quaternion.Euler(0, 0, 11 * i));
                bul3.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul3);
                bul3.GetComponent<BulletScript>().getBulletType(bullType);

                //yield return new WaitForSeconds(waitTime);
            }
        }

        if (spreadType.Equals("test4"))
        {
            lockPos = true;
            for (int i = 0; i < 20; i++)
            {
                Debug.Log("test");
                GameObject bul1 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 7.2f * i));
                bul1.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul1);
                bul1.GetComponent<BulletScript>().getBulletType(bullType);

                GameObject bul2 = Instantiate(bullet, new Vector2(this.transform.position.x + 5, this.transform.position.y), Quaternion.Euler(0, 0, 97.2f * i));
                bul2.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul2);
                bul2.GetComponent<BulletScript>().getBulletType(bullType);

                GameObject bul3 = Instantiate(bullet, new Vector2(this.transform.position.x - 5, this.transform.position.y), Quaternion.Euler(0, 0, 187.2f * i));
                bul3.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul3);
                bul3.GetComponent<BulletScript>().getBulletType(bullType);

                GameObject bul4 = Instantiate(bullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 277.2f * i));
                bul4.GetComponent<BulletScript>().GetPlayerId(playerPeerId);
                bulletmanager.GetComponent<BulletManager>().AddBulletToList(bul4);
                bul4.GetComponent<BulletScript>().getBulletType(bullType);




                yield return new WaitForSeconds(waitTime);
            }
        }



        lockPos = false;


    }
}
