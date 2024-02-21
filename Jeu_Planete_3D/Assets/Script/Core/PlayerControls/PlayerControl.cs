

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerControl: MonoBehaviour, ActivationRestrictable
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
        return type;
    }

    public bool GetRegisterable()
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
     
        // Enable all designed scripts if their activation/deactivation is not restricted
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

    public bool IsRegisterable()
    {
        return registerable;
    }

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

    public void SetActivationRestrictions(bool restricted, string regexIdentifier)
    {
        // Look into scripts to enable
        foreach (Tuple<string, ActivationRestrictable> script in scriptsToEnable)
        {
            if (script.Item1.Equals(regexIdentifier))
            {
                if (restricted)
                {
                    script.Item2.Activate(false);
                }
                script.Item2.activationRestricted = restricted;
                // If the interaction is in progress, enable the script as soon as possible
                if (!restricted && enabled)
                {
                    script.Item2.Activate(true);
                }
            }
            
        }
        // Look into scripts to disable
        foreach (Tuple<string, ActivationRestrictable> script in scriptsToDisable)
        {
            if (script.Item1.Equals(regexIdentifier))
            {
                if (restricted)
                {
                    script.Item2.Activate(false);
                }
                script.Item2.activationRestricted = restricted;
            }
            // If the interaction is not in progress, enable the script as soon as possible
            if (!restricted && !enabled)
            {
                script.Item2.Activate(true);
            }
        }
        // // Look into interactions to disable
        // foreach (PlayerControl control in controlsToDisable)
        // {
        //     if (control.type.Equals(regexIdentifier))
        //     {
        //         if (restricted)
        //         {
        //             control.Activate(false);
        //         }
        //         control.activationRestricted = restricted;
        //     }
        // }
        
    }
    
    public void SetActivationRestrictions(bool restricted, string[] regexIdentifiers)
    {
        // Look into scripts to enable
        foreach (Tuple<string, ActivationRestrictable> script in scriptsToEnable)
        {
            if (MatchIdentifiers(script.Item1, regexIdentifiers))
            {
                if (restricted)
                {
                    script.Item2.Activate(false);
                }
                script.Item2.activationRestricted = restricted;
                // If the interaction is in progress, enable the script as soon as possible
                if (!restricted && enabled)
                {
                    script.Item2.Activate(true);
                }
            }
            
        }
        // Look into scripts to disable
        foreach (Tuple<string, ActivationRestrictable> script in scriptsToDisable)
        {
            if (MatchIdentifiers(script.Item1, regexIdentifiers))
            {
                if (restricted)
                {
                    script.Item2.Activate(false);
                }
                script.Item2.activationRestricted = restricted;
                // If the interaction is not in progress, enable the script as soon as possible
                if (!restricted && !enabled)
                {
                    script.Item2.Activate(true);
                }
            }
        }
        // Look into interactions to disable
        // foreach (PlayerControl control in controlsToDisable)
        // {
        //     if (MatchIdentifiers(control.type, regexIdentifiers))
        //     {
        //         if (restricted)
        //         {
        //             control.Activate(false);
        //         }
        //         control.activationRestricted = restricted;
        //     }
        // }
        
    }
    
    public void SetActivationRestrictions(bool restricted, int option)
    {
        if (option == 1) // Scripts to enable
        {
            foreach (Tuple<string, ActivationRestrictable> script in scriptsToEnable)
            {
                if (restricted)
                {
                    script.Item2.Activate(false);
                }
                script.Item2.activationRestricted = restricted;
                // If the interaction is in progress, enable the script as soon as possible
                if (!restricted && enabled)
                {
                    script.Item2.Activate(true);
                }
            }
        } 
        
        else if (option == 2) // Scripts to disable
        {
            foreach (Tuple<string, ActivationRestrictable> script in scriptsToDisable)
            {
                if (restricted)
                {
                    script.Item2.Activate(false);
                }
                script.Item2.activationRestricted = restricted;
                // If the interaction is not in progress, enable the script as soon as possible
                if (!restricted && !enabled)
                {
                    script.Item2.Activate(true);
                }
            }
        }
        
        // else if (option == 3) // Interactions to disable
        // {
        //     foreach (PlayerControl control in controlsToDisable)
        //     {
        //         if (restricted)
        //         {
        //             control.Activate(false);
        //         }
        //         control.activationRestricted = restricted;
        //     }
        // }
    }
    
    public void SetActivation(bool activation, string regexIdentifier)
    {
        // Look into scripts to enable
        foreach (Tuple<string, ActivationRestrictable> script in scriptsToEnable)
        {
            if (script.Item1.Equals(regexIdentifier))
            {
                if (script.Item2.activationRestricted || (activation && !enabled)) continue;
                script.Item2.Activate(activation);
            }
            
        }
        // Look into scripts to disable
        foreach (Tuple<string, ActivationRestrictable> script in scriptsToDisable)
        {
            if (script.Item1.Equals(regexIdentifier))
            {
                if (script.Item2.activationRestricted || (activation && enabled)) continue;
                script.Item2.Activate(activation);
            }
        }
        // Look into interactions to disable
        // foreach (PlayerControl control in controlsToDisable)
        // {
        //     if (control.type.Equals(regexIdentifier))
        //     {
        //         if (control.activationRestricted) continue;
        //         control.Activate(activation);
        //     }
        // }
        
    }
    
    public void SetActivation(bool activation, string[] regexIdentifiers)
    {
        // Look into scripts to enable
        foreach (Tuple<string, ActivationRestrictable> script in scriptsToEnable)
        {
            if (MatchIdentifiers(script.Item1, regexIdentifiers) || (activation && !enabled))
            {
                if (script.Item2.activationRestricted) continue;
                script.Item2.Activate(activation);
            }
            
        }
        // Look into scripts to disable
        foreach (Tuple<string, ActivationRestrictable> script in scriptsToDisable)
        {
            if (MatchIdentifiers(script.Item1, regexIdentifiers))
            {
                if (script.Item2.activationRestricted || (activation && enabled)) continue;
                script.Item2.Activate(activation);
            }
        }
        // Look into interactions to disable
        // foreach (PlayerControl control in controlsToDisable)
        // {
        //     if (MatchIdentifiers(control.type, regexIdentifiers))
        //     {
        //         if (control.activationRestricted) continue;
        //         control.Activate(activation);
        //     }
        // }
        
    }
    
    public void SetActivation(bool activation, int option)
    {
        if (option == 1) // Scripts to enable
        {
            foreach (Tuple<string, ActivationRestrictable> script in scriptsToEnable)
            {
                if (script.Item2.activationRestricted || (activation && !enabled)) continue;
                script.Item2.Activate(activation);
            }
        } 
        
        else if (option == 2) // Scripts to disable
        {
            foreach (Tuple<string, ActivationRestrictable> script in scriptsToDisable)
            {
                if (script.Item2.activationRestricted || (activation && enabled)) continue;
                script.Item2.Activate(activation);
            }
        }
        
        // else if (option == 3) // Interactions to disable
        // {
        //     foreach (PlayerControl control in controlsToDisable)
        //     {
        //         if (control.activationRestricted) continue;
        //         control.Activate(activation);
        //     }
        // }
    }

    private void OnEnable()
    {
        OnEnableProcedure();
    }
    
    private void OnDisable()
    {
        OnDisableProcedure();
    }

    public static bool MatchIdentifiers(string name, string[] identifiers)
    {
        foreach (string identifier in identifiers)
        {
            if (!name.Contains(identifier)) return false;
        }

        return true;
    }
    
}
