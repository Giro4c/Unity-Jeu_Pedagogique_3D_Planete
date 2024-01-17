using UnityEngine;
using UnityEngine.Assertions.Must;

public class RotationOrOrbitDetector : MonoBehaviour
{
    
    public bool detectorActivated = true;
    public bool automotionActivated = true;
    
    [Header("Rotation Scripts")]
    [SerializeField] private RotationDrag rotationDragScript;
    [SerializeField] private RotationAuto rotationAutoScript;
    
    [Header("Orbit Scripts")]
    [SerializeField] private OrbitMotion orbitMotionScript;
    [SerializeField] private OrbitDrag orbitDragScript;
    
    [Header("Sliders Scripts")]
    [SerializeField] private SliderOrbitDrag sliderOrbitScript;
    [SerializeField] private SliderRotationDrag sliderRotationScript;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Script RotationOrOrbitDetector activé.");
        // Rotation Drag
        if (!rotationDragScript)
        {
            rotationDragScript = gameObject.GetComponent<RotationDrag>();
        }
        rotationDragScript.enabled = false;
        // Rotation Auto
        if (!rotationAutoScript)
        {
            rotationAutoScript = gameObject.GetComponent<RotationAuto>();
        }
        rotationAutoScript.enabled = true;
        // Orbit Motion
        if (!orbitMotionScript)
        {
            orbitMotionScript = gameObject.GetComponentInParent<OrbitMotion>();
        }
        orbitMotionScript.enabled = true;
        // Orbit Drag
        if (!orbitDragScript)
        {
            orbitDragScript = gameObject.GetComponentInParent<OrbitDrag>();
        }
        orbitDragScript.enabled = false;
        // Slider Orbit
        if (!sliderOrbitScript)
        {
            sliderOrbitScript = GameObject.Find("Month Slider").GetComponent<SliderOrbitDrag>();
        }
        sliderOrbitScript.enabled = true;
        sliderOrbitScript.SetAutoMotion(true);
        // Slider Rotation
        if (!sliderRotationScript)
        {
            sliderRotationScript = GameObject.Find("Hour Slider").GetComponent<SliderRotationDrag>();
        }
        sliderRotationScript.enabled = true;
        sliderRotationScript.SetAutoMotion(true);
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

    public void ActivateDetector()
    {
        detectorActivated = true;
        // Reactivate sliders scripts
        sliderRotationScript.enabled = true;
        sliderOrbitScript.enabled = true;
    }

    public void DeactivateDetector()
    {
        detectorActivated = false;
        // Deactivate sliders scripts
        sliderRotationScript.enabled = false;
        sliderOrbitScript.enabled = false;
    }

    public void DeactivateAllScriptsOrbit()
    {
        orbitDragScript.enabled = false;
        orbitMotionScript.enabled = false;
    }
    
    public void DeactivateAllScriptsRotation()
    {
        rotationDragScript.enabled = false;
        rotationAutoScript.enabled = false;
    }

    public void ActivateAutoMotion()
    {
        automotionActivated = true;
        
        orbitMotionScript.enabled = true;
        rotationAutoScript.enabled = true;
        sliderRotationScript.SetAutoMotion(true);
        sliderOrbitScript.SetAutoMotion(true);
    }
    
    public void DeactivateAutoMotion()
    {
        automotionActivated = false;
        
        orbitMotionScript.enabled = false;
        rotationAutoScript.enabled = false;
        sliderRotationScript.SetAutoMotion(false);
        sliderOrbitScript.SetAutoMotion(false);
    }
    
    public void ActivateAll()
    {
        ActivateDetector();
        ActivateAutoMotion();
    }

    public void DeactivateAll()
    {
        DeactivateDetector();
        DeactivateAutoMotion();
    }

}
