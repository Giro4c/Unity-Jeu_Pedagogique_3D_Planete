using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleAutoMotion : MonoBehaviour, ActivationRestrictable
{
    
    private bool _active = true;
    [SerializeField] protected Cycle cycle;
    private Coroutine _routine;
    public bool activationRestricted { get; set; }
    public void Activate(bool activation)
    {
        enabled = activation;
    }
    
    private void Start()
    {
        _active = CanBeEnabled();
        enabled = _active;
    }

    public virtual bool CanBeEnabled()
    {
        if (cycle == null)
        {
            cycle = gameObject.GetComponent<Orbit>();
            if (cycle == null) return false;
        }

        return true;
    }

    private void OnEnable()
    {
        _active = CanBeEnabled();
        enabled = _active;
        if (!enabled) return;
        cycle.SetOrbitingObjectInCycle();
        _routine = StartCoroutine(AnimateCycle());
    }

    private void OnDisable()
    {
        _active = false;
        StopCoroutine(_routine);
    }

    IEnumerator AnimateCycle()
    {
        if (cycle.GetPeriod() < 0.1f)
        {
            cycle.SetPeriod(0.1f);
        }
        while (_active)
        {
            UpdateProgress();
            cycle.SetOrbitingObjectInCycle();
            yield return null;
        }
    }

    public virtual void UpdateProgress()
    {
        float cycleSpeed = 1f / cycle.GetPeriod();
        cycle.SetProgress((cycle.GetProgress() + Time.deltaTime * cycleSpeed)%1f);
    }
    
}
