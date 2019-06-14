using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility {


    //calculates and returns a random postion on a bounds
    public static Vector3 GetRandomPosOnBounds(this Bounds bounds)
    {

        Vector3 result = Vector3.zero;
        //min max of bounds
        Vector3 min = bounds.min;
        Vector3 max = bounds.max;

        bool topOrBottom = Random.Range(0, 2) > 0;
        bool top = Random.Range(0, 2) > 0;
        bool right = Random.Range(0, 2) > 0;

        //top or bottom
        if (topOrBottom)
        {
            //get random range on x
            result.x = Random.Range(min.x, max.x);
            //top or bottom?
            result.y = top ? max.y : min.y;
        }
        //right or left
        else
        {
            //get random range on y
            result.y = Random.Range(min.y, max.y);
            //right or left?
            result.x = right ? max.x : min.x;
        }

        return result;
    }

    // this Camera cam  <<< a spacial way of making an extension method
    //Calculates and returns camera bounds with padding (defaults to 1f)
    public static Bounds GetBounds (this Camera cam, float padding = 1f)
    {
        //camera dimension floats
        float cameraHeight, cameraWidth;

        //get camera pos
        Vector3 camPos = cam.transform.position;

        //calculate height and width of camera
        cameraHeight = 2f * cam.orthographicSize;
        cameraWidth = cameraHeight * cam.aspect;

        //apply padding
        cameraHeight += padding;
        cameraWidth += padding;

        return new Bounds(camPos, new Vector3(cameraWidth, cameraHeight, 100));
    }
}
