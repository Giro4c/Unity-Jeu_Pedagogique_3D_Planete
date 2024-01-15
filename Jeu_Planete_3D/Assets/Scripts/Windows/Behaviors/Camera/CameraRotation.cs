using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRotation : MonoBehaviour
{
    // Camera constraint to avoid inverting the camera
    private const float MAX_BORNE_X = 310;
    private const float MIN_BORNE_X = 50;
    private const float MEDIAN_BORNE_X = MAX_BORNE_X - MIN_BORNE_X;
    private EventSystem _eventSys;
    
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        _eventSys = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Verifying if there is no UI object in front of the mouse
            if (_eventSys.Equals(null) || ! _eventSys.IsPointerOverGameObject())
            {
                // Verifying if there is no object in front of the mouse on the screen
                RaycastHit hit;
                Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                // Does the ray intersect any objects excluding the player layer
                if (!Physics.Raycast(mouseRay, out hit))
                {
                    //Debug.Log("Did Not Hit");
                
                    /* Change Camera angle :
                     Mouse Up -> Look Up
                     Mouse Down -> Look Down
                     Mouse Left -> Look Right
                     Mouse Right -> Look Left
                    */
                    Vector3 newAngle = transform.eulerAngles + ( speed * new Vector3(Input.GetAxis("Mouse Y"), -1 * Input.GetAxis("Mouse X"), 0));
                    newAngle.x = AdjustXAngleToBoundaries(newAngle.x);
                    transform.eulerAngles = newAngle;
                }
                else
                {
                    //Debug.Log("Did Hit");
                } 
            }
            else
            {
                //Debug.Log("Cursor on UI object");
            }

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
