using UnityEngine;
using UnityEngine.Assertions.Must;

public class RotationOrOrbitDetector : Detector
{
    // SolarSystem
    private RotationDrag rotationDragScript;
    private RotationAuto rotationAutoScript;
    private OrbitMotion orbitMotionScript;
    private OrbitDrag orbitDragScript;
    // Sliders
    private SliderOrbitDrag sliderOrbitScript;
    private SliderRotationDrag sliderRotationScript;
    
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
        sliderOrbitScript = GameObject.Find("Month Slider").GetComponent<SliderOrbitDrag>();
        sliderOrbitScript.enabled = true;
        sliderRotationScript = GameObject.Find("Hour Slider").GetComponent<SliderRotationDrag>();
        sliderRotationScript.enabled = true;
    }

    // Used for scripts that continue to run until certain action
    private void Update()
    {
        if (!detectorActivated) return;
        if (Input.GetMouseButtonUp(1) && !orbitMotionScript.enabled)
        {
            
            orbitDragScript.enabled = false;
            if (automotionActivated)
            {
                orbitMotionScript.enabled = true;
                //Debug.Log("Orbit Auto Enabled");
            }
            
        }
    }

    private void OnMouseOver()
    {
        if (!detectorActivated) return;
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
            if (automotionActivated)
            {
                rotationAutoScript.enabled = true;
                orbitMotionScript.enabled = true;
            }
            
        }
        
    }

    private void OnMouseExit()
    {
        if (!detectorActivated) return;
        if (rotationDragScript)
        {
            rotationDragScript.enabled = false;
        }

        if (automotionActivated && !rotationAutoScript)
        {
            rotationAutoScript.enabled = true;
            orbitMotionScript.enabled = true;
        }
        
    }

    public override void ActivateDetector()
    {
        base.ActivateDetector();
        // Reactivate sliders scripts
        sliderRotationScript.enabled = true;
        sliderOrbitScript.enabled = true;
    }

    public override void DeactivateDetector()
    {
        base.DeactivateDetector();
        // Deactivate sliders scripts
        sliderRotationScript.enabled = false;
        sliderOrbitScript.enabled = false;
    }

    public override void DeactivateAllScriptsOrbit()
    {
        orbitDragScript.enabled = false;
        orbitMotionScript.enabled = false;
    }
    
    public override void DeactivateAllScriptsRotation()
    {
        rotationDragScript.enabled = false;
        rotationAutoScript.enabled = false;
    }

    public override void ActivateAutoMotion()
    {
        base.ActivateAutoMotion();
        
        orbitMotionScript.enabled = true;
        rotationAutoScript.enabled = true;
        sliderRotationScript.SetAutoMotion(true);
        sliderOrbitScript.SetAutoMotion(true);
    }
    
    public override void DeactivateAutoMotion()
    {
        base.DeactivateAutoMotion();
        
        orbitMotionScript.enabled = false;
        rotationAutoScript.enabled = false;
        sliderRotationScript.SetAutoMotion(false);
        sliderOrbitScript.SetAutoMotion(false);
    }

}
