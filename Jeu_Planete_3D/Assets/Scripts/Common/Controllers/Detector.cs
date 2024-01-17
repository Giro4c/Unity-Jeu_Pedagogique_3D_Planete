using UnityEngine;
using UnityEngine.Assertions.Must;

public interface Detector
{

    void ActivateDetector();

    void DeactivateDetector();

    void ActivateAutoMotion();

    void DeactivateAutoMotion();

    void ActivateAll()
    {
        ActivateDetector();
        ActivateAutoMotion();
    }

    public void DeactivateAll()
    {
        DeactivateDetector();
        DeactivateAutoMotion();
    }

    public void DeactivateAllScriptsOrbit();

    public void DeactivateAllScriptsRotation();
    
}
