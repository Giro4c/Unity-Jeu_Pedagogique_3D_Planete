using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // Camera constraint to avoid inverting the camera
    private const float MAX_BORNE_X = 310;
    private const float MIN_BORNE_X = 50;
    private const float MEDIAN_BORNE_X = MAX_BORNE_X - MIN_BORNE_X;
    
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0) && !Physics.Raycast(transform.position, Input.mousePosition, 100))
        {
            Vector3 newAngle = transform.eulerAngles + ( speed * new Vector3(Input.GetAxis("Mouse Y"), -1 * Input.GetAxis("Mouse X"), 0));

            newAngle.x = AdjustXAngleToBoundaries(newAngle.x);

            transform.eulerAngles = newAngle;

        }
    }

    /**
     * Verifies if the given x angle is within the camera boundaries and correct the value if not.
     * @param float x The x value of the new camera angle
     * @returns Returns x unchanged if the boundaries are respected. If not returns the bound closest to x.
     */
    private float AdjustXAngleToBoundaries(float x)
    {
        if (x > MIN_BORNE_X && x <= MEDIAN_BORNE_X)
        {
            return MIN_BORNE_X;
        }
        else if (x > MEDIAN_BORNE_X && x < MAX_BORNE_X)
        {
            return MAX_BORNE_X;
        }
        else
        {
            return x;
        }
    }
}
