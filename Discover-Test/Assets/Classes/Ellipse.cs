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
        float x = Mathf.Sin(angle) * xAxis;
        float y = Mathf.Cos(angle) * yAxis;
        return new Vector2(x, y);
    }

    public float FindProgressUsingX(float x, float y)
    {
        // Simple values verification
        if (x >= xAxis)
        {
            return 0;
        }
        if (x <= xAxis * -1)
        {
            return 0.5f;
        }

        // Find progress
        float angle = Mathf.Acos(x / xAxis);
        float progress = angle / (Mathf.Deg2Rad * 360f);
        if (y < 0) return (1f - progress)%1f;
        return progress%1f;
        
    }
    
    public float FindProgressUsingY(float x, float y)
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
    }

}
