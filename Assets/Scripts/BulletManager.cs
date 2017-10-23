using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

    public List<GameObject> bullets = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddBulletToList(GameObject bull)

    {
        bullets.Add(bull);
    }

    public void DestroyAllBullets()
    {
        foreach(GameObject b in bullets)
        {
            Debug.Log("boom");
           
            Destroy(b);
            
        }
        bullets.Clear();
    }

    public void PauseGame()
    {
        foreach(GameObject b in bullets)
        {
            if(b.GetComponent<BulletScript>() != null)
            {
                b.GetComponent<BulletScript>().gamePaused = !b.GetComponent<BulletScript>().gamePaused;
            }
            else if (b.GetComponent<EnemyBulletScript>() != null)
            {
                b.GetComponent<EnemyBulletScript>().PauseBullets();
            }
        }
    }
}
