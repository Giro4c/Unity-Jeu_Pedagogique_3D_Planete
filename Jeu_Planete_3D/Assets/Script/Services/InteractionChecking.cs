using System;
using Script.WebData;
using Unity.VisualScripting;
using UnityEngine;

namespace Script.Services
{
    public class InteractionChecking : MonoBehaviour
    {

        [SerializeField] private PlayerControl[] playerControls;
        private int indexCurrentActivatedControl = -1;

        public string[] restrictionsToEnable { get; private set; } = new string[0];
        public string[] restrictionsToDisable { get; private set; } = new string[0];

        // private IdentifiableRestrictable[] scripts;
        private Tuple<string, Boolean, MonoBehaviour>[] associationScripts = new Tuple<string, bool, MonoBehaviour>[0];

        // [SerializeField] [ExpectedType(typeof(WebDatabaseAccessInterface))]
        // private UnityEngine.Object _linkWeb;
        // private WebDatabaseAccessInterface linkWeb => _linkWeb as WebDatabaseAccessInterface;
        [SerializeReference] private WebDatabaseAccess linkWeb;

        
        /// <summary>
        /// <para>
        /// Initialize the service class based on the values stored in the 3 serializable arrays. The items of a Tuple number X are :<br/>
        /// - string from identifiers : the identifier of a script<br/>
        /// - bool from restrictionsActivation : whether or not the script's activation is restricted<br/>
        /// - MonoBehavior from scripts : the script<br/>
        /// Each at the index X in their respective array.
        /// </para>
        /// </summary>
        /// <param name="identifiers">Contains the identifier of an associated script</param>
        /// <param name="restrictionsActivation">Contains the activation restriction of an associated script</param>
        /// <param name="scripts">Contains the associated script</param>
        /// <exception cref="Exception">The arrays are not of the same size. The Tuple array cannot be initialized.</exception>
        public void Initialize(string[] identifiers, bool[] restrictionsActivation, MonoBehaviour[] scripts)
        {
            // Verify that all arrays are of the same size. If not then throw an exception
            if (identifiers.Length != restrictionsActivation.Length ||
                identifiers.Length != scripts.Length)
                throw new Exception(
                    "Arrays identifiers, restrictionsActivation and scripts must be of same length.");
            
            // Initialize size of Tuple array
            Tuple<string, Boolean, MonoBehaviour>[] array = new Tuple<string, Boolean, MonoBehaviour>[identifiers.Length];
            
            // Fill the Tuple array
            for (int i = 0; i < identifiers.Length; ++i)
            {
                array[i] = new Tuple<string, bool, MonoBehaviour>(identifiers[i],
                    restrictionsActivation[i], scripts[i]);
            }

            associationScripts = array;
        }
        
        public void NewRestrictions(string[] resEnable, string[] resDisable)
        {
            bool newRs = AreNewRestrictions(resEnable, resDisable);
            restrictionsToEnable = resEnable;
            restrictionsToDisable = resDisable;
            if (newRs)
            {
                ApplyRestrictions();
            }
        }

        private bool AreNewRestrictions(string[] resEnable, string[] resDisable)
        {
            
            // Verify if same size
            if (resEnable.Length != restrictionsToEnable.Length ||
                resDisable.Length != restrictionsToDisable.Length) return true;
            
            // Verify all elements identical in enable restrictions
            for (int i = 0; i < restrictionsToEnable.Length; ++i)
            {
                if (resEnable[i] != restrictionsToEnable[i]) return true;
            }
            // Verify all elements identical in disable restrictions
            for (int i = 0; i < restrictionsToDisable.Length; ++i)
            {
                if (resDisable[i] != restrictionsToDisable[i]) return true;
            }
            
            // Everything is identical
            return false;
        }
        
        public void ApplyRestrictions()
        {
            ApplyRestrictions(true, restrictionsToEnable);
            ApplyRestrictions(false, restrictionsToDisable);
        }
        
        public void ApplyRestrictions(bool enabling, string[] restrictions)
        {
            Debug.Log("Applying Restrictions :");
            Debug.Log(enabling);
            Debug.Log(restrictions);
            foreach (string restrictionType in restrictions)
            {
                if (restrictionType.Contains("Detector"))
                {
                    Debug.Log("Detector");
                    ActivationDetectorFor(enabling, restrictionType.Replace("Detector ", "").Split(" "));
                }
                else if (restrictionType.Contains("SubScript"))
                {
                    Debug.Log("SubScript");
                    ActivationRestrictionsSubscripts(enabling, restrictionType.Replace("SubScript ", "").Split(" "));
                    // ActivationSubScripts(enabling, restrictionType.Replace("SubScript ", "").Split(" "));
                }
                else
                {
                    Debug.Log("Any");
                    ActivationAllFor(enabling, restrictionType.Split(" "));
                }
            }
        }
        
        public void ManageControls()
        {
            Debug.Log("Index Current Activated : " + indexCurrentActivatedControl);
            Debug.Log("Player Control : " + playerControls.Length);

            // ApplyRestrictions();

            if (indexCurrentActivatedControl != -1)
            {
                if (playerControls[indexCurrentActivatedControl].IsFinished() || !playerControls[indexCurrentActivatedControl].enabled)
                {
                    // Launch disable player control procedure
                    EnablingPlayerControlProcedure(playerControls[indexCurrentActivatedControl], false);
                
                    // Reset the index for the current activated control
                    indexCurrentActivatedControl = -1;
                
                    print("Control current : ended. New index : " + indexCurrentActivatedControl);
                    // ApplyRestrictions();
                }
            }
            
            if (indexCurrentActivatedControl == -1)
            {
                // Debug.Log("Verify activations");
                for (int i = 0; i < playerControls.Length; ++i)
                {
                    // Debug.Log(i);
                    // Debug.Log("Can be activated : "  + !playerControls[i].activationRestricted);
                    // Debug.Log("Is Triggered : "  + playerControls[i].IsTriggered());
                    if (playerControls[i].IsTriggered() && !playerControls[i].enabled)
                    {
                        // Launch enable player control procedure
                        EnablingPlayerControlProcedure(playerControls[i], true);
                        
                        // Activate the player control
                        playerControls[i].enabled = true;
                        
                        // Actualize the index for the current control activated
                        indexCurrentActivatedControl = i;
                        print("Player control activated : " + playerControls[i].GetControlType() + " // index : " + i);
                        
                        // Leave the loop to avoid enabling 2 controls at the same time (only 1 control activated at once)
                        break;
                    }
                }
            }
            
        }

        public void ResetFinishedInteractionsAndRegisterCycleToDatabaseIfPossible(bool quizzStarted)
        {
            foreach (PlayerControl control in playerControls)
            {
                if (!control.IsFinished()) continue;
                Debug.Log(control.IsFinished());
                Debug.Log(control.GetControlType());
                control.SetFinished(false);
                if (control.IsRegisterable() && control.GetType().IsSubclassOf(typeof(CycleInteraction)))
                {
                    StartCoroutine(linkWeb.AddInteraction(control.GetControlTypeSimplified(), ((CycleInteraction)control).GetValue(),
                        quizzStarted));
                }
                    
            }
        }

        public void ActivationDetectorFor(bool activationDetector, string[] typesRegex)
        {
            foreach (PlayerControl control in playerControls)
            {
                if (MatchIdentifiers(control.GetControlType(), typesRegex))
                {
                    if (!activationDetector)
                    {
                        control.enabled = false;
                    }
                    control.activationRestricted = activationDetector;
                    
                }

            }

        }
        
        // public void ActivationSubScriptsFor(bool activation, string[] typesRegex)
        // {
        //     SetActivation(activation, typesRegex, 2);
        // }
        
        public void ActivationAllFor(bool activation, string[] typesRegex)
        {
            ActivationDetectorFor(activation, typesRegex);
            ActivationSubScripts(activation, typesRegex);
        }
        
        
        public void ActivationRestrictionsSubscripts(bool restricted, string[] regexIdentifiers)
        {
            for (int i = 0; i < associationScripts.Length; ++i)
            {
                if (MatchIdentifiers(associationScripts[i].Item1, regexIdentifiers))
                {
                    associationScripts[i] = new Tuple<string, bool, MonoBehaviour>(associationScripts[i].Item1, restricted, associationScripts[i].Item3);
                    if (restricted)
                    {
                        associationScripts[i].Item3.enabled = false;
                    }
                    else if (CanBeActivated(associationScripts[i].Item1, false))
                    {
                        associationScripts[i].Item3.enabled = true;
                    }
                }
            }
        }
    
        public void ActivationSubScripts(bool activation, string[] regexIdentifiers)
        {
            for (int i = 0; i < associationScripts.Length; ++i)
            {
                if (associationScripts[i].Item2) continue;
                if (MatchIdentifiers(associationScripts[i].Item1, regexIdentifiers))
                {
                    associationScripts[i].Item3.enabled = activation;
                }
            }
        }
    
        public static bool MatchIdentifiers(string name, string[] identifiers)
        {
            foreach (string identifier in identifiers)
            {
                if (!name.Contains(identifier)) return false;
            }

            return true;
        }

        /// <summary>
        /// Verifies if a script whose name is put in the parameters is included in the restrictions of a player control. <br/>
        /// </summary>
        /// <param name="name">The name associated to the script</param>
        /// <param name="currentControl">The player control you want to verify uses the script</param>
        /// <returns>
        /// Returns 0 if there is no association.<br/>
        /// Returns 1 if the association is in the ToEnable array of the control.<br/>
        /// Returns 2 if the association is in the ToDisable array of the control.
        /// </returns>
        public static int AssociatedToControl(string name, PlayerControl currentControl)
        {
            foreach (string idRegex in currentControl.scriptsToEnable)
            {
                if (MatchIdentifiers(name, idRegex.Split(" "))) return 1;
            }
            foreach (string idRegex in currentControl.scriptsToDisable)
            {
                if (MatchIdentifiers(name, idRegex.Split(" "))) return 2;
            }

            return 0;
        }

        public bool CanBeActivated(string nameScript, bool currentlyRestricted)
        {
            if (currentlyRestricted) return false;
            if (indexCurrentActivatedControl != -1 && playerControls[indexCurrentActivatedControl].enabled)
            {
                int associationToCurrentControl =
                    AssociatedToControl(nameScript, playerControls[indexCurrentActivatedControl]);
                if (associationToCurrentControl == 2) return false;
            }

            return true;
        }

        public void EnablingPlayerControlProcedure(PlayerControl control, bool enabling)
        {
            foreach (Tuple<string, Boolean, MonoBehaviour> script in associationScripts)
            {
                if (script.Item2) continue;
                int association = AssociatedToControl(script.Item1, control);
                if (association == 1)
                {
                    script.Item3.enabled = enabling;
                }
                else if (association == 2)
                {
                    script.Item3.enabled = !enabling;
                }
            }
        }
        
        // public void ActivationPlayerControl(PlayerControl control, bool enabling)
        // {
        //     foreach (Tuple<string, Boolean, MonoBehaviour> script in associationScripts)
        //     {
        //         if (script.Item2) continue;
        //         int association = AssociatedToControl(script.Item1, control);
        //         if (association == 1)
        //         {
        //             script.Item3.enabled = enabling;
        //         }
        //         else if (association == 2)
        //         {
        //             script.Item3.enabled = !enabling;
        //         }
        //     }
        // }
        
        // public void EnablingPlayerControlProcedure2(PlayerControl control, bool enabling)
        // {
        //     foreach (string toEnable in control.scriptsToEnable2)
        //     {
        //         ActivationSubScripts(enabling, toEnable.Split(" "));
        //     }
        //     foreach (string toDisable in control.scriptsToDisable2)
        //     {
        //         ActivationSubScripts(enabling, toDisable.Split(" "));
        //     }
        // }

    }
    
    
    
}