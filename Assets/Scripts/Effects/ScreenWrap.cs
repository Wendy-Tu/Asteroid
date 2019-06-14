using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour {

    public float padding = 3f; //padding around the screen for screen wrapping
    public Color debugColor = Color.blue;

    public SpriteRenderer spriteRenderer;
    
    // Runs before start
	void Awake () {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        UpdatePosition();

    }

    private void OnDrawGizmos()
    {
        // get the bounds areound the camera with the given padding
        Bounds camBounds = Camera.main.GetBounds(padding);

        //then draw the camera bounds
        Gizmos.color = debugColor;
        Gizmos.DrawWireCube(camBounds.center, camBounds.size);
    }

    //update the position of Gameobject this script is attatched to
    void UpdatePosition()
    {
        // get the bounds areound the camera with the given padding
        Bounds camBounds = Camera.main.GetBounds(padding);

        // get this GameObjects position
        Vector3 pos = this.transform.position;

        // min max vectors for the bounds
        Vector3 min = camBounds.min;
        Vector3 max = camBounds.max;

        //check left
        if (pos.x < min.x)
        {
            pos.x = max.x;
        }

        //check right 
        if (pos.x > max.x)
        {
            pos.x = min.x;
        }

        //check up
        if (pos.y < min.y)
        {
            pos.y = max.y;
        }

        //check down
        if (pos.y > max.y)
        {
            pos.y = min.y;
        }


        //now that we have all adjustments
        //apply it to this Objects position
        this.transform.position = pos;

    }
}
