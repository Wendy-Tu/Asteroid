using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    //variables
    public GameObject[] asteroidPieces; // drag drop??
    public int spawnAmount = 4;
    public float maxVelocity = 3f;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //spawns a random asteroid 
    void Spawn()
    {
        // generate random index
        int randomIndex = Random.Range(0, asteroidPieces.Length);

        //select random asteroid piece
        GameObject asteroid = asteroidPieces[randomIndex];

        //ask the asteroid manager to spawn a new asteroid piece at a posistion
        //asking the Singleton
        AsteroidManagerB.Spawn(asteroid, this.transform.position);
    }

    public void Destroy()
    {
        // destroy seld
        Destroy(gameObject);

        if (asteroidPieces.Length > 0)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                //spawn an asteroid
                Spawn();
            }
        }
    }

    
}
