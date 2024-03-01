

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[Serializable]
public abstract class PlayerControl: MonoBehaviour, IdentifiableRestrictable
{
    
    // Interface implementation ---------------
    [SerializeField] protected string identifier = "None";
    public bool activationRestricted { get; set; } = false;
    [SerializeField] private bool _defaultActivation = false;
    
    public void Activate(bool activation)
    {
        enabled = activation;
    }

    public string GetIdentifier()
    {
        return identifier;
    }

    public bool MatchRegex(string[] identifiers)
    {
        return IdentifiableRestrictable.MatchRegex(GetIdentifier(), identifiers);
    }

    public bool GetDefaultActivation()
    {
        return _defaultActivation;
    }

    // ----------------------------------------------
    [SerializeField] protected string typeSimplified;
    [SerializeField] protected InputActionProperty trigger;
    protected Coroutine routine = null;
    protected bool finished = false;
        
    [SerializeField] protected bool registerable;
    
    [FormerlySerializedAs("scriptsToEnable")] [SerializeField] public string[] toEnable;
    [FormerlySerializedAs("scriptsToDisable")] [SerializeField] public string[] toDisable;
    
    
    
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
