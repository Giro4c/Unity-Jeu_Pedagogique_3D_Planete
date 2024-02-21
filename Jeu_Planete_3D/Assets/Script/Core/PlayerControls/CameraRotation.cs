using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRotation : PlayerControl
{
    // Camera constraint to avoid inverting the camera
    private const float MAX_BORNE_X = 310;
    private const float MIN_BORNE_X = 50;
    private const float MEDIAN_BORNE_X = MAX_BORNE_X - MIN_BORNE_X;
    protected EventSystem _eventSys;
    protected Camera _cam;
    
    private float speed = 5;

    protected override void ProcessingInput()
    {
        Vector3 newAngle = transform.eulerAngles + ( speed * new Vector3(Input.GetAxis("Mouse Y"), -1 * Input.GetAxis("Mouse X"), 0));
        newAngle.x = AdjustXAngleToBoundaries(newAngle.x);
        _cam.transform.eulerAngles = newAngle;
    }

    public override bool IsTriggered()
    {
        // Verifying if there is a UI object in front of the mouse
        bool UICollision = _eventSys.IsPointerOverGameObject();
        // Does the ray intersect any objects excluding the hidden layers
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool colliderCollision = Physics.Raycast(mouseRay, out hit);
        // Final verification
        return base.IsTriggered() && !UICollision && !colliderCollision;
    }
    
    // public override bool IsControlActive()
    // {
    //     throw new System.NotImplementedException();
    // }
    

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
