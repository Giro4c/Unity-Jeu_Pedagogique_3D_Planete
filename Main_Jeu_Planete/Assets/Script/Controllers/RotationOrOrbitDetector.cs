using UnityEngine;

public class RotationOrOrbitDetector : MonoBehaviour
{
    private RotationDrag rotationDragScript;
    private RotationAuto rotationAutoScript;
    private OrbitMotion orbitMotionScript;
    private OrbitDrag orbitDragScript;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Script RotationOrOrbitDetector activé.");
        rotationDragScript = gameObject.GetComponent<RotationDrag>();
        rotationDragScript.enabled = false;
        rotationAutoScript = gameObject.GetComponent<RotationAuto>();
        rotationAutoScript.enabled = true;
        orbitMotionScript = gameObject.GetComponentInParent<OrbitMotion>();
        orbitMotionScript.enabled = true;
        orbitDragScript = gameObject.GetComponentInParent<OrbitDrag>();
        orbitDragScript.enabled = false;
    }

    // Used for scripts that continue to run until certain action
    private void Update()
    {
        
        if (Input.GetMouseButtonUp(1) && !orbitMotionScript.enabled)
        {
            Debug.Log("Orbit Auto Enabled");
            orbitDragScript.enabled = false;
            orbitMotionScript.enabled = true;
        }
    }

    private void OnMouseOver()
    {
        //Debug.Log("Mouse Over");
        // On Mouse Down
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("Rotation Auto Disabled");
            rotationDragScript.enabled = true;
            rotationAutoScript.enabled = false;
            orbitMotionScript.enabled = false;
        }
        else if (Input.GetMouseButton(1))
        {
            //Debug.Log("Orbit Auto Disabled");
            orbitDragScript.enabled = true;
            orbitMotionScript.enabled = false;
        }
        
        // On Mouse Up
        if (Input.GetMouseButtonUp(0) && rotationDragScript.enabled)
        {
            //Debug.Log("Rotation Auto Enabled");
            rotationDragScript.enabled = false;
            rotationAutoScript.enabled = true;
            orbitMotionScript.enabled = true;
        }
        
    }

    private void OnMouseExit()
    {
        if (rotationDragScript)
        {
            rotationDragScript.enabled = false;
        }

        if (!rotationAutoScript)
        {
            rotationAutoScript.enabled = true;
            orbitMotionScript.enabled = true;
        }
        
    }
}
