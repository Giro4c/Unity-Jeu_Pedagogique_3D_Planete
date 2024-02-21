using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ellipse
{

    [SerializeField] private float xAxis = 3f;
    [SerializeField] private float yAxis = 5f;

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
        float angle = Mathf.Deg2Rad * 360f * t;
        float x = Mathf.Cos(angle) * xAxis;
        float y = Mathf.Sin(angle) * yAxis;
        return new Vector2(x, y);
    }

    public float FindProgressUsingX(float x, float y)
    {
        // Verification if x and y values do not cause maths errors
        if ((xAxis >= 0 && x > xAxis) || (xAxis < 0 && x < xAxis))
        {
            x = xAxis;
        }
        if ((yAxis >= 0 && y > yAxis) || (yAxis < 0 && y < yAxis))
        {
            y = yAxis;
        }
        
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
    
    public float FindProgressUsingY(float x, float y)
    {
        // Verification if x and y values do not cause maths errors
        if ((xAxis >= 0 && x > xAxis) || (xAxis < 0 && x < xAxis))
        {
            x = xAxis;
        }
        if ((yAxis >= 0 && y > yAxis) || (yAxis < 0 && y < yAxis))
        {
            y = yAxis;
        }
        
        float verifAngleX = Mathf.Acos(x / xAxis);
        float angleY = Mathf.Asin(y / yAxis);
        
        // Verification if angle must be changed
        if (verifAngleX <= Mathf.Deg2Rad * 90f)
        {
            if (angleY < 0)
            {
                angleY = (Mathf.Deg2Rad * 360f) + angleY;
            }
            //else: if (angleY >= 0) Do nothing;
        }
        else
        {
            angleY = (Mathf.Deg2Rad * 180f) - angleY;
        }
        
        // Find progress
        float progress = (Mathf.Rad2Deg * angleY) / 360f;
        
        return progress%1f;
    }

    public float FindProgress(float x, float y)
    {
        float baseLength = Mathf.Sqrt(x * x + y * y);
        float angle = Mathf.Acos(x / baseLength);
        if (Mathf.Asin(y / baseLength) < 0)
        {
            angle = (Mathf.Deg2Rad * 360f) - angle;
        }
        float progress = (Mathf.Rad2Deg * angle) / 360f;
        return progress%1f;
    }

}
