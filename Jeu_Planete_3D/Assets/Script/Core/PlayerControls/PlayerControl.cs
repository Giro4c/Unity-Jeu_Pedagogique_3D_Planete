

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public abstract class PlayerControl: MonoBehaviour, ActivationRestrictable
{

    [SerializeField] protected string type;
    [SerializeField] protected string typeSimplified;
    [SerializeField] protected InputActionProperty trigger;
    protected Coroutine routine = null;
    
    protected bool finished = false;
    public bool activationRestricted { get; set; } = false;
    
    [SerializeField] protected bool registerable;
    
    [SerializeField] public string[] scriptsToEnable;
    [SerializeField] public string[] scriptsToDisable;
    
    public void Activate(bool activation)
    {
        enabled = activation;
    }

    public string GetControlType()
    {
        return type;
    }
    
    public string GetControlTypeSimplified()
    {
        return typeSimplified;
    }

    public bool IsRegisterable()
    {
        return registerable;
    }

    public void SetRegisterable(bool val)
    {
        registerable = val;
    }
    
    protected IEnumerator Control()
    {
        finished = false;
        Debug.Log("Player Control enabled");
        while (enabled && IsControlActive())
        {
            ProcessingInput();
            yield return null;
        }
        finished = true;
        enabled = false;
    }

    protected void OnEnableProcedure()
    {
        if (activationRestricted)
        {
            enabled = false;
            return;
        }
        
        // Start the coroutine
        routine = StartCoroutine(Control());
    }
    
    protected void OnDisableProcedure()
    {
        if (routine == null) return;
        // Stop the coroutine if it was started already
        StopCoroutine(routine);
        routine = null;
    }
    
    protected abstract void ProcessingInput();

    public virtual bool IsControlActive()
    {
        return trigger.action.IsPressed();
    }

    public virtual bool IsTriggered()
    {
        // Debug.Log(type + " -- " + trigger.action.triggered);
        // Debug.Log(type + " -- " + trigger.action.IsPressed());
        return !activationRestricted && trigger.action.IsPressed();
    }

    public bool IsFinished()
    {
        return finished;
    }

    public void SetFinished(bool val)
    {
        finished = val;
    }
    
    private void OnEnable()
    {
        OnEnableProcedure();
    }
    
    private void OnDisable()
    {
        OnDisableProcedure();
    }

    
    
}
