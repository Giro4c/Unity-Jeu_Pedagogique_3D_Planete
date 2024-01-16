using UnityEngine;
using UnityEngine.Assertions.Must;

public abstract class Detector : MonoBehaviour
{

    public bool detectorActivated = true;
    public bool automotionActivated = true;
    
    public virtual void ActivateDetector()
    {
        detectorActivated = true;
    }

    public virtual void DeactivateDetector()
    {
        detectorActivated = false;
    }

    public virtual void ActivateAutoMotion()
    {
        automotionActivated = true;
    }
    
    public virtual void DeactivateAutoMotion()
    {
        automotionActivated = false;
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

    public abstract void DeactivateAllScriptsOrbit();

    public abstract void DeactivateAllScriptsRotation();
    
}
