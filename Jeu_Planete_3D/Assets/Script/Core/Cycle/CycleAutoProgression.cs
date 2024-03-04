using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleAutoProgression : MonoBehaviour, IdentifiableRestrictable
{
    
    protected bool _active = true;
    [SerializeField] protected Cycle cycle;
    private Coroutine _routine;
    
    // Interface implementation ---------------
    [SerializeField] private string identifier = "None";
    public bool activationRestricted { get; set; }
    [SerializeField] private bool _defaultActivation = true;

    
    public void Activate(bool activation)
    {
        enabled = activation;
    }

    public string GetIdentifier()
    {
        return identifier;
    }
    
    public bool GetDefaultActivation()
    {
        return _defaultActivation;
    }
    
    // ----------------------------------------------
    
    private void Start()
    {
        _active = CanBeEnabled();
        enabled = _active;
    }

    public virtual bool CanBeEnabled()
    {
        if (cycle == null)
        {
            cycle = gameObject.GetComponent<Cycle>();
            if (cycle == null) return false;
        }

        return true;
    }

    private void OnEnable()
    {
        _active = CanBeEnabled();
        enabled = _active;
        if (!enabled) return;
        cycle.SetPositionAndRotationInCycle();
        _routine = StartCoroutine(AnimateCycle());
    }

    private void OnDisable()
    {
        _active = false;
        StopCoroutine(_routine);
    }

    protected virtual IEnumerator AnimateCycle()
    {
        // if (cycle.GetPeriod() < 0.1f)
        // {
        //     cycle.SetPeriod(0.1f);
        // }
        while (_active)
        {
            UpdateProgress();
            cycle.SetPositionAndRotationInCycle();
            yield return null;
        }
    }

    public virtual void UpdateProgress()
    {
        float cycleSpeed = 1f / cycle.GetPeriod();
        cycle.SetProgress((cycle.GetProgress() + Time.deltaTime * cycleSpeed)%1f);
    }
    
}
