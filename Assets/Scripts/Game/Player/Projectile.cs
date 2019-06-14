using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    #region Variables
    public float speed; // speed of the bullet
    Rigidbody2D rigid; // reference to the projectiles rigidbody (this script will be on rigid body
    #endregion

    // Use this for initialization
    void Awake () {
        rigid = this.GetComponent<Rigidbody2D>();

	}
	
	public void Fire(Vector3 dir)
    {
        //add force in a given diraction
        rigid.AddForce(dir*speed, ForceMode2D.Impulse); //impulse delivers the whole force at once
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Asteroid asteroidScript = collision.GetComponent<Asteroid>();

        if (asteroidScript)
        {
            //destroy the asteroid by calling its Destroy()
            asteroidScript.Destroy();

            //destroy self (this projectile)
            Destroy(gameObject);
        }
    }
}
