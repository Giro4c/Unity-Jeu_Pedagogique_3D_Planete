using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Script.WebData;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Services
{
    public class InteractionChecking : MonoBehaviour
    {

        [SerializeField] private PlayerControl[] playerControls;
        private int indexCurrentActivatedControl = -1;

        public string[] restrictions { get; private set; } = new string[0];

        private IdentifiableRestrictable[] scripts;
        // private Tuple<string, Boolean, MonoBehaviour>[] scripts = new Tuple<string, bool, MonoBehaviour>[0];

        [SerializeReference] private WebDatabaseAccess linkWeb;


        /// <summary>
        /// <para>
        /// Initialize scripts array based on all the instances of IdentifiableRestrictable present in the active scene.<br/>
        /// Excludes IdentifiableRestrictable classes that are subclasses of PlayerControl.
        /// </para>
        /// </summary>
        public void Initialize()
        {
            IdentifiableRestrictable[] array = Array.Empty<IdentifiableRestrictable>();
            
            // Get all root gameObjects of the active scene
            List<GameObject> rootObjectsInScene = new List<GameObject>();
            Scene scene = SceneManager.GetActiveScene();
            scene.GetRootGameObjects(rootObjectsInScene);
            
            // Look for all IdentifiableRestrictable classes in the scene
            foreach (GameObject o in rootObjectsInScene)
            {
                IdentifiableRestrictable[] added = o.GetComponentsInChildren<IdentifiableRestrictable>();
                array = array.Concat(added).ToArray();
            }

            // Remove Player Controls from array
            List<IdentifiableRestrictable> list = array.ToList();
            while (RemoveAPlayerControl(list))
            {
                Debug.Log("List new size : " + list.Count);
            }

            // Set the scripts attribute to the created array
            scripts = list.ToArray();
            
            // Debugging :
            // Debug.Log("Init interactions checking. Array IdentifiableRestrictable Length : " + array.Length);
            // foreach (IdentifiableRestrictable iRestrictable in scripts)
            // {
            //     Debug.Log(iRestrictable.GetType().Name);
            // }
        }

        private bool RemoveAPlayerControl(List<IdentifiableRestrictable> list)
        {
            foreach (IdentifiableRestrictable id in list)
            {
                if (id.GetType().IsSubclassOf(typeof(PlayerControl)))
                {
                    Debug.Log("Object of class Player Control : " + id.GetType().Name);
                    list.Remove(id);
                    return true;
                }
            }

            return false;
        }

        public void NewRestrictions(string[] newRestrictions)
        {
            bool newRs = AreNewRestrictions(newRestrictions);
            restrictions = newRestrictions;
            if (newRs)
            {
                ApplyRestrictions();
            }
        }

        private bool AreNewRestrictions(string[] newRestrictions)
        {
            // Verify if same size
            if (newRestrictions.Length != restrictions.Length) return true;
            
            // Verify all elements identical in restrictions
            for (int i = 0; i < restrictions.Length; ++i)
            {
                if (newRestrictions[i] != restrictions[i]) return true;
            }
            // Everything is identical
            return false;
        }
        
        public void ApplyRestrictions()
        {
            ApplyRestrictions(restrictions);
        }
        
        // public void ApplyRestrictions(string[] restrictionsToApply)
        // {
        //     Debug.Log("Applying Restrictions :");
        //     Debug.Log(restrictionsToApply);
        //     foreach (string restrictionType in restrictionsToApply)
        //     {
        //         if (restrictionType.Contains("Detector"))
        //         {
        //             Debug.Log("Detector");
        //             RestrictDetection(restrictionType.Replace("Detector ", "").Split(" "));
        //         }
        //         else if (restrictionType.Contains("SubScript"))
        //         {
        //             Debug.Log("SubScript");
        //             RestrictSubscripts(restrictionType.Replace("SubScript ", "").Split(" "));
        //             // ActivationSubScripts(enabling, restrictionType.Replace("SubScript ", "").Split(" "));
        //         }
        //         else
        //         {
        //             Debug.Log("Any");
        //             RestrictionsAll(restrictionType.Split(" "));
        //         }
        //     }
        // }
        
        public void ApplyRestrictions(string[] restrictionsToApply)
        {
            Debug.Log("Applying Restrictions :");
            Debug.Log(restrictionsToApply);
            int i = 0;
            
            // PlayerControls
            foreach (PlayerControl control in playerControls)
            {
                for (i = 0; i < restrictionsToApply.Length; ++i)
                {
                    if (restrictions[i].Contains("SubScript")) continue;
                    if (control.MatchRegex(restrictionsToApply[i].Replace("Detector", "").Split(" ")))
                    {
                        control.Activate(false);
                        control.activationRestricted = true;
                        break;
                    }
                }

                if (i >= restrictionsToApply.Length)
                {
                    control.activationRestricted = false;
                }
            }
            
            // Subscripts
            foreach (IdentifiableRestrictable script in scripts)
            {
                for (i = 0; i < restrictionsToApply.Length; ++i)
                {
                    if (restrictions[i].Contains("Detector")) continue;
                    if (script.MatchRegex(restrictionsToApply[i].Replace("SubScript", "").Split(" ")))
                    {
                        script.Activate(false);
                        script.activationRestricted = true;
                        break;
                    }
                }

                if (i >= restrictionsToApply.Length)
                {
                    script.activationRestricted = false;
                    if (CanBeActivated(script))
                    {
                        script.Activate(true);
                    }
                }
            }
            
        }
        
        public void ManageControls()
        {
            // Debug.Log("Index Current Activated : " + indexCurrentActivatedControl);
            // Debug.Log("Player Control : " + playerControls.Length);

            // ApplyRestrictions();

            if (indexCurrentActivatedControl != -1)
            {
                if (playerControls[indexCurrentActivatedControl].IsFinished() || !playerControls[indexCurrentActivatedControl].enabled)
                {
                    // Launch disable player control procedure
                    ActivationPlayerControl(playerControls[indexCurrentActivatedControl], false);
                
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
                        ActivationPlayerControl(playerControls[i], true);
                        
                        // Activate the player control
                        // playerControls[i].enabled = true;
                        
                        // Actualize the index for the current control activated
                        indexCurrentActivatedControl = i;
                        print("Player control activated : " + playerControls[i].GetIdentifier() + " // index : " + i);
                        
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
                Debug.Log(control.GetIdentifier());
                control.SetFinished(false);
                if (control.IsRegisterable() && control.GetType().IsSubclassOf(typeof(CycleInteraction)))
                {
                    StartCoroutine(linkWeb.AddInteraction(control.GetControlTypeSimplified(), ((CycleInteraction)control).GetValue(),
                        quizzStarted));
                }
                    
            }
        }

        public void RestrictDetection(string[] typesRegex)
        {
            foreach (PlayerControl control in playerControls)
            {
                if (control.MatchRegex(typesRegex))
                {
                    control.enabled = false;
                    control.activationRestricted = true;
                }
                else
                {
                    control.activationRestricted = false;
                }
            }
        }
        
        public void ActivationDetectorFor(bool activationDetector, string[] typesRegex)
        {
            foreach (PlayerControl control in playerControls)
            {
                if (control.MatchRegex(typesRegex))
                {
                    if (!activationDetector)
                    {
                        control.enabled = false;
                    }
                    control.activationRestricted = activationDetector;
                    
                }

            }
        }
        
        public void RestrictionsAll(string[] typesRegex)
        {
            RestrictDetection(typesRegex);
            RestrictSubscripts(typesRegex);
        }
        
        public void ActivationAllFor(bool activation, string[] typesRegex)
        {
            ActivationDetectorFor(activation, typesRegex);
            ActivationSubScripts(activation, typesRegex);
        }
        
        
        public void ActivationRestrictionsSubscripts(bool restricted, string[] regexIdentifiers)
        {
            for (int i = 0; i < scripts.Length; ++i)
            {
                if (scripts[i].MatchRegex(regexIdentifiers))
                {
                    scripts[i].activationRestricted = restricted;
                    if (restricted)
                    {
                        scripts[i].Activate(false);
                    }
                    // The script is unrestricted
                    else if (CanBeActivated(scripts[i]))
                    {
                        scripts[i].Activate(true);
                    }
                }
            }
        }
        
        public void RestrictSubscripts(string[] regexIdentifiers)
        {
            foreach (IdentifiableRestrictable script in scripts)
            {
                if (script.MatchRegex(regexIdentifiers))
                {
                    script.activationRestricted = true;
                    script.Activate(false);
                    // The script is unrestricted
                    
                }
                else
                {
                    script.activationRestricted = false;
                    if (CanBeActivated(script))
                    {
                        script.Activate(true);
                    }
                }
            }
        }
    
        public void ActivationSubScripts(bool activation, string[] regexIdentifiers)
        {
            for (int i = 0; i < scripts.Length; ++i)
            {
                if (scripts[i].activationRestricted) continue;
                if (scripts[i].MatchRegex(regexIdentifiers))
                {
                    scripts[i].Activate(activation);
                }
            }
        }

        /// <summary>
        /// Verifies if a script whose name is put in the parameters is included in the restrictions of a player control. <br/>
        /// </summary>
        /// <param name="script">The script we want to verify the association</param>
        /// <param name="currentControl">The player control you want to verify uses the script</param>
        /// <returns>
        /// Returns 0 if there is no association.<br/>
        /// Returns 1 if the association is in the ToEnable array of the control.<br/>
        /// Returns 2 if the association is in the ToDisable array of the control.
        /// </returns>
        public static int AssociatedToControl(IdentifiableRestrictable script, PlayerControl currentControl)
        {
            foreach (string idRegex in currentControl.toEnable)
            {
                if (script.MatchRegex(idRegex.Split(" "))) return 1;
            }
            foreach (string idRegex in currentControl.toDisable)
            {
                if (script.MatchRegex(idRegex.Split(" "))) return 2;
            }

            return 0;
        }

        public bool CanBeActivated(IdentifiableRestrictable script)
        {
            if (script.activationRestricted) return false;
            if (indexCurrentActivatedControl != -1 && playerControls[indexCurrentActivatedControl].enabled)
            {
                int associationToCurrentControl =
                    AssociatedToControl(script, playerControls[indexCurrentActivatedControl]);
                if (associationToCurrentControl == 2) return false;
            }

            return true;
        }

        public void ActivationPlayerControl(PlayerControl control, bool enabling)
        {
            foreach (IdentifiableRestrictable script in scripts)
            {
                if (script.activationRestricted) continue;
                int i;
                for (i = 0; i < control.toEnable.Length; ++i)
                {
                    if (script.MatchRegex(control.toEnable[i].Split(" ")))
                    {
                        script.Activate(enabling);
                        Debug.Log(script.GetIdentifier() + " affected.");
                        break;
                    }
                }
                
                if (i < control.toEnable.Length) continue;
                Debug.Log(script.GetIdentifier() + " not in to enable list.");
                for (i = 0; i < control.toDisable.Length; ++i)
                {
                    if (script.MatchRegex(control.toDisable[i].Split(" ")))
                    {
                        script.Activate(!enabling);
                        Debug.Log(script.GetIdentifier() + " affected.");
                        break;
                    }
                }
                if (i < control.toDisable.Length) continue;
                Debug.Log(script.GetIdentifier() + " not in to disable list.");
                
            }
            Debug.Log( "Control : " + control.GetIdentifier() + " activated.");
            control.enabled = enabling;
        }
        
        // public void EnablingPlayerControlProcedure(PlayerControl control, bool enabling)
        // {
        //     foreach (Tuple<string, Boolean, MonoBehaviour> script in scripts)
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
        
        
    }
    
    
    
}