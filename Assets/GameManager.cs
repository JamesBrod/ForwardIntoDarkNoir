using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject EnemyManager;
    public GameObject BulletManager;
    public GameObject MusicManager;
    public GameObject PlayerChar;
    public GameObject GameCanvas;


	// Use this for initialization
	void Start ()
    {
        Instantiate(EnemyManager);
        Instantiate(BulletManager);
        Instantiate(MusicManager);
        Instantiate(GameCanvas);

    }
	
	// Update is called once per frame
	void Update ()
    {
       
    }

    public void PopulateGame()
    {
        Debug.Log("ping");
        MusicManager.SetActive(true);
        GameObject go = Instantiate(PlayerChar);
        go.transform.position = new Vector2(0, 0);
        EnemyManager.GetComponent<EnemyManagerScript>().SetGameRunning();


    }
}
