using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBorder : MonoBehaviour {

    //variables
    public float padding = 10f; // padding from border to trigger destruction of this object
    public Color debugColor = Color.red;
    Bounds camBounds;

    // Use this for initialization
    void Awake () {
        camBounds = Camera.main.GetBounds(padding);
    }
	
	// Update is called once per frame
	void Update () {

        //if this projectiles position is out of bounds
        if (!camBounds.Contains(this.transform.position))
        {
            //Destroy it
            Destroy(gameObject);
        }
	}

    #region Gizmo
    private void OnDrawGizmos()
    {
        //get camera bounds with padding
       

        Gizmos.color = debugColor;
        Gizmos.DrawWireCube(camBounds.center, camBounds.size);
    }
    #endregion
}
