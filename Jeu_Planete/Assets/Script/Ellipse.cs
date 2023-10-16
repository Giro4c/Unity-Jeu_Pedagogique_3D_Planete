using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ellipse : MonoBehaviour
{

    public float xAxis;
    public float yAxis;

    // Constructors
    public Ellipse(float xAxis, float yAxis)
    {
        this.xAxis = xAxis;
        this.yAxis = yAxis;
    }
    
   

    /**
     * Calculate and returns the coordinates of the point on the ellipse corresponding the "progress" t.
     * @param float t Determines how far along on the ellipse we are. ( 0 <= t <= 1)
     * @returns A Vector2 that represents the coordinates of the point on the ellipse.
     */
    public Vector2 Evaluate(float t)
    {
        float angle = Mathf.Deg2Rad * 360 * t;
        float x = Mathf.Sin(angle) * xAxis;
        float y = Mathf.Cos(angle) * yAxis;
        return new Vector2(x, y);
    }
}
