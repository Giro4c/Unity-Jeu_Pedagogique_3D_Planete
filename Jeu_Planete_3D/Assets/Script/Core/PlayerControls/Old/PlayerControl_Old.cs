

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public abstract class PlayerControl_Old: MonoBehaviour, ActivationRestrictable
{

    [SerializeField] protected string type;
    [SerializeField] protected string typeSimplified;
    [SerializeField] protected InputActionProperty trigger;
    protected Coroutine routine = null;
    
    protected bool finished = false;
    public bool activationRestricted { get; set; }
    
    [SerializeField] protected bool registerable;
    
    [SerializeField] protected Tuple<string, ActivationRestrictable>[] scriptsToEnable;
    [SerializeField] protected Tuple<string, ActivationRestrictable>[] scriptsToDisable;
    
    // private bool _changesAllowedForScriptsToEnable = true;
    // private bool _changesAllowedForScriptsToDisable = true;
    
    // [SerializeField] protected PlayerControl[] controlsToDisable;
    // private bool _changesAllowedForControlsToDisable = true;

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
        foreach (Tuple<string, ActivationRestrictable> script in scriptsToEnable)
        {
            if (script.Item2.activationRestricted) continue;
            script.Item2.Activate(true);
        }
        
        // Disable all designed scripts if their activation/deactivation is not restricted
        foreach (Tuple<string, ActivationRestrictable> script in scriptsToDisable)
        {
            if (script.Item2.activationRestricted) continue;
            script.Item2.Activate(false);
        }
        
        // Block all designed interactions if their activation/deactivation is not restricted
        // SetChangesAllowedForAllInteractionsToDisable(false);
        
        // Start the coroutine
        routine = StartCoroutine(Control());
    }
    
    protected void OnDisableProcedure()
    {
        if (activationRestricted) return;
     
        // Enable all designed scripts if their activation/deactivation is not restricted
        foreach (Tuple<string, ActivationRestrictable> script in scriptsToEnable)
        {
            if (script.Item2.activationRestricted) continue;
            script.Item2.Activate(false);
        }
        
        // Disable all designed scripts if their activation/deactivation is not restricted
        foreach (Tuple<string, ActivationRestrictable> script in scriptsToDisable)
        {
            if (script.Item2.activationRestricted) continue;
            script.Item2.Activate(true);
        }
        
        // Unblock all designed interactions
        // SetChangesAllowedForAllInteractionsToDisable(true);
        
        // Stop the coroutine
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
        return !activationRestricted && !enabled && trigger.action.IsPressed();
    }

    public bool IsFinished()
    {
        return finished;
    }

    public void SetFinished(bool val)
    {
        finished = val;
    }

    /*
    public void SetChangesAllowedForAllScriptsToEnable(bool changesAllowed)
    {
        foreach (Tuple<string, ActivationRestrictable> script in scriptsToEnable)
        {
            if (!changesAllowed)
            {
                script.Item2.Activate(false);
            }
            script.Item2.activationRestricted = !changesAllowed;
        }
    }
    */
    
    /*
    public void SetChangesAllowedForAllScriptsToDisable(bool changesAllowed)
    {
        foreach (Tuple<string, ActivationRestrictable> script in scriptsToDisable)
        {
            if (!changesAllowed)
            {
                script.Item2.Activate(false);
            }
            script.Item2.activationRestricted = !changesAllowed;
        }
    }
    */

    /*
    public void SetChangesAllowedForAllInteractionsToDisable(bool changesAllowed)
    {
        foreach (PlayerControl control in controlsToDisable)
        {
            if (!changesAllowed)
            {
                control.Activate(false);
            }
            control.activationRestricted = !changesAllowed;
        }
    }
    */

    


    private void OnEnable()
    {
        OnEnableProcedure();
    }
    
    private void OnDisable()
    {
        OnDisableProcedure();
    }

    
    
}
