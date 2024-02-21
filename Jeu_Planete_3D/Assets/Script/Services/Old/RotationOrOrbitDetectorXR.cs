/*
using Unity.VRTemplate;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;

public class RotationOrOrbitDetectorXR : MonoBehaviour
{
    public bool detectorActivated = true;
    public bool automotionActivated = true;
    
    [SerializeField] private Collider planet;
    
    [Header("Controllers")]
    [SerializeField] private ActionBasedController controllerRight;
    [SerializeField] private ActionBasedController controllerLeft;
    
    [Header("Ray Interactors")]
    [SerializeField] private XRRayInteractor rayInteractorRight;
    [SerializeField] private XRRayInteractor rayInteractorLeft;
    private RaycastHit hit;

    [Header("Rotation Scripts")]
    [SerializeField] private RotationDragXR rotationDragScript;
    [SerializeField] private XRKnob rotationKnob;
    [SerializeField] private RotationAuto rotationAutoScript;
    
    [Header("Orbit Scripts")]
    [SerializeField] private OrbitMotion orbitMotionScript;
    [SerializeField] private OrbitDragXR orbitDragScript;
    
    [Header("Sliders Scripts")]
    [SerializeField] private SliderOrbitDragXR sliderOrbitScript;
    [SerializeField] private SliderRotationDragXR sliderRotationScript;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        rotationDragScript.enabled = false;
        rotationAutoScript.enabled = true;
        orbitMotionScript.enabled = true;
        orbitDragScript.enabled = false;
        sliderOrbitScript.enabled = true;
        sliderRotationScript.enabled = true;
    }

    // Used for scripts that continue to run until certain action
    private void Update()
    {
        ActivationsCheck();
        DeactivationsCheck();
    }

    private void ActivationsCheck()
    {
        if (!detectorActivated) return;
        if (rayInteractorRight.TryGetCurrent3DRaycastHit(out hit) && hit.collider.Equals(planet))
        {
            // Action on planet orbit
            if (controllerRight.uiPressAction.action.IsPressed())
            {
                // Orbit Drab enabled
                orbitDragScript.enabled = true;
                // Orbit Motion disabled
                orbitMotionScript.enabled = false;
            }
            
            // Action on planet rotation
            if (controllerRight.selectAction.action.IsPressed())
            {
                // Rotation Drag enabled (update progress depending on Knob)
                rotationDragScript.enabled = true;
                // Rotation Auto disabled
                rotationAutoScript.enabled = false;
                // Orbit Motion disabled
                orbitMotionScript.enabled = false;
            }
        }
        if (rayInteractorLeft.TryGetCurrent3DRaycastHit(out hit) && hit.collider.Equals(planet))
        {
            // Action on planet orbit
            if (controllerLeft.uiPressAction.action.IsPressed())
            {
                // Orbit Drab enabled
                orbitDragScript.enabled = true;
                // Orbit Motion disabled
                orbitMotionScript.enabled = false;
            }
            
            // Action on planet rotation
            if (controllerLeft.selectAction.action.IsPressed())
            {
                // Rotation Drag enabled (update progress depending on Knob)
                rotationDragScript.enabled = true;
                // Rotation Auto disabled
                rotationAutoScript.enabled = false;
                // Orbit Motion disabled
                orbitMotionScript.enabled = false;
            }
        }
        
    }

    private void DeactivationsCheck()
    {
        // Action on planet orbit
        if ((controllerRight.uiPressAction.action.WasReleasedThisFrame() || controllerLeft.uiPressAction.action.WasReleasedThisFrame()) && orbitDragScript.enabled)
        {
            // Orbit Drag disabled
            orbitDragScript.enabled = false;
            
            if (automotionActivated)
            {
                // Orbit Motion enabled
                orbitMotionScript.enabled = true;
            }
            
        }
        
        // Action on planet rotation
        if ((controllerRight.selectAction.action.WasReleasedThisFrame() || controllerLeft.selectAction.action.WasReleasedThisFrame()) && rotationDragScript.enabled)
        {
            // Rotation Drag disabled
            rotationDragScript.enabled = false;
            
            if (automotionActivated)
            {
                // Rotation Auto enabled
                rotationAutoScript.enabled = true;
                // Orbit Motion enabled
                orbitMotionScript.enabled = true;
            }
            
        }
    }

    public void ActivateDetector()
    {
        detectorActivated = true;
        // Activate Knob
        rotationKnob.enabled = true;
        // Reactivate sliders scripts
        sliderRotationScript.enabled = true;
        sliderOrbitScript.enabled = true;
    }

    public void DeactivateDetector()
    {
        detectorActivated = false;
        // Deactivate Knob
        rotationKnob.enabled = false;
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
        rotationKnob.enabled = false;

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
*/
