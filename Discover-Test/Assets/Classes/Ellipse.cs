using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ellipse
{

    public float xAxis = 3f;
    public float yAxis = 5f;

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
        float x = Mathf.Cos(angle) * xAxis;
        float y = Mathf.Sin(angle) * yAxis;
        return new Vector2(x, y);
    }

    public float FindProgressUsingX(float x, float y)
    {
        float angleX = Mathf.Acos(x / xAxis);
        float verifAngleY = Mathf.Asin(y / yAxis);
        
        // Verification if angle must be changed
        if (verifAngleY < 0)
        {
            if (xAxis >= 0)
            {
                angleX = (Mathf.Deg2Rad * 360f) - angleX;
            }
            else
            {
                angleX = (Mathf.Deg2Rad * 180f) + angleX;
            }
        }
        //else: if (verifAngle >= 0) Do nothing;
        
        // Find progress
        float progress = (Mathf.Rad2Deg * angleX) / 360f;
        
        return progress%1f;
        
    }
    
    /*public float FindProgressUsingY(float x, float y)
    {
        // Simple values verification
        if (y >= yAxis)
        {
            return 0.25f;
        }
        if (y <= yAxis * -1)
        {
            return 0.75f;
        }

        // Find progress
        float angle = Mathf.Asin(y / yAxis);
        float progress = angle / (Mathf.Deg2Rad * 360f);
        if (x < 0) return (0.5f - progress)%1f;
        return progress;
    }*/

}
