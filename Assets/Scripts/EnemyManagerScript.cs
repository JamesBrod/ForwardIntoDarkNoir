using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyManagerScript : MonoBehaviour {

    public GameObject enemy;
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject bulletmanager;
    public double score = 0;
    public Text scoreText;
    private bool gameover = true;
    private bool gamerunning = false;

    public GameObject gameovertext;

    // Use this for initialization
    void Start ()
    {
        gamerunning = false;
        bulletmanager = GameObject.FindGameObjectWithTag("BulletManager");

    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(gamerunning);
        if (enemies.Count < 3 && gamerunning)
        {
            Spawn();
        }

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        //}

        if (Input.GetKeyDown(KeyCode.R))
        {
            PauseGame();
        }

        scoreText.text = "Score:" + score.ToString();

        //should mega attacks be tracked here and triggered on individual enemies?
        //Pros: Less chance of cluster of mega attacks, easier on player
        //Cons: Looks less cool

    }

    private void FixedUpdate()
    {
        if(!gameover)
        score++;

        Debug.Log(gamerunning);
    }



    void Spawn()
    {
      int posx =  Random.Range(-17, 17);
       int posy =  Random.Range(-6, 13);
        GameObject go = Instantiate(enemy, new Vector2(posx, posy), Quaternion.identity);
        enemies.Add(go);
        
    }

   public void RemoveEnemy(GameObject s)
    {
        if(enemies.Contains(s))
        enemies.Remove(s);
        
        score += 1000;
    }

    public void GameOver()
    {
        
        gameovertext.SetActive(true);
        gameover = true;
    }

    public void PauseGame()
    {
        foreach(GameObject g in enemies)
        {
            g.GetComponent<EnemyScript>().gamePaused = ! g.GetComponent<EnemyScript>().gamePaused;
            
        }

        GameObject go = GameObject.FindGameObjectWithTag("Player");
        go.GetComponent<PlayerMovement>().gamePaused = !go.GetComponent<PlayerMovement>().gamePaused;
        bulletmanager.GetComponent<BulletManager>().PauseGame();

    }

    public void EnemyfromOffScreen()
    {
        //Get X, Y Coordinates which are offscreen

        //Movement should automatically set it to continue onscreen

        //Set bullets and specials to not fire until on screen

    }

    public void SetGameRunning()
    {
        Debug.Log(gamerunning);
        gamerunning = true;
        Debug.Log(gamerunning);
    }
    
}
