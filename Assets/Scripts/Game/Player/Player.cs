using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //variables
    public GameObject projectilePrefab; // prefab to spawn (add this by drag and drop in unity)
    public float movementSpeed = 10f;
    public float rotationSpeed = 230f;
    private Rigidbody2D rigid;
    
    
    
    // Use this for initialization
	void Start () {
        rigid = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        Control();
	}

    void Control()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //shoot a projectile
            Shoot();
        }

        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        //rotate to left / right
        this.transform.Rotate(Vector3.back, inputHorizontal * rotationSpeed * Time.deltaTime);
        //forward backwards
        rigid.AddForce(inputVertical*transform.up*movementSpeed);
    }

    public void Shoot()
    {
        //spawn projectile in position and rotation of player
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

        //call fire method in projectile
        projectile.GetComponent<Projectile>().Fire(this.transform.up);
    }
}
